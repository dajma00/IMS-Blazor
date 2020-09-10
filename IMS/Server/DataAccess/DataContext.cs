using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using IMS.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IMS.Server.DataAccess
{
    
    namespace IMS.Server.DataAccess
    {
        public class DataContext : DbContext
        {
            public DataContext()
            {
            }

            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }
            
            public virtual DbSet<TitlesTable> tblTitles { get; set; }
            public virtual DbSet<Quote> tblQuotes { get; set; }
            public virtual DbSet<Vehicle> tblVehicles { get; set; }
            /*
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql("server=132.148.86.53; Database=kfacon; user=kfa; password=abc@12345;default command timeout=1800000;");
                }
            }
            */
        }
    }

}

