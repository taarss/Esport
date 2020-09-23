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
using Esport.business;

namespace Esport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Business business = new Business();
        private bool addNewSponser;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void playerRegNextBtn_Click(object sender, RoutedEventArgs e)
        {            
            if (playerName.Text != "" && playerPhoneNumber.Text != "" && playerRank.Text != "" && playerUsername.Text != "")
            {
                ApiHandler apiHandler = new ApiHandler();
                
                    apiHandler.getUser(playerUsername.Text);
                    
                        DatabaseHandler databaseHandler = new DatabaseHandler();
                        if (databaseHandler.DoesPlayerExists(playerPhoneNumber.Text) == true)
                        {
                            MessageBox.Show("En spiller med dette telefon nummer findes allerede");
                        }
                        else
                        {
                            business.CreatePlayer(playerName.Text, playerUsername.Text, Convert.ToInt32(playerRank.Text), playerPhoneNumber.Text, 0);
                            if (addNewSponser == true)
                            {
                                business.CreateSponser(companyName.Text, field.Text, Convert.ToInt32(cost.Text));
                            }
                        }
                    
                
                
            }
        }

        private void addSponserConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (companyName.Text != "" && field.Text != "" && cost.Text != "")
            {
                addNewSponser = true;
                addSponser.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Du skal indtaste værdier");
            }
        }

        private void addSponserBtn_Click(object sender, RoutedEventArgs e)
        {
            addSponser.Visibility = Visibility.Visible;
        }

        private void closeAddSponser_Click(object sender, RoutedEventArgs e)
        {
            addSponser.Visibility = Visibility.Hidden;
            addNewSponser = false;
        }
    }
}
