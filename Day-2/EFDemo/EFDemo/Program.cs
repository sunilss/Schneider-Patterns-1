using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
            var emp = new Employee() {Name = "Magesh"};
            var manager = new Employee() {Name = "Rajesh"};
            emp.Manager = manager;
            var context = new AppContext();
            context.Employees.Add(emp);
            context.SaveChanges();
            Console.WriteLine("Done");
            Console.ReadLine();

        }
    }

    public class AppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Manager { get; set; }
    }
}
