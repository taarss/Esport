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
using Esport.dal;

namespace Esport
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

        private void playerRegNextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (playerName.Text != "" && playerPhoneNumber.Text != "" && playerRank.Text != "" && playerUsername.Text != "")
            {
                ApiHandler apiHandler = new ApiHandler();
                try
                {
                    apiHandler.getUser(playerUsername.Text);
                    try
                    {
                        DatabaseHandler databaseHandler = new DatabaseHandler();
                        if (databaseHandler.DoesPlayerExists(playerPhoneNumber.Text) == true)
                        {
                            MessageBox.Show("En spiller med dette telefon nummer findes allerede");
                        }
                        else
                        {

                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bruger findes ikke i riot database");
                }
            }
        }
    }
}
