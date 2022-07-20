using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_USING_ADO.Net.Models
{
    [Table("Employee")]
      public class Employee
    { 
            [Key]
            [ScaffoldColumn(false)]
            public int Id { get; set; }
            [Required(ErrorMessage = "Employee name is required")]
            [DataType(DataType.Text)]
            [Display(Name = "Employee Name")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Salary is required")]
            [Display(Name = "Salary")]
            
            public double Salary { get; set; }
        
      }
}  
