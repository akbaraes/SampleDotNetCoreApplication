using AutoMapper;
using CodeSnippetSample.Models;
using DALLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippetSample.Extensions
{
    public class SampleMapper : Profile
    {
        public SampleMapper()
        {
            CreateMap<EmployeeModel, Employee>().ReverseMap();
        }
    }
}
