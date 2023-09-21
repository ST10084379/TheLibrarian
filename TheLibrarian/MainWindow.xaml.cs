using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace TheLibrarian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // When the user clicks the exit button
            System.Windows.Forms.MessageBox.Show("Thank you for using the Time Management application", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close(); // Closes the application
        }

        private void btnReplacingBooks_Click(object sender, RoutedEventArgs e)
        {
            ReplacingBooks replacingBooks = new ReplacingBooks();
            replacingBooks.Show();
            this.Close();
        }
    }
}
