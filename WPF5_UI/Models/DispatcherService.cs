using System;
using System.Windows.Threading;

namespace WPF5_UI.Models
{
    public static class DispatcherService
    {
        public static void Invoke(Action action)
        {
            Dispatcher dispatchObject = WPF5_UI.App.Current != null ? WPF5_UI.App.Current.Dispatcher : null;
            if (dispatchObject == null || dispatchObject.CheckAccess())
                action();
            else
                dispatchObject.Invoke(action);
        }
    }
}
