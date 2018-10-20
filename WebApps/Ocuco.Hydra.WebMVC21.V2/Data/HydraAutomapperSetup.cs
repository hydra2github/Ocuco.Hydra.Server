using AutoMapper;
using Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels;
using Ocuco.DataModel.Catalog.Entities;
using Ocuco.DataModel.Hydradb.Entities;
using Ocuco.Hydra.WebMVC21.V2.ViewModels;

namespace Ocuco.Hydra.WebMVC21.V2.Data
{
    public class HydraAutomapperSetup : Profile
    {
        public HydraAutomapperSetup()
        {
            // Sample data

            CreateMap<ArtOrder, ArtOrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<ArtOrderItem, ArtOrderItemViewModel>()
                .ReverseMap();

            ////////////////////
            //
            // Catalogue

            CreateMap<Customer, CustomerViewModel>()
                .ReverseMap();

            CreateMap<Catalogue, CatalogueViewModel>()
                .ForMember(o => o.Manufacturer, ex => ex.MapFrom(o => o.Manufacturer.ManufacturerName))
                .ReverseMap();

            CreateMap<Product, ProductViewModel>()
                .ReverseMap();

            CreateMap<HubBrand, DropDownListViewModel>()
                .ForMember(o => o.label, ex => ex.MapFrom(o => o.OcuBrandName))
                .ForMember(o => o.value, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<Product, DropDownListViewModel>()
                .ForMember(o => o.label, ex => ex.MapFrom(o => o.ArticleName))
                .ForMember(o => o.value, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

        }
    }
}
