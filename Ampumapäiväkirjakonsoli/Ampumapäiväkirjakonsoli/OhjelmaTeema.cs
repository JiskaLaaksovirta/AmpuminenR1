using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Diagnostics;

namespace Ampumapäiväkirjakonsoli
{
    class OhjelmaTeema
    {
        public static void ChangeTheme(Uri themeuri)
        {
            ResourceDictionary theme = new() { Source = themeuri };

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(theme);

        }

    }    
}
