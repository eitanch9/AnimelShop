using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class AnimalViewModel
    {
        public Animal Animal { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
