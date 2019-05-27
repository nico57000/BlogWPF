using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogWPF
{
    public enum droits
    {
        User,
        Admin,
        Guest
    }
    public class User
    {

        [Key]
        public int Key { get; set; }
        [Column]
        public string Pseudo { get; set; }
        [Column]
        public string password { get; set; }
        [Column]
        public droits droit { get; set; }

        public User(string pseudo, string password)
        {
            Pseudo = pseudo;
            this.password = password;
            droit = droits.Guest;
            if (pseudo == "ADMIN" && password == "ADMIN")
            {
                droit = droits.Admin;
            }
        }

        public User()
        {

        }

    }
}
