using AutoMapper;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentApplication, StudentApplicationViewModel>().ReverseMap();
            CreateMap<TeacherApplication, TeacherApplicationViewModel>().ReverseMap();
            CreateMap<LessonType, LessonTypeViewModel>().ReverseMap();
            CreateMap<Group, GroupViewModel>().ReverseMap();
            CreateMap<StudentApplication, ManageStudentApplicationViewModel>().ReverseMap();
            CreateMap<TeacherApplication, ManageTeacherApplicationViewModel>().ReverseMap();
            CreateMap<ApplicationUser, StudentInfoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.PreviousGrade, opt => opt.MapFrom(src => src.Comments))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<ApplicationUser, TeacherInfoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Comments))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
