using AutoMapper;
using Colossus.Utility;
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
            CreateMap<FileStorageViewModel, FileStoreage>().ReverseMap();

            //CreateMap<FileStorageViewModel, FileStoreage>()
            //    .ForMember(dest => dest.FolderName, opt => opt.MapFrom(src => src.FolderName.Unescape()))
            //    .ForMember(dest => dest.ParentFolderName, opt => opt.MapFrom(src => src.ParentFolderName.Unescape()))
            //    .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath.Unescape()))
            //    .ForMember(dest => dest.FileCreationDate, opt => opt.MapFrom(src => src.FileCreationDate));

            //CreateMap<FileStoreage, FileStorageViewModel>()
            //    .ForMember(dest => dest.FolderName, opt => opt.MapFrom(src => src.FolderName.Unescape()))
            //    .ForMember(dest => dest.ParentFolderName, opt => opt.MapFrom(src => src.ParentFolderName.Unescape()))
            //    .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath.Unescape()))
            //    .ForMember(dest => dest.FileCreationDate, opt => opt.MapFrom(src => src.FileCreationDate));

        }
    }
}
