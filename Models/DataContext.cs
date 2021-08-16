using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InternalProject1.Models{
    public class DataContext : DbContext{
        public DbSet<Employee> Employees {get;set;}
        public DataContext(){

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options){
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured){
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                var connectionString = @"server=LNAR-5CG1086QH1\SQLEXPRESS; initial catalog=EmployeeDatabase;integrated security=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
    
}