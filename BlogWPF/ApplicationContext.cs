using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BlogWPF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Liste_Db_User { get; set; }

        public DbSet<Article> Liste_Db_Articles { get; set; }

    }
}
