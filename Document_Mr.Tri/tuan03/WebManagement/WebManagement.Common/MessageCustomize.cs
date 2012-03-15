using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace WebManagement.Common
{
    public enum MessageImage
    {
        None = 0,
        Alert = 1,
        Information = 2,
        Warning = 3,
        Question = 4
    }

    public static class MessageCustomize
    {
        public static void Show(string msg, string caption, MessageBoxButton button, MessageImage msgImage, Action<MessageBoxResult> callback)
        {
            DialogMessage result = new DialogMessage(null, msg, callback);
            result.Caption = caption + ";" + ((int)msgImage).ToString();
            result.Button = button;
            AppMessages.SendMessage.Send(result);
        }

        public static void Show(string msg, string caption, MessageImage msgImage, Action<MessageBoxResult> callback)
        {
            Show(msg, caption, MessageBoxButton.OK, msgImage, callback);
        }

        public static void Show(string msg, string caption, MessageImage msgImage)
        {
            Show(msg, caption, MessageBoxButton.OK, msgImage, null);
        }

        public static void Show(string msg)
        {
            Show(msg, "Thông báo", MessageBoxButton.OK, MessageImage.None, null);
        }
    }

    public static class CallWindow
    {
        public static void Show(object sender, string viewType, Action<MessageBoxResult> callback)
        {
            DialogMessage dialog = new DialogMessage(sender, viewType, callback);
            AppMessages.WindowMessage.Send(dialog);
        }
    }

    public static class CallDialog
    {
        public static void Show(object sender, string viewType, Action<MessageBoxResult> callback)
        {
            DialogMessage dialog = new DialogMessage(sender, viewType, callback);
            AppMessages.WindowDialogMessage.Send(dialog);
        }
    }
}
