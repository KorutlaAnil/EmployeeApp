using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<EmployeeHobbies> EmployeeHobbies { get; set; }
        public DbSet<EmployeeSkills> EmployeeSkills { get; set; }


    }
}
