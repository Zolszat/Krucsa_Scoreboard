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
using System.Windows.Shapes;

namespace Krucsa_Scoreboard
{
    /// <summary>
    /// Interaction logic for Csapatnevek.xaml
    /// </summary>
    public partial class Csapatnevek : Window
    {
        public Csapatnevek()
        {
            InitializeComponent();
        }
        public string csapatnev1;
        public string csapatnev2;
        public string player1;
        public string player2;
        public string player3;
        public string player4;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player1 = jatekos_1.Text;
            player2 = jatekos_2.Text;
            player3 = jatekos_3.Text;
            player4 = jatekos_4.Text;
            csapatnev1 = player1 + "+" + player3;
            csapatnev2 = player2 + "+" + player4;
            DialogResult = true;
        }
    }
}
