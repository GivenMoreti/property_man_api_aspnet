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

            //Lease Mappings
            CreateMap<Lease, LeaseDTO>();


            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();
        }


    }

}