using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Admin2.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext() : base("dbcontext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbcontext, Hospoital_app.Migrations.Configuration>("dbcontext"));
        }
        
    }
}