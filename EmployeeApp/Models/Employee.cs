using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address{ get; set; }
        public DateTime BirthDate{ get; set; }
        public DateTime Joindate{ get; set; }
        public string Gender{ get; set; }
        public int  RoleId{ get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Roles{ get; set; }
        public string About {get; set; }



    }
}
