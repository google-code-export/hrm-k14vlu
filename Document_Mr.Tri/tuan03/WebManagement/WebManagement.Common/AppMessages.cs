using System;
using System.IO;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

namespace WebManagement.Common
{
    public class AppMessages
    {
        enum MessageTypes
        {
            ChangeMenuItem,
            Window,
            WindowDialog,
            Send,
            HelpWindow
        }

        public static class WindowMessage
        {
            public static void Send(DialogMessage dialogMessage)
            {
                Messenger.Default.Send(dialogMessage, MessageTypes.Window);
            }

            public static void Register(object recipient, Action<DialogMessage> action)
            {
                Messenger.Default.Register(recipient, MessageTypes.Window, action);
            }
        }

        public static class WindowDialogMessage
        {
            public static void Send(DialogMessage dialogMessage)
            {
                Messenger.Default.Send(dialogMessage, MessageTypes.WindowDialog);
            }

            public static void Register(object recipient, Action<DialogMessage> action)
            {
                Messenger.Default.Register(recipient, MessageTypes.WindowDialog, action);
            }
        }

        public static class SendMessage
        {
            public static void Send(DialogMessage dialogMessage)
            {
                Messenger.Default.Send(dialogMessage, MessageTypes.Send);
            }

            public static void Register(object recipient, Action<DialogMessage> action)
            {
                Messenger.Default.Register(recipient, MessageTypes.Send, action);
            }
        }

        public static class HelpWindowMessage
        {
            public static void Send(string screenName)
            {
                Messenger.Default.Send(screenName, MessageTypes.HelpWindow);
            }

            public static void Register(object recipient, Action<string> action)
            {
                Messenger.Default.Register(recipient, MessageTypes.HelpWindow, action);
            }
        }

        public static class ChangeMenuItemMessage
        {
            public static void Send(string screenName)
            {
                Messenger.Default.Send(screenName, MessageTypes.ChangeMenuItem);
            }

            public static void Register(object recipient, Action<string> action)
            {
                Messenger.Default.Register(recipient, MessageTypes.ChangeMenuItem, action);
            }
        }
    }
}
