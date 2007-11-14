using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using TwitterLib;
using System.Collections.Specialized;
using System.IO;
using System.Globalization;

namespace Witty
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        public static User LoggedInUser = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            Properties.Settings appSettings = Witty.Properties.Settings.Default;

            try
            {
                if (!string.IsNullOrEmpty(appSettings.Skin))
                {
                    ResourceDictionary rd = new ResourceDictionary();
                    rd.MergedDictionaries.Add(Application.LoadComponent(new Uri(appSettings.Skin, UriKind.Relative)) as ResourceDictionary);
                    Application.Current.Resources = rd;
                }
            }
            catch
            {
            }


            base.OnStartup(e);
        }

        /// <summary>
        /// Gets the collection of skins
        /// </summary>
        public static NameValueCollection Skins
        {
            get
            {
                NameValueCollection skins = new NameValueCollection();

                foreach (string folder in Directory.GetDirectories(@".\"))
                {
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        if (string.Compare(fileInfo.Extension, ".xaml",  true, CultureInfo.InvariantCulture) == 0)
                        {
                            // Use the first part of the resource file name for the menu item name.
                            //skins.Add(fileInfo.Name.Remove(fileInfo.Name.IndexOf(".xaml")),
                            //    Path.Combine(folder, fileInfo.Name));

                            skins.Add(Path.Combine(folder, fileInfo.Name),  Path.Combine(folder, fileInfo.Name));
                        }
                    }
                }
                return skins;
            }
        }
    }
}