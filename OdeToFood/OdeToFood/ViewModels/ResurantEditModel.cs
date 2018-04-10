using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    public class ResurantEditModel
    {
        [Required, MaxLength(80)]
       public  string Name { get; set; }
        public CuisineType cuisine { get; set; }
    }
}
