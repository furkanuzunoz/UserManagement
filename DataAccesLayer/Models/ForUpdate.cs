using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Models
{
    public class ForUpdate
    {
        public int id { get; set; }
        [Required(ErrorMessage ="plase give new user")]
        public Users newUser { get; set; }

    }
}
