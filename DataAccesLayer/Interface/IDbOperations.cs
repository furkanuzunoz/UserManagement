using DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interface
{
    public interface IDbOperations
    {
        public Response UserCreate(Users user);
        public Response UserUpdate(ForUpdate newUser);
        public Response UserDelete(string name, string lastname, string gsm);
        public List<Users> UserListing();
    }
}
