using AutoMapper;
using Colossus.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colossus.DomainModel
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<FileStoreage, FileStorageViewModel>().ReverseMap();
        }
    }
}
