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
using Fusion_v2.LandingPages;
using Fusion_v2.ViewMenu;
namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;
        private Menus item1;
        private ControlProgramLandingPage controlProgramLandingPage;

        public UserControlMenuItem(Menus menu, MainWindow context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = menu.SubMenus == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = menu.SubMenus == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = menu;
        }

        public UserControlMenuItem(Menus item1, ControlProgramLandingPage controlProgramLandingPage)
        {
            this.item1 = item1;
            this.controlProgramLandingPage = controlProgramLandingPage;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _context.SwitchScreen(((SubMenu)((ListView)sender).SelectedItem).Screen);
        }
    }
}
