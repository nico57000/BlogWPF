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
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion(MainWindow w)
        {
            InitializeComponent();
            mw = w;
        }
        private MainWindow mw;
        private void Button_Connexion(object sender, RoutedEventArgs e)
        {
            try
            {
                User us = (from u in mw.Db.Liste_Db_User
                           where u.Pseudo == pseudo.Text && u.password == MDP.Text
                           select u).First();
                if (us.droit != droits.Admin)
                {
                    us.droit = droits.User;
                }
                
                MessageBox.Show("bienvenue " + pseudo.Text);
                ((MainWindow)System.Windows.Application.Current.MainWindow).affichage_user.Text = us.Pseudo + " " + us.droit.ToString();
                mw.connectedUser = us;
                mw.ajouter.IsEnabled = true;
                mw.supprimer.IsEnabled = true;
                mw.Modifier.IsEnabled = true;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Vous n'etes pas enregistré");

            }
            

        }
    }
}
