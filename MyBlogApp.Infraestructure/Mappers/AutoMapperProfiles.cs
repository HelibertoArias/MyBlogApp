using AutoMapper;
using MyBlogApp.Core.Entities;
using MyBlogApp.Infraestructure.Models;
using MyBlogApp.Infraestructure.Responses;

namespace MyBlogApp.Infraestructure.Mappers
{
    /// <summary>
    /// auto mapper profiles.
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfiles"/> class.
        /// </summary>
        public AutoMapperProfiles()
        {
            CreateMap<Post, PostItemModel>()
                .ForMember(dest => dest.AutorName, opt =>
                {
                    opt.MapFrom(src => src.Autor.Username);
                })
                .ForMember(dest => dest.PostStatusName, opt =>
                {
                    opt.MapFrom(src => src.PostStatus.Name);
                });

            CreateMap<Post, PostEditAddModel>().ReverseMap();

 

            CreateMap<PostStatus, PostStatusModel>().ReverseMap();


            CreateMap<User, UserLoginResponse>()
             .ForMember(dest => dest.RoleName, opt =>
              {
                  opt.MapFrom(src => src.Role.Name);
              }).ForMember(dest => dest.Id, opt =>
              {
                  opt.MapFrom(src => src.UserId);
              });



        }
    }
}
