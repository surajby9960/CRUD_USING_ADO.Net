﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_USING_ADO.Net.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
            [Required(ErrorMessage ="Product name is required")]
            [DataType(DataType.Text)]
            [Display(Name ="Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Price is required")]
        [Display(Name ="Product Price")]
        [Range(minimum:1,maximum:50000)]
        public double Price { get; set; }
    }
}
