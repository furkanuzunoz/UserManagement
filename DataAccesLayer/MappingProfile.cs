using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DataAccesLayer.Models;

namespace UserManagement.DataAccesLayer.Interface
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, DtoUsers>().ForMember(dst=>dst.message , opt=>opt.Ignore())
                .ForMember(dst=>dst.state,opt=>opt.Ignore());
            CreateMap<DtoUsers, ModelWievUsers>();
        }
    }
}
