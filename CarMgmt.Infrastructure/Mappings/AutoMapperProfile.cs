using AutoMapper;
using CarMgmt.Core;

namespace CarMgmt.Infrastructure
{
	public class AutoMapperProfile : Profile
	{ 
		public AutoMapperProfile()
		{
			CreateMap<Vehicle, VehicleDto>().ReverseMap();

			CreateMap<Model, ModelDto>().ReverseMap();

			CreateMap<Brand, BrandDto>().ReverseMap();

			CreateMap<Brand, BrandDto>().ReverseMap();

			CreateMap<Status, StatusDto>().ReverseMap();

		}
	}
}
