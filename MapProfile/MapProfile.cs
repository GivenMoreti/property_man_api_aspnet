using AutoMapper;
using PropertyManApi.DTO;
using PropertyManApi.Models;

namespace PropertyManApi.MapProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyDTO>();
            CreateMap<CreatePropertyDTO, Property>();
            CreateMap<UpdatePropertyDTO, Property>();

            //unit mappings
            CreateMap<Unit, UnitDTO>();
            CreateMap<CreateUnitDTO, Unit>();
            //Lease Mappings
            CreateMap<Lease, LeaseDTO>();
            CreateMap<CreateLeaseDTO, Lease>();

            //maintenance mappings
            CreateMap<MaintenanceRequest, MaintenanceRequestDTO>();
            CreateMap<CreateMaintenanceRequestDTO, MaintenanceRequest>();

            //tenant mappings
            CreateMap<Tenant, TenantDTO>();
            CreateMap<CreateTenantDTO, Tenant>();

            //user mappings
            CreateMap<UserDTO, User>();
            

            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();
        }


    }

}