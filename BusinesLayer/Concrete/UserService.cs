using BusinesLayer.Interface;
using DataAccesLayer.Interface;
using DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
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
                
                var result = _dbOperations.UserCreate(user);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Response UserDelete(string name, string lastname, string gsm)
        {
            try
            {
                var result = _dbOperations.UserDelete(name, lastname, gsm);
                return result;
            }
            catch (Exception)
            {
                return new Response { message = "User Deleting Failed", status = 401 };
            }
            
        }

        public List<Users> UserListing()
        {
            try
            {
                var result = _dbOperations.UserListing();
                return result;
            }
            catch (Exception)
            {
                throw new Exception(message:"User Listing Failed");
            }
           
        }

        public Response UserUpdate(ForUpdate newUser)
        {
            try
            {
                var result =_dbOperations.UserUpdate(newUser);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
