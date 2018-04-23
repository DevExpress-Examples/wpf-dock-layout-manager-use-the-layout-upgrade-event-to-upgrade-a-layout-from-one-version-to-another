using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.ComponentModel;
using DevExpress.Xpf.Docking;

using DevExpress.Xpf.Core.Serialization;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Utils.Serializing;

namespace Q557494
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DXSerializer.AddLayoutUpgradeHandler(DockManager, layoutUpgrade);
        }
        private void layoutUpgrade(object sender, LayoutUpgradeEventArgs e)
        {
            if (e.RestoredVersion == "1")
            {
                documentGroup1.MDIStyle = MDIStyle.MDI;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DockManager.SaveLayoutToXml("..//..//layout.xml");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DockManager.RestoreLayoutFromXml("..//..//layout.xml");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string layoutVersion = DXSerializer.GetLayoutVersion(DockManager);
            int number = int.Parse(layoutVersion);
            number++;
            DXSerializer.SetLayoutVersion(DockManager, number.ToString());
        }
    }

}

