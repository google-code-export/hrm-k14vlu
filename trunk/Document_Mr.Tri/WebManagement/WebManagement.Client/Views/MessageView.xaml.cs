using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Telerik.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using WebManagement.Common;

namespace WebManagement.Client
{
    public partial class MessageView : RadWindow
    {
        public MessageView()
        {
            InitializeComponent();
        }

        public DialogMessage Diaglog { get; set; }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Diaglog != null)
                {
                    string[] strs = Diaglog.Caption.Split(';');
                    Diaglog.Caption = string.Empty;
                    for (int i = 0; i < strs.Length - 1; i++)
                        Diaglog.Caption += strs[i];
                    Header = Diaglog.Caption;
                    txtMessage.Text = Diaglog.Content;
                    switch (Diaglog.Button)
                    {
                        case MessageBoxButton.OK:
                            btnCancel.Visibility = Visibility.Collapsed;
                            break;
                    }

                    MessageImage img = (MessageImage)(Convert.ToInt32(strs[strs.Length - 1]));
                    imgAlert.Visibility = imgInfo.Visibility = imgWarning.Visibility = imgQues.Visibility = Visibility.Collapsed;
                    switch (img)
                    {
                        case MessageImage.Alert:
                            imgAlert.Visibility = Visibility.Visible;
                            break;
                        case MessageImage.Information:
                            imgInfo.Visibility = Visibility.Visible;
                            break;
                        case MessageImage.Warning:
                            imgWarning.Visibility = Visibility.Visible;
                            break;
                        case MessageImage.Question:
                            imgQues.Visibility = Visibility.Visible;
                            break;
                    }

                    this.KeyUp += new KeyEventHandler(MessageView_KeyUp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MessageView_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    if (Diaglog.Callback != null)
                        Diaglog.ProcessCallback(MessageBoxResult.OK);
                    this.Close();
                }
                else if (e.Key == Key.Escape)
                {
                    if (Diaglog.Callback != null)
                        Diaglog.ProcessCallback(MessageBoxResult.Cancel);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Diaglog.Callback != null)
                    Diaglog.ProcessCallback(MessageBoxResult.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Diaglog.Callback != null)
                    Diaglog.ProcessCallback(MessageBoxResult.Cancel);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

    }
}

