using UserManagement.BusinesLayer.Interface;
using UserManagement.DataAccesLayer.Interface;
using UserManagement.DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.BusinesLayer.Concrete
{
    public class UserService : IUserService
    {
        private readonly IDbOperations _dbOperations;
        public UserService(IDbOperations dbOperations)
        {
            _dbOperations = dbOperations;
        }

        public Response UserCreate(Users user)
        {
            try
            {
                
                _dbOperations.UserCreate(user);
                return new Response {message="User Created Succesfuly" ,state=true };
            }
            catch (Exception)
            {
                return new Response { message = "User Created Fail Look at the Db operations", state = false };
            }
        }

        public Response UserDelete(string name, string lastname, string gsm)
        {
            try
            {
                _dbOperations.UserDelete(name, lastname, gsm);
                return new Response { message = "User Deleted Succesfuly", state = true }; ;
            }
            catch (Exception)
            {
                return new Response { message = "User Deleting Failed Some Db Operations error", state = false };
            }
            
        }

        public List<DtoUsers> UserListing()
        {
            try
            {
                var result = _dbOperations.UserListing();

                return result;
            }
            catch (Exception )
            {
                throw new Exception(message:"Some Db Operations Error");
            }
           
        }

        public Response UserUpdate(ForUpdate newUser)
        {
            try
            {
                _dbOperations.UserUpdate(newUser);
                return new Response { message = "User Updated Succesfuly", state = true }; ;
            }
            catch (Exception)
            {
                return new Response { message = "User Updated Failed Some Db Operations error" , state = false };
            }
        }
    }
}
