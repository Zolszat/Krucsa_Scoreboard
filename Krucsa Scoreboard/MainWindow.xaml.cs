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
using System.Speech.Synthesis;

namespace Krucsa_Scoreboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int team1_score_sum; // adott körben elért pontszám (120-as)
        int team2_score_sum; // adott körben elért pontszám (120-as)
        int point_to_reach; // licit miatt ennyit kell elérni
        int team1_final_score; // adott körben elért pontszám (15-ös)
        int team2_final_score; // adott körben elért pontszám (15-ös)
        int round_number; // hányadik kör
        int team1to15; // 15-ig tartó pontozásban
        int team2to15; // 15-ig tartó pontozásban
        int started_dealer;
        int actual_dealer;
        string[] players;
        SpeechSynthesizer speaker;
        Brush brush;
        public MainWindow()
        {
            InitializeComponent();
            brush = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            started_dealer = 0;
            actual_dealer = 0;
            speaker = new SpeechSynthesizer();
            Csapatnevek team_names = new Csapatnevek();
            team_names.ShowDialog();
            if(team_names.DialogResult==true)
            {
                teamname_1.Text = team_names.csapatnev1;
                teamname_2.Text = team_names.csapatnev2;
            }
            players = new string[4];
            players[0] = team_names.player1;
            players[1] = team_names.player2;
            players[2] = team_names.player3;
            players[3] = team_names.player4;
            speaker.SpeakAsync($"The next dealer is {players[actual_dealer++]}");
            team1_score_sum = 0;
            team2_score_sum = 0;
            round_number = 1;
            team1to15 = 0;
            team2to15 = 0;
            team1_final_score = 0;
            team2_final_score = 0;
            team1_lb.Items.Add(new Label() { Content = $"   KÖR\t\t     PONTSZÁM\t\tAKTUÁLIS", FontSize = 30, FontWeight = FontWeights.Heavy, Background = Brushes.BurlyWood});
            team2_lb.Items.Add(new Label() { Content = $"   KÖR\t\t     PONTSZÁM\t\tAKTUÁLIS", FontSize = 30, FontWeight = FontWeights.Heavy, Background = Brushes.BurlyWood});
        }

        private void husz_1_1_Click(object sender, RoutedEventArgs e)
        {
            if (husz_1_1.Background != Brushes.Green)
            {
                husz_1_1.Background = Brushes.Green;
                team1_score_sum += 20;
            }
            else
            {
                husz_1_1.Background = brush;
                team1_score_sum -= 20;
            }
        }

        private void negyven_1_Click(object sender, RoutedEventArgs e)
        {
            if (negyven_1.Background != Brushes.Red)
            {
                negyven_1.Background = Brushes.Red;
                team1_score_sum += 40;
            }
            else
            {
                negyven_1.Background = brush;
                team1_score_sum -= 40;
            }
        }

        private void husz_1_2_Click(object sender, RoutedEventArgs e)
        {
            if (husz_1_2.Background != Brushes.Green)
            {
                husz_1_2.Background = Brushes.Green;
                team1_score_sum += 20;
            }
            else
            {
                husz_1_2.Background = brush;
                team1_score_sum -= 20;
            }
        }

        private void husz_1_3_Click(object sender, RoutedEventArgs e)
        {
            if (husz_1_3.Background != Brushes.Green)
            {
                husz_1_3.Background = Brushes.Green;
                team1_score_sum += 20;
            }
            else
            {
                husz_1_3.Background = brush;
                team1_score_sum -= 20;
            }
        }

        private void husz_2_1_Click(object sender, RoutedEventArgs e)
        {
            if (husz_2_1.Background != Brushes.Green)
            {
                husz_2_1.Background = Brushes.Green;
                team2_score_sum += 20;
            }
            else
            {
                husz_2_1.Background = brush;
                team2_score_sum -= 20;
            }
        }

        private void negyven_2_Click(object sender, RoutedEventArgs e)
        {
            if (negyven_2.Background != Brushes.Red)
            {
                negyven_2.Background = Brushes.Red;
                team2_score_sum += 40;
            }
            else
            {
                negyven_2.Background = brush;
                team2_score_sum -= 40;
            }
        }

        private void husz_2_2_Click(object sender, RoutedEventArgs e)
        {
            if (husz_2_2.Background != Brushes.Green)
            {
                husz_2_2.Background = Brushes.Green;
                team2_score_sum += 20;
            }
            else
            {
                husz_2_2.Background = brush;
                team2_score_sum -= 20;
            }
        }

        private void husz_2_3_Click(object sender, RoutedEventArgs e)
        {
            if (husz_2_3.Background != Brushes.Green)
            {
                husz_2_3.Background = Brushes.Green;
                team2_score_sum += 20;
            }
            else
            {
                husz_2_3.Background = brush;
                team2_score_sum -= 20;
            }
        }

        private void kiszamol_Click(object sender, RoutedEventArgs e)
        {
            // Pontok kiértékelése *************
            if (licit_1.Text != "")
            {
                point_to_reach = int.Parse(licit_1.Text) * 33;
                if (pont_1.Text != "")
                {
                    team1_score_sum += int.Parse(pont_1.Text);
                    team2_score_sum += 120 - int.Parse(pont_1.Text);
                }
                else
                {
                    team1_score_sum += 120 - int.Parse(pont_2.Text);
                    team2_score_sum += int.Parse(pont_2.Text);
                }
                if (team1_score_sum<point_to_reach)
                {
                    team1_final_score = -1 * int.Parse(licit_1.Text);
                }
                else
                {
                    team1_final_score = team1_score_sum / 33;
                }
                team2_final_score = team2_score_sum / 33;
            }
            else
            {
                point_to_reach = int.Parse(licit_2.Text) * 33;
                if (pont_2.Text != "")
                {
                    team2_score_sum += int.Parse(pont_2.Text);
                    team1_score_sum += 120 - int.Parse(pont_2.Text);
                }
                else
                {
                    team2_score_sum += 120 - int.Parse(pont_1.Text);
                    team1_score_sum += int.Parse(pont_1.Text);
                }
                if (team2_score_sum < point_to_reach)
                {
                    team2_final_score = -1 * int.Parse(licit_2.Text);
                }
                else
                {
                    team2_final_score = team2_score_sum / 33;
                }
                team1_final_score = team1_score_sum / 33;
            }
            team1to15 += team1_final_score;
            team2to15 += team2_final_score;
            // Pontok kiértékelve *************
            // Pontok megjelenítése *************
            if (team1_final_score < 0)
            {
                team1_lb.Items.Add(new Label() { Content = $"[{round_number}. kör]\t\t\t{team1to15}\t\t      {team1_final_score}", FontSize = 30, FontWeight = FontWeights.Heavy});
                team2_lb.Items.Add(new Label() { Content = $"[{round_number}. kör]\t\t\t{team2to15}\t\t      +{team2_final_score}", FontSize = 30, FontWeight = FontWeights.Heavy });
            }
            else if (team2_final_score < 0)
            {
                team1_lb.Items.Add(new Label() { Content = $"[{round_number}. kör]\t\t\t{team1to15}\t\t      +{team1_final_score}", FontSize = 30, FontWeight = FontWeights.Heavy });
                team2_lb.Items.Add(new Label() { Content = $"[{round_number}. kör]\t\t\t{team2to15}\t\t      {team2_final_score}", FontSize = 30, FontWeight = FontWeights.Heavy });
            }
            else
            {
                team1_lb.Items.Add(new Label() { Content = $"[{round_number}. kör]\t\t\t{team1to15}\t\t      +{team1_final_score}", FontSize = 30, FontWeight = FontWeights.Heavy });
                team2_lb.Items.Add(new Label() { Content = $"[{round_number}. kör]\t\t\t{team2to15}\t\t      +{team2_final_score}", FontSize = 30, FontWeight = FontWeights.Heavy });
            }
            round_number++;
            // Pontok megjelenítve *************
            // Gombok színének visszaállítása *************
            var brush = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            foreach(var x in grid.Children)
            {
                if(x is Button)
                {
                    (x as Button).Background = brush;
                }
            }
            // Gombok színei visszaállítva *************
            // Pontok lenullázása következő körre *************
            pont_1.Text = "";
            pont_2.Text = "";
            team1_score_sum = 0;
            team2_score_sum = 0;
            point_to_reach = 0;
            team1_final_score = 0;
            team2_final_score = 0;
            // Pontok lenullázva következő körre *************
            // Játék végének ellenőrzése *************
            if (team1to15 >= 15 || team2to15 >= 15)
            {
                if (team1to15 >= 15 && team2to15 < 15)
                {
                    if (MessageBox.Show("Nyert az első csapat! Szeretnéd lenullázni az állást?") == MessageBoxResult.OK)
                    {
                        round_number = 1;
                        team1to15 = 0;
                        team2to15 = 0;
                        team1_lb.Items.Clear();
                        team2_lb.Items.Clear();
                    }
                }
                else if (team2to15 >= 15 && team1to15 < 15)
                {
                    if (MessageBox.Show("Nyert a második csapat! Szeretnéd lenullázni az állást?") == MessageBoxResult.OK)
                    {
                        round_number = 1;
                        team1to15 = 0;
                        team2to15 = 0;
                        team1_lb.Items.Clear();
                        team2_lb.Items.Clear();
                    }
                }
                else if (team1to15 >= 15 && team2to15 >= 15 && team1to15 == team2to15 && licit_1.Text != "")
                {
                    if (MessageBox.Show("Nyert az első csapat! Szeretnéd lenullázni az állást?") == MessageBoxResult.OK)
                    {
                        round_number = 1;
                        team1to15 = 0;
                        team2to15 = 0;
                        team1_lb.Items.Clear();
                        team2_lb.Items.Clear();
                    }
                }
                else
                {
                    if (MessageBox.Show("Nyert a második csapat! Szeretnéd lenullázni az állást?") == MessageBoxResult.OK)
                    {
                        round_number = 1;
                        team1to15 = 0;
                        team2to15 = 0;
                        team1_lb.Items.Clear();
                        team2_lb.Items.Clear();
                    }
                }
                team1_lb.Items.Add(new Label() { Content = $"   KÖR\t\t     PONTSZÁM\t\tAKTUÁLIS", FontSize = 30, FontWeight = FontWeights.Heavy, Background = Brushes.BurlyWood });
                team2_lb.Items.Add(new Label() { Content = $"   KÖR\t\t     PONTSZÁM\t\tAKTUÁLIS", FontSize = 30, FontWeight = FontWeights.Heavy, Background = Brushes.BurlyWood });
                started_dealer++;
                if(started_dealer>3)
                {
                    started_dealer = 0;
                }
                actual_dealer = started_dealer;
                speaker.SpeakAsync($"The next dealer is {players[actual_dealer++]}");
                if(actual_dealer>3)
                {
                    actual_dealer = 0;
                }
            }
            else
            {
                speaker.SpeakAsync($"The next dealer is {players[actual_dealer++]}");
                if(actual_dealer>3)
                {
                    actual_dealer = 0;
                }
            }
            // Játék vége ellenőrízve *************
            // Licitmezők lenullázása *************
            licit_1.Text = "";
            licit_2.Text = "";
            // Licitmezők lenullázva *************
        }
    }
}
