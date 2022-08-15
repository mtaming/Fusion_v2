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
    /// Interaction logic for MachineManager.xaml
    /// </summary>
    public partial class MachineManager : Page
    {
        public MachineManager()
        {
            InitializeComponent();
        }

        private void GeneralGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Visible;
            FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.Khaki;
            gentb.Foreground = Brushes.Khaki;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;
        }

        private void CommGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CommunicationsTvI.IsExpanded = true;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;
        }

        private void FlashDNCGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FlashDNCSetGrid.Visibility = Visibility.Visible;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            GenSetGrid.Visibility = Visibility.Collapsed;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;
        }

        private void CbxFlashDNC_Checked(object sender, RoutedEventArgs e)
        {
            FlashDNC.Visibility = Visibility.Visible;
        }

        private void CbxFlashDNC_Unchecked(object sender, RoutedEventArgs e)
        {
            FlashDNC.Visibility = Visibility.Collapsed;
        }

        private void FocasGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocasSetGrid.Visibility = Visibility.Visible;
            FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            GenSetGrid.Visibility = Visibility.Collapsed;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;
        }

        private void CbxFocas_Checked(object sender, RoutedEventArgs e)
        {
            Focas.Visibility = Visibility.Visible;
        }

        private void CbxFocas_Unchecked(object sender, RoutedEventArgs e)
        {
            Focas.Visibility = Visibility.Collapsed;
        }
    }
}
