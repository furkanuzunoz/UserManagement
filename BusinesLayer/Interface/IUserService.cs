using UserManagement.DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserManagement.BusinesLayer.Interface
{
    public interface IUserService
    {
        public Response UserCreate(Users user);
        public Response UserUpdate(ForUpdate newUser);
        public Response UserDelete(string name, string lastname, string gsm);
        public List<DtoUsers> UserListing();
    }
}
