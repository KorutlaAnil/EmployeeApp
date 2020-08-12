using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    [Table("Hobbies")]
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
    }
}
