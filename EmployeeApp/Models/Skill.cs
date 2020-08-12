using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    [Table("Skills")]
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
    }
}
