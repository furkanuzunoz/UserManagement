using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataAccesLayer.Models
{
    public class ModelWievUsers
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public string Tittle { get; set; }
        public int DepartmanId { get; set; }
    }
}
