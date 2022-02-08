using Dapper;
using DataAccesLayer.Interface;
using DataAccesLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DbOperations : IDbOperations
    {
        private readonly IConfiguration _configuration;
        public DbOperations(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response UserCreate(Users user)
        {
            //var Con = new SqlConnection(_configuration.GetConnectionString("Default")) ;

            

            using (var Con = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                Con.Execute("insert into Users values (@Name,@LastName,@DateOfBirth,@Email,@Gsm,@Tittle,@DepartmanId,1)", new
                {
                    user.Name,
                    user.Lastname,
                    user.DateOfBirth,
                    user.Email,
                    user.Gsm,
                    user.Tittle,
                    user.DepartmanId
                });
                return new Response { message = "User created susccesfuly", status = 200 };
            }
        }

        public Response UserDelete(string name,string lastname ,string gsm)
        {
            using (var Con = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                Con.Execute("Update Users SET State=0 WHERE Name=@Name and LastName=@LastName and Gsm=@Gsm ", new {
                name,
                lastname,
                gsm
                });

                return new Response { message = "User Deleted succesfuly", status = 200 };
            }
        }

        public List<Users> UserListing()
        {
            using (var Con = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                //var result = Con.ExecuteReader("Select * From Users Where State=1");

                var result = Con.Query<Users>("Select * From Users Where State=1").ToList() ;
                return result;
            }
        }

        public Response UserUpdate(ForUpdate newUser)
        {
            using (var Con = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                Con.Execute("UPDATE Users SET Name=@name,LastName=@LastName,DateOfBirth=@DateOfBirth,Email=@Email,Gsm=@Gsm," +
                    "Tittle=@Tittle,DepartmanId=@DepartmanId WHERE Id=@Id",
                    new
                    {
                        newUser.newUser.Name,
                        newUser.newUser.Lastname,
                        newUser.newUser.DateOfBirth,
                        newUser.newUser.Email,
                        newUser.newUser.Gsm,
                        newUser.newUser.Tittle,
                        newUser.newUser.DepartmanId,
                        newUser.id
                    });
                return new Response { message = "User Updated succesfuly", status = 200 };
            }
        }
    }
}
