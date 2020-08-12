using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    [Table("EmployeeHobbies")]
    public class EmployeeHobbies
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int HobbyId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        [ForeignKey(nameof(HobbyId))]
        public Hobby Hobby { get; set; }
    }
}
