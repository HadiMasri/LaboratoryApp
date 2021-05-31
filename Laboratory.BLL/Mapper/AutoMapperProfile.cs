using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.BLL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdressDto, Adress>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<LaboDto, Labo>().ReverseMap();
            CreateMap<Patient_TestDto, Patient_Test>().ReverseMap();
            CreateMap<PatientDto, Patient>().ReverseMap();
            CreateMap<SexDto, Gender>().ReverseMap();
            CreateMap<TestDto, Test>().ReverseMap();
            CreateMap<TestRangeDto, TestRange>().ReverseMap();
            CreateMap<TitleDto, Title>().ReverseMap();
        }
    }
}
