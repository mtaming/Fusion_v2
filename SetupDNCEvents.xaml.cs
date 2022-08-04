using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for SetupDNCEvents.xaml
    /// </summary>
    public partial class SetupDNCEvents : Page
    {
        public SetupDNCEvents()
        {
            InitializeComponent();
        }

        private void createeventBtn_Click(object sender, RoutedEventArgs e)
        {
            createEventGrid.Visibility = Visibility.Visible;
        }

        private void canceleventBtn_Click(object sender, RoutedEventArgs e)
        {
            createEventGrid.Visibility = Visibility.Collapsed;
        }
    }
}
