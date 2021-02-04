using AutoMapper;
using DynamicScreen.Business.Services;
using DynamicScreen.Data.Models;
using DynamicScreen.Dto;
using DynamicScreen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

    }

    public static class ConfigurationMapper
    {
        public static MapperConfiguration MapperConfiguration()
        {
            var methodColumnService = new MethodColumnService();
            return new MapperConfiguration(conf => {
                conf.AddProfile<AutoMapperProfile>();
                
                conf.CreateMap<ConfigurationModel, ConfigurationTabDto>()
                .ForMember(dest => dest.RowId, opt => opt.Ignore())
                .ForMember(dest => dest.ConfigurationRow, opt => opt.MapFrom(src => src.ConfigurationRow))
                .ForMember(dest => dest.ConfigurationColumn, opt => opt.MapFrom(src => src.ConfigurationColumn));

                conf.CreateMap<ConfigurationTabDto, ConfigurationModel>()
                .ForMember(dest => dest.ConfigurationRow, opt => opt.MapFrom(src => src.ConfigurationRow))
                .ForMember(dest => dest.ConfigurationColumn, opt => opt.MapFrom(src => src.ConfigurationColumn));

                conf.CreateMap<ConfigurationRowDto, ConfigurationRowModel>()
                .ForMember(dest => dest.ConfigurationValue, opt => opt.MapFrom(src => src.ConfigurationValue));

                conf.CreateMap<ConfigurationRowModel, ConfigurationRowDto>()
                .ForMember(dest => dest.ConfigurationValue, opt => opt.MapFrom(src => src.ConfigurationValue));

                conf.CreateMap<ConfigurationColumnModel, ConfigurationColumnDto>()
                .ForMember(dest => dest.Component, opt => opt.ResolveUsing(o => MapComponent(o.Component)))
                .ForMember(dest => dest.EnableValues, opt => opt.ResolveUsing(o => methodColumnService.ExecuteMethod(o.Method)));

                conf.CreateMap<ConfigurationColumnDto, ConfigurationColumnModel>()
                .ForMember(dest => dest.Component, opt => opt.ResolveUsing(o => o.Component.ToString()))
                .ForMember(dest => dest.ConfigurationValue, opt => opt.Ignore())
                .ForMember(dest => dest.ConfigurationColumnSource, opt => opt.Ignore())
                .ForMember(dest => dest.ConfigurationColumnDestination, opt => opt.Ignore())
                .ForMember(dest => dest.Configuration, opt => opt.Ignore());

                conf.CreateMap<ConfigurationValueModel, ConfigurationValueDto>()
                .ForMember(dest => dest.Column, opt => opt.Ignore());

                conf.CreateMap<ConfigurationValueDto, ConfigurationValueModel>()
                .ForMember(dest => dest.ConfigurationColumn, opt => opt.Ignore())
                .ForMember(dest => dest.ConfigurationRow, opt => opt.Ignore());

                conf.CreateMap<ConfigurationColumnFillModel, ConfigurationColumnFillDto>();

                conf.CreateMap<ConfigurationColumnFillDto, ConfigurationColumnFillModel>()
                .ForMember(dest => dest.ConfigurationColumnDestination, opt => opt.Ignore())
                .ForMember(dest => dest.ConfigurationColumnSource, opt => opt.Ignore());
            });
        }

        public static ComponentAllowed MapComponent(string component)
        {
            if (Enum.TryParse(component, out ComponentAllowed componentAllowed))
                return componentAllowed;
            return ComponentAllowed.TextBox;
        }
    }
}
