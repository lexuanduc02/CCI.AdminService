using CCI.Domain.Entities;
using CCI.Model.DepartmentModels;
using Profile = AutoMapper.Profile;

namespace CCIAdmin.ModuleRegistrations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentModel>();
        }
    }
}
