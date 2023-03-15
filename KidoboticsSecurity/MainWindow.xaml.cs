using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KidoboticsSecurity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        // Imposes no restrictions on where the window can be displayed (Default)
        public static readonly uint WDA_NONE = 0;
        // The window content is displayed only on a monitor. Everywhere else, the window appears with no content
        public static readonly uint WDA_MONITOR = 1;
        /* The window is displayed only on a monitor. Everywhere else, the window does not appear at all.
        One use for this affinity is for windows that show video recording controls, so that the controls are not included in the capture */
        public static readonly uint WDA_EXCLUDEFROMCAPTURE = 3;

        [DllImport("user32.dll")]
        public static extern bool SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // getting tha mainwindow's window handel
            var hWnd = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

            // changine the window display affinity of the main window
            bool state = SetWindowDisplayAffinity(hWnd, WDA_MONITOR);
        }
    }
}
