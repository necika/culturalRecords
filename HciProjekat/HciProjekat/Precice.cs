using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HciProjekat
{
    public static class Precice
    {
        public static readonly RoutedUICommand DodajSpomenik = new RoutedUICommand(
            "Model1",
            "DodajSpomenik",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand DodajTip = new RoutedUICommand(
            "Model2",
            "DodajTip",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand PrikazTip = new RoutedUICommand(
            "Model2",
            "PrikazTip",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.P, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand DodajEtiketu = new RoutedUICommand(
            "Model2",
            "DodajEtiketu",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand PrikazEtiketu = new RoutedUICommand(
            "Model2",
            "PrikazEtiketu",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Sacuvaj = new RoutedUICommand(
            "Model1",
            "Sacuvaj",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Pomoc = new RoutedUICommand(
            "Model1",
            "Pomoc",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.H, ModifierKeys.Control)
            }
        );
        public static readonly RoutedUICommand Login = new RoutedUICommand(
            "Model1",
            "Login",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.L, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Registracija = new RoutedUICommand(
            "Model1",
            "Registracija",
            typeof(Precice),
            new InputGestureCollection()
            {
                new KeyGesture(Key.R, ModifierKeys.Control)
            }
        );



    }
}
