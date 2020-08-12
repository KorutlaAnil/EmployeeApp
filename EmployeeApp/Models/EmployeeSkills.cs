using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    [Table("EmployeeSkills")]
    public class EmployeeSkills
    {
        [Key]
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skill Skill { get; set; }
    }
}
