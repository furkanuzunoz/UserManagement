using Dapper;
using UserManagement.DataAccesLayer.Interface;
using UserManagement.DataAccesLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace UserManagement.DataAccesLayer
{
    public class DbOperations : IDbOperations
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public DbOperations(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
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
                return new Response { message = "User created susccesfuly", state = true };
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

                return new Response { message = "User Deleted succesfuly", state = true };
            }
        }

        public List<DtoUsers> UserListing()
        {
            var Con = new SqlConnection(_configuration.GetConnectionString("Default"));

            var result = Con.Query<Users>("Select * From Users Where State=1").ToList() ;

            List<DtoUsers> dto = _mapper.Map<List<DtoUsers>>(result);
            dto[0].state = true ;
            return dto;
            

        }

        public Response UserUpdate(ForUpdate newUser)
        {
            using (var Con = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                if (newUser.DateOfBirth == null)
                {
                    //sdasd
                }
                Con.Execute("UPDATE Users SET Name=@name,LastName=@LastName,DateOfBirth=@DateOfBirth,Email=@Email,Gsm=@Gsm," +
                    "Tittle=@Tittle,DepartmanId=@DepartmanId WHERE Id=@Id",
                    new
                    {
                        newUser.Name,
                        newUser.Lastname,
                        newUser.DateOfBirth,
                        newUser.Email,
                        newUser.Gsm,
                        newUser.Tittle,
                        newUser.DepartmanId,
                        newUser.id
                    });
                return new Response { message = "User Updated succesfuly", state = true };
            }
        }
    }
}
