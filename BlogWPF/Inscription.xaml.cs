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

namespace BlogWPF
{
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        public Inscription(MainWindow w)
        {
            InitializeComponent();
            mw = w;
        }
        private MainWindow mw;
        private void Button_Inscription(object sender, RoutedEventArgs e)
        {
            User usr = new User(pseudo.Text,MDP.Text);
            mw.Db.Liste_Db_User.Add(usr);
            mw.Db.SaveChanges();

            MessageBox.Show("Inscription réussie", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}