using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataAccesLayer.Models
{
    public class ForUpdate
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public string Tittle { get; set; }
        public int DepartmanId { get; set; }

    }
}
