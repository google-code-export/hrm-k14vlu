using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Controls.Primitives;

namespace WebManagement.Common
{
    public class AcceptCancelBehavior : Behavior<ChildWindow>
    {
        #region AcceptButton Dependency Property
        public const string AcceptButtonPropertyName = "AcceptButton";

        public ButtonBase AcceptButton
        {
            get { return (ButtonBase)GetValue(AcceptButtonProperty); }
            set { SetValue(AcceptButtonProperty, value); }
        }

        public static readonly DependencyProperty AcceptButtonProperty =
            DependencyProperty.Register(AcceptButtonPropertyName,
            typeof(ButtonBase), typeof(AcceptCancelBehavior), null);

        #endregion

        #region CancelButton Dependency Property

        public const string CancelButtonPropertyName = "CancelButton";

        public ButtonBase CancelButton
        {
            get { return (ButtonBase)GetValue(CancelButtonProperty); }
            set { SetValue(CancelButtonProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonProperty =
            DependencyProperty.Register(CancelButtonPropertyName,
            typeof(ButtonBase), typeof(AcceptCancelBehavior), null);

        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.KeyUp += ChildWindow_KeyUp;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyUp -= ChildWindow_KeyUp;

            base.OnDetaching();
        }

        private void ChildWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ActivateButton(AcceptButton);
            }
            else if (e.Key == Key.Escape)
            {
                ActivateButton(CancelButton);
            }
        }

        private void ActivateButton(ButtonBase button)
        {
            if (button is Telerik.Windows.Controls.RadButton)
            {
                Telerik.Windows.Controls.RadButton btn = button as Telerik.Windows.Controls.RadButton;
                if (btn.Command != null
                    && btn.Command.CanExecute(button.CommandParameter))
                {
                    btn.Command.Execute(button.CommandParameter);
                }
            }
            else
            {
                if (button != null && button.Command != null
                    && button.Command.CanExecute(button.CommandParameter))
                {
                    button.Command.Execute(button.CommandParameter);
                }
            }
        }
    }
}
