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
using Esport.entityLayer;
using System.Data.SqlClient;

namespace Esport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Business business = new Business();
        private bool addNewSponser;
        private int teamIndex;
        int index = 0;
        int index2 = 0;
        private int maxTeamPlayers;
        private bool teamOnePicked;
        private bool teamTwoPicked;
        private bool judgeSelected;
        private int judgeId;
        private int overviewIndex;
        private string staffType;
        private List<int> team1Id = new List<int>();
        private List<int> team2Id = new List<int>();


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
                    //Med hjælp fra Nico
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
                catch (Exception)
                {
                    MessageBox.Show("Denne bruger findes ikke i riot databasen.");
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

        private void regTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (playerReg.IsChecked == true)
            {
                regPlayer.Visibility = Visibility.Visible;
            }
            if (tourReg.IsChecked == true)
            {
                regtournament.Visibility = Visibility.Visible;
                teamIndex = 0;

            }
            if (staffReg.IsChecked == true)
            {
                regStaff.Visibility = Visibility.Visible;
            }
        }

        private void regTourBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tourName.Text == "" || teamOnePicked == false || teamTwoPicked == false)
            {
                MessageBox.Show("Alt info er ikke udfyldt");
            }
            else if (judgeSelected == true)
            {
                tourCreated.Visibility = Visibility.Visible;
                business.CreateTournament(tourName.Text, maxTeamPlayers.ToString(), team1Id, team2Id, judgeId);
                team1Id.Clear();
                team2Id.Clear();
            }
            else
            {
                MessageBox.Show("Vælg en dommer");
            }
        }

        private void pickTeamOneBtn_Click(object sender, RoutedEventArgs e)
        {
            if (teamOnePicked != true)
            {
                selectedPlayersStackpanel.Children.Clear();
            }
            teamIndex = 1;
            pickPlayers.Visibility = Visibility.Visible;
            teamTxt.Text = "Hold 1";
            DatabaseHandler databaseHandler = new DatabaseHandler();
            allPlayersStackPanel.Children.Clear();
            List<Player> players = databaseHandler.GetPlayers();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.IngameName;
                button.Tag = index;
                button.Click += new RoutedEventHandler(removeFromStack1_Click);
                allPlayersStackPanel.Children.Add(button);
                index++;
            }
        }

        private void pickTeamTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (teamTwoPicked != true)
            {
                selectedPlayersStackpanel.Children.Clear();
            }
            teamIndex = 2;
            pickPlayers.Visibility = Visibility.Visible;
            teamTxt.Text = "Hold 2";
            DatabaseHandler databaseHandler = new DatabaseHandler();
            allPlayersStackPanel.Children.Clear();
            List<Player> players = databaseHandler.GetPlayers();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.IngameName;
                button.Tag = index;
                button.Click += new RoutedEventHandler(removeFromStack1_Click);
                allPlayersStackPanel.Children.Add(button);
                index++;
            }
        }

        private void pickJudgeBtn_Click(object sender, RoutedEventArgs e)
        {
            pickJudge.Visibility = Visibility.Visible;
            DatabaseHandler databaseHandler = new DatabaseHandler();
            allJudges.Children.Clear();
            List<Judge> judges = databaseHandler.GetJudges();
            foreach (var item in judges)
            {
                Button button = new Button();
                button.Content = item.Name;
                button.Tag = index2;
                button.Click += new RoutedEventHandler(removeFromJudgeStack_Click);
                allJudges.Children.Add(button);
                index2++;
            }
        }

        private void removeFromStack1_Click(object sender, RoutedEventArgs e)
        {
            UIElement uI = null;
            Button button = sender as Button;
            int tempId = Convert.ToInt32(button.Tag);
            foreach (UIElement item in allPlayersStackPanel.Children)
            {
                Button tempButton = item as Button;
                if (Convert.ToInt32(tempButton.Tag) == tempId)
                {
                    uI = item;
                }
            }
            allPlayersStackPanel.Children.Remove(uI);
            Button parseButton = uI as Button;
            Button passButton = new Button();
            passButton.Tag = parseButton.Tag;
            passButton.Content = parseButton.Content;
            passButton.Click += new RoutedEventHandler(removeFromStack2_Click);
            selectedPlayersStackpanel.Children.Add(passButton);
            tempId--;
        }
        private void removeFromStack2_Click(object sender, RoutedEventArgs e)
        {
            UIElement uI = null;
            Button button = sender as Button;
            int tempId = Convert.ToInt32(button.Tag);
            foreach (UIElement item in selectedPlayersStackpanel.Children)
            {
                Button tempButton = item as Button;
                if (Convert.ToInt32(tempButton.Tag) == tempId)
                {
                    uI = item;
                }
            }
            selectedPlayersStackpanel.Children.Remove(uI);
            Button parseButton = uI as Button;
            Button passButton = new Button();
            passButton.Tag = parseButton.Tag;
            passButton.Content = parseButton.Content;
            passButton.Click += new RoutedEventHandler(removeFromStack1_Click);
            allPlayersStackPanel.Children.Add(passButton);
            tempId--;
        }

        private void removeFromJudgeStack_Click(object sender, RoutedEventArgs e)
        {
            judgeSelected = true;
            UIElement uI = null;
            Button button = sender as Button;
            int tempId = Convert.ToInt32(button.Tag);
            foreach (UIElement item in allJudges.Children)
            {
                Button tempButton = item as Button;
                if (Convert.ToInt32(tempButton.Tag) == tempId)
                {
                    uI = item;
                }
            }
            allJudges.Children.Remove(uI);
            Button parseButton = uI as Button;
            Button passButton = new Button();
            passButton.Tag = parseButton.Tag;
            passButton.Content = parseButton.Content;
            passButton.Click += new RoutedEventHandler(removeFromSelectedJudgeStack_Click);
            SelectedJudge.Children.Add(passButton);
            tempId--;
        }

        private void removeFromSelectedJudgeStack_Click(object sender, RoutedEventArgs e)
        {
            judgeSelected = false;
            UIElement uI = null;
            Button button = sender as Button;
            int tempId = Convert.ToInt32(button.Tag);
            foreach (UIElement item in SelectedJudge.Children)
            {
                Button tempButton = item as Button;
                if (Convert.ToInt32(tempButton.Tag) == tempId)
                {
                    uI = item;
                }
            }
            SelectedJudge.Children.Remove(uI);
            Button parseButton = uI as Button;
            Button passButton = new Button();
            passButton.Tag = parseButton.Tag;
            passButton.Content = parseButton.Content;
            passButton.Click += new RoutedEventHandler(removeFromJudgeStack_Click);
            allJudges.Children.Add(passButton);
            tempId--;
        }


        private void completePlayersPickedBtn_Click(object sender, RoutedEventArgs e)
        {

            if (OnevsOneBtn.IsChecked == true)
            {
                maxTeamPlayers = 1;
            }
            if (TwovsTwoBtn.IsChecked == true)
            {
                maxTeamPlayers = 3;
            }
            if (FivevsFiveBtn.IsChecked == true)
            {
                maxTeamPlayers = 5;
            }
            if (selectedPlayersStackpanel.Children.Count > maxTeamPlayers)
            {
                MessageBox.Show("Du valgte for mange spillere til denne slags turnering");
            }          
            else
            {
                if (selectedPlayersStackpanel.Children.Count < maxTeamPlayers)
                {
                    MessageBox.Show("Du valgte ikke nok spillere til denne slags turnering");
                }
                else
                {
                    if (teamIndex == 1)
                    {
                        teamOnePicked = true;
                        foreach  (UIElement uIElement in selectedPlayersStackpanel.Children)
                        {
                            Button button = uIElement as Button;
                            team1Id.Add(Convert.ToInt32(button.Tag));
                        }
                    }
                    else
                    {
                        teamTwoPicked = true;
                        foreach (UIElement uIElement in selectedPlayersStackpanel.Children)
                        {
                            Button button = uIElement as Button;
                            team2Id.Add(Convert.ToInt32(button.Tag));
                        }
                    }
                    pickPlayers.Visibility = Visibility.Hidden;
                }
            }
        }

        private void cornfirmSelectedJudge_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedJudge.Children.Count > 1)
            {
                MessageBox.Show("Du kan kun vælge en dommer");
            }
            else
            {
                Button button = SelectedJudge.Children[0] as Button;
                judgeId = Convert.ToInt32(button.Tag);
                pickJudge.Visibility = Visibility.Hidden;
            }
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            addNewSponser = false;
            teamIndex = 0;
            index = 0;
            index2 = 0;
            maxTeamPlayers = 0;
            teamOnePicked = false;
            teamTwoPicked = false;
            judgeSelected = false;
            regtournament.Visibility = Visibility.Hidden;
            pickPlayers.Visibility = Visibility.Hidden;
            pickJudge.Visibility = Visibility.Hidden;
            tourCreated.Visibility = Visibility.Hidden;
            overview.Visibility = Visibility.Hidden;
            overviewPanel.Visibility = Visibility.Hidden;
            SelectedJudge.Children.Clear();
            registrerMenu.Visibility = Visibility.Hidden;
            inputStaffInfo.Visibility = Visibility.Hidden;
            regStaff.Visibility = Visibility.Hidden;

        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            registrerMenu.Visibility = Visibility.Visible;
            overview.Visibility = Visibility.Hidden;
        }

        private void OnMouseMoveHandler(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(RootCanvas);
            double pX = p.X;
            double pY = p.Y;
            Canvas.SetTop(customPointer, pY);
            Canvas.SetLeft(customPointer, pX);
            Cursor = Cursors.None;
        }

        private void closeOverviewBtn_Click(object sender, RoutedEventArgs e)
        {
            overviewPanel.Visibility = Visibility.Hidden;
        }

        private void overviewSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void overviewSale_Click(object sender, RoutedEventArgs e)
        {
            overviewIndex = 0;
            overviewStackpanel.Children.Clear();
            overviewPanel.Visibility = Visibility.Visible;            
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Salesman> players = databaseHandler.GetSalesman();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.Name;
                button.Tag = item.Id;
                button.Click += new RoutedEventHandler(clickDetails_Click);
                overviewStackpanel.Children.Add(button);
                index++;
            }
        }

        private void overviewTech_Click(object sender, RoutedEventArgs e)
        {
            overviewIndex = 1;
            overviewStackpanel.Children.Clear();
            DatabaseHandler databaseHandler = new DatabaseHandler();
            overviewPanel.Visibility = Visibility.Visible;
            List<Technician> players = databaseHandler.GetTechnician();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.Name;
                button.Tag = item.Id;
                button.Click += new RoutedEventHandler(clickDetails_Click);
                overviewStackpanel.Children.Add(button);
                index++;
            }
        }

        private void overviewJudges_Click(object sender, RoutedEventArgs e)
        {
            overviewIndex = 2;
            overviewStackpanel.Children.Clear();
            overviewPanel.Visibility = Visibility.Visible;
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Judge> players = databaseHandler.GetJudges();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.Name;
                button.Tag = item.Id;
                button.Click += new RoutedEventHandler(clickDetails_Click);
                overviewStackpanel.Children.Add(button);
                index++;
            }
        }

        private void overviewTour_Click(object sender, RoutedEventArgs e)
        {
            overviewIndex = 3;
            overviewStackpanel.Children.Clear();
            overviewPanel.Visibility = Visibility.Visible;
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Tournament> players = databaseHandler.GetTournament();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.TournamentName;
                button.Tag = item.Id;
                button.Click += new RoutedEventHandler(clickDetails_Click);
                overviewStackpanel.Children.Add(button);
                index++;
            }
        }

        private void overviewPlayers_Click(object sender, RoutedEventArgs e)
        {
            overviewIndex = 4;
            overviewStackpanel.Children.Clear();
            overviewPanel.Visibility = Visibility.Visible;
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Player> players = databaseHandler.GetPlayers();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.IngameName;
                button.Tag = item.Id;
                button.Click += new RoutedEventHandler(clickDetails_Click);
                overviewStackpanel.Children.Add(button);
                index++;
            }
        }

        private void overviewSponser_Click(object sender, RoutedEventArgs e)
        {
            overviewIndex = 5;
            overviewStackpanel.Children.Clear();
            overviewPanel.Visibility = Visibility.Visible;
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Sponser> players = databaseHandler.GetSponser();
            foreach (var item in players)
            {
                Button button = new Button();
                button.Content = item.CompanyName;
                button.Tag = item.Id;
                button.Click += new RoutedEventHandler(clickDetails_Click);
                overviewStackpanel.Children.Add(button);
                index++;
            }
        }

        private void overviewBtn_Click(object sender, RoutedEventArgs e)
        {
            addNewSponser = false;
            teamIndex = 0;
            index = 0;
            index2 = 0;
            maxTeamPlayers = 0;
            teamOnePicked = false;
            teamTwoPicked = false;
            judgeSelected = false;
            regtournament.Visibility = Visibility.Hidden;
            pickPlayers.Visibility = Visibility.Hidden;
            pickJudge.Visibility = Visibility.Hidden;
            tourCreated.Visibility = Visibility.Hidden;
            overview.Visibility = Visibility.Visible;
            overviewPanel.Visibility = Visibility.Hidden;
            SelectedJudge.Children.Clear();
            registrerMenu.Visibility = Visibility.Hidden;
            inputStaffInfo.Visibility = Visibility.Hidden;
            regStaff.Visibility = Visibility.Hidden;
        }

        private void clickDetails_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            deleteCrudBtn.Tag = button.Tag;
            detailsCrudBtn.Tag = button.Tag;
            crudPopupBox.Visibility = Visibility.Visible;
        }



        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void closeCrudPopUpBtn_Click(object sender, RoutedEventArgs e)
        {
            crudPopupBox.Visibility = Visibility.Hidden;
            
            
        }

        private void deleteCrudBtn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            string deleteLocation = "";
            Button button = sender as Button;
            switch (overviewIndex)
            {
                case 0:
                    deleteLocation = "Salesman";
                    break;
                case 1:
                    deleteLocation = "Technician";
                    break;
                case 2:
                    deleteLocation = "Judge";
                    break;
                case 3:
                    deleteLocation = "Tournament";
                    break;
                case 4:
                    deleteLocation = "Player";
                    break;
                case 5:
                    deleteLocation = "Sponser";
                    break;
            }
            databaseHandler.DeleteRow(Convert.ToInt32(button.Tag), deleteLocation);
            switch (overviewIndex)
            {
                case 0:
                    deleteLocation = "Salesman";
                    overviewSale_Click(new object(), new RoutedEventArgs());
                    break;
                case 1:
                    deleteLocation = "Technician";
                    overviewTech_Click(new object(), new RoutedEventArgs());
                    break;
                case 2:
                    deleteLocation = "Judge";
                    overviewJudges_Click(new object(), new RoutedEventArgs());
                    break;
                case 3:
                    deleteLocation = "Tournament";
                    overviewTour_Click(new object(), new RoutedEventArgs());

                    break;
                case 4:
                    deleteLocation = "Player";
                    overviewPlayers_Click(new object(), new RoutedEventArgs());
                    break;
                case 5:
                    deleteLocation = "Sponser";
                    overviewSponser_Click(new object(), new RoutedEventArgs());
                    break;
            }
            crudPopupBox.Visibility = Visibility.Hidden;

        }

        private void regStaffBtn_Click(object sender, RoutedEventArgs e)
        {

            business.CreateStaff(Convert.ToInt32(inputLevel.Text), inputName.Text, Convert.ToInt32(inputPhone.Text), Convert.ToInt32(inputPay.Text), staffType);

        }

        private void regStaffTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isJudge.IsChecked == true)
            {
                staffType = "Judge";
            }
            else if (isSale.IsChecked == true)
            {
                staffType = "Salesman";
            }
            else if (isTech.IsChecked == true)
            {
                staffType = "Technician";
            }
            inputStaffInfo.Visibility = Visibility.Visible;
        }

        private void detailsCrudBtn_Click(object sender, RoutedEventArgs e)
        {
            crudPopupBox.Visibility = Visibility.Hidden;
            overviewDetailsPanel.Visibility = Visibility.Visible;
            DatabaseHandler databaseHandler = new DatabaseHandler();
            string getLocation = "";
            Button button = sender as Button;
            switch (overviewIndex)
            {
                case 0:
                    getLocation = "Salesman";
                    SetStaffDetails(index, "Salesman");
                    break;
                case 1:
                    getLocation = "Technician";
                    SetStaffDetails(index, "Technician");
                    break;
                case 2:
                    getLocation = "Judge";
                    SetStaffDetails(index, "Judge");
                    break;
                case 3:
                    getLocation = "Tournament";
                    SetTourDetails(Convert.ToInt32(button.Tag));
                    break;
                case 4:
                    getLocation = "Player";
                    SetPlayerDetails(Convert.ToInt32(button.Tag));
                    break;
                case 5:
                    getLocation = "Sponser";
                    SetSponserDetails(Convert.ToInt32(button.Tag));
                    break;
            }
        }


        private void SetStaffDetails(int index, string jobType)
        {

            DatabaseHandler databaseHandler = new DatabaseHandler();
            if (jobType == "Judge")
            {
                List<Judge> judges = databaseHandler.GetJudges();
                foreach (var item in judges)
                {
                    if (item.Id == index)
                    {
                        textblockPhone.Text = "Telefon";
                        nameInputTxt.Text = item.Name;
                        phoneInputTxt.Text = item.PhoneNumber.ToString();
                        textblock1.Text = "Dommer niveau";
                        textblock2.Text = "Løn";
                        textblock1input.Text = item.JudgeLevel1.ToString();
                        textblock2input.Text = item.Pay.ToString();
                    }
                }

            }
            if (jobType == "Technician")
            {
                List<Technician> technicians = databaseHandler.GetTechnician();
                foreach (var item in technicians)
                {
                    if (item.Id == index)
                    {
                        textblockPhone.Text = "Telefon";
                        nameInputTxt.Text = item.Name;
                        phoneInputTxt.Text = item.PhoneNumber.ToString();
                        textblock1.Text = "Dommer niveau";
                        textblock2.Text = "Løn";
                        textblock1input.Text = item.Level.ToString();
                        textblock2input.Text = item.Pay.ToString();
                    }
                }
            }
            if (jobType == "Salesman")
            {
                List<Salesman> salesmen = databaseHandler.GetSalesman();
                foreach (var item in salesmen)
                {
                    if (item.Id == index)
                    {
                        textblockPhone.Text = "Telefon";
                        nameInputTxt.Text = item.Name;
                        phoneInputTxt.Text = item.PhoneNumber.ToString();
                        textblock1.Text = "Dommer niveau";
                        textblock2.Text = "Løn";
                        textblock1input.Text = item.SalesmanLevel.ToString();
                        textblock2input.Text = item.Pay.ToString();
                    }
                }
            }
        }

        private void SetPlayerDetails(int index)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Player> players = databaseHandler.GetPlayers();
            foreach (var item in players)
            {
                if (item.Id == index)
                {
                    textblockPhone.Text = "Telefon";
                    nameInputTxt.Text = item.Name;
                    phoneInputTxt.Text = item.PhoneNumber;
                    textblock1.Text = "Ingame name";
                    textblock2.Text = "Rank";
                    textblock1input.Text = item.IngameName;
                    textblock2input.Text = item.Rank.ToString();
                }
            }
        }

        private void SetTourDetails(int index)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Tournament> players = databaseHandler.GetTournament();
            foreach (var item in players)
            {
                if (item.Id == index)
                {

                    nameInputTxt.Text = item.TournamentName;
                    textblockPhone.Text = "";
                    phoneInputTxt.Text = "";
                    textblock1.Text = "Type";
                    textblock2.Text = "";
                    textblock1input.Text = item.TournamentType;
                    textblock2input.Text = "";
                }
            }
        }

        public void SetSponserDetails(int index)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<Sponser> sponsers = databaseHandler.GetSponser();
            foreach (var item in sponsers)
            {
                if (item.Id == index)
                {

                    nameInputTxt.Text = item.CompanyName;
                    textblockPhone.Text = item.Field;
                    phoneInputTxt.Text = "Branche";
                    textblock1.Text = "Beløb";
                    textblock2.Text = "Spiller id";
                    textblock1input.Text = item.Cost.ToString();
                    textblock2input.Text = item.PlayerId.ToString();
                }
            }
        }

        private void closeDetailsOverviewBtn_Click(object sender, RoutedEventArgs e)
        {
            overviewDetailsPanel.Visibility = Visibility.Hidden;

        }
    }
    
}
