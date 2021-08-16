using Microsoft.EntityFrameworkCore;

namespace InternalProject1.Models{
    public class DataContext: DbContext{
        public DbSet<Employee> Employees {get;set;}

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
    }
}