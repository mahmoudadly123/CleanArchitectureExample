using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.MVC.ViewModels.Book;

namespace CleanArchitecture.MVC.ObjectMapping.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ViewBookDto, ViewBookViewModel>().ReverseMap();
            CreateMap<CreateBookDto, CreateBookViewModel>().ReverseMap();
            CreateMap<UpdateBookDto, UpdateBookViewModel>().ReverseMap();
            CreateMap<DeleteBookDto, DeleteBookViewModel>().ReverseMap();
            
            CreateMap<ViewBookViewModel, CreateBookViewModel>().ReverseMap();
            CreateMap<ViewBookViewModel, UpdateBookViewModel>().ReverseMap();
            CreateMap<ViewBookViewModel, DeleteBookViewModel>().ReverseMap();
        }
    }
}
