using System;
using System.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Data;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Markup;
using System.ComponentModel;

namespace Telerik.Windows.Controls.GridView.HeaderMenu
{
    public class GridViewHeaderMenu
    {
        private RadGridView grid = null;

        public GridViewHeaderMenu(RadGridView grid)
        {
            this.grid = grid;
        }

        public static readonly DependencyProperty IsEnabledProperty
            = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(GridViewHeaderMenu),
                new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        public static void SetIsEnabled(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(IsEnabledProperty, enabled);
        }

        public static bool GetIsEnabled(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsEnabledProperty);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
            if (grid != null)
            {
                if ((bool)e.NewValue)
                {
                    // Create new GridViewHeaderMenu and attach RowLoaded event.
                    GridViewHeaderMenu menu = new GridViewHeaderMenu(grid);
                    menu.Attach();
                }
            }
        }

        private void Attach()
        {
            if (grid != null)
            {
                // create menu
                RadContextMenu contextMenu = new RadContextMenu();
                // set menu Theme
                StyleManager.SetTheme(contextMenu, StyleManager.GetTheme(grid));

                contextMenu.Opened += OnMenuOpened;
                contextMenu.ItemClick += OnMenuItemClick;

                RadContextMenu.SetContextMenu(grid, contextMenu);
            }
        }

        void OnMenuOpened(object sender, RoutedEventArgs e)
        {
            RadContextMenu menu = (RadContextMenu)sender;
            GridViewHeaderCell cell = menu.GetClickedElement<GridViewHeaderCell>();

            if (cell != null)
            {
                menu.Items.Clear();

                RadMenuItem item = new RadMenuItem();
                item.Tag = "Ascending";
                item.Header = String.Format(@"Sắp xếp cột ""{0}"" tăng dần", cell.Column.Header);
                menu.Items.Add(item);

                item = new RadMenuItem();
                item.Tag = "Descending";
                item.Header = String.Format(@"Sắp xếp cột ""{0}"" giảm dần", cell.Column.Header);
                menu.Items.Add(item); 

                item = new RadMenuItem();
                item.Tag = "Clear";
                item.Header = String.Format(@"Xóa sắp xếp trên cột ""{0}""", cell.Column.Header);
                menu.Items.Add(item);

                item = new RadMenuItem();
                item.Header = "Chọn cột:";
                menu.Items.Add(item);

                // create menu items
                foreach (GridViewColumn column in grid.Columns)
                {
                    RadMenuItem subMenu = new RadMenuItem();
                    subMenu.Header = column.Header;
                    subMenu.IsCheckable = true;
                    subMenu.IsChecked = true;

                    Binding isCheckedBinding = new Binding("IsVisible");
                    isCheckedBinding.Mode = BindingMode.TwoWay;
                    isCheckedBinding.Source = column;

                    // bind IsChecked menu item property to IsVisible column property
                    subMenu.SetBinding(RadMenuItem.IsCheckedProperty, isCheckedBinding);

                    item.Items.Add(subMenu);
                }
            }
            else
            {
                menu.IsOpen = false;
            }
        }

        void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            RadContextMenu menu = (RadContextMenu)sender;

            GridViewHeaderCell cell = menu.GetClickedElement<GridViewHeaderCell>();
            RadMenuItem clickedItem = ((RadRoutedEventArgs)e).OriginalSource as RadMenuItem;
            GridViewColumn column = cell.Column;

            if (clickedItem.Parent is RadMenuItem)
                return;

            string header = Convert.ToString(clickedItem.Tag);

            using (grid.DeferRefresh())
            {
                ColumnSortDescriptor sd = (from d in grid.SortDescriptors.OfType<ColumnSortDescriptor>()
                                           where d.Column == column
                                           select d).FirstOrDefault();

                if (header.Contains("Ascending"))
                {
                    if (sd != null)
                    {
                        grid.SortDescriptors.Remove(sd);
                    }

                    ColumnSortDescriptor newDescriptor = new ColumnSortDescriptor();
                    newDescriptor.Column = column;
                    newDescriptor.SortDirection = ListSortDirection.Ascending;

                    grid.SortDescriptors.Add(newDescriptor);
                }
                else if (header.Contains("Descending"))
                {
                    if (sd != null)
                    {
                        grid.SortDescriptors.Remove(sd);
                    }

                    ColumnSortDescriptor newDescriptor = new ColumnSortDescriptor();
                    newDescriptor.Column = column;
                    newDescriptor.SortDirection = ListSortDirection.Descending;

                    grid.SortDescriptors.Add(newDescriptor);
                }
                else if (header.Contains("Clear"))
                {
                    if (sd != null)
                    {
                        grid.SortDescriptors.Remove(sd);
                    }
                }
            }
        }
    }
}
