using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6
{
    public class MyButton : Button
    {
        public static RoutedEvent MyButtonClickEvent;
        static MyButton()
        {
            MyButtonClickEvent = EventManager.RegisterRoutedEvent("MyButtonClick", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(MyButton));

        }

        public event RoutedEventHandler MyButtonClick
        {
            add { AddHandler(MyButtonClickEvent, value); }
            remove { RemoveHandler(MyButtonClickEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            RoutedEventArgs args = new RoutedEventArgs(MyButton.MyButtonClickEvent, this);
            RaiseEvent(args);
        }
    }
}
