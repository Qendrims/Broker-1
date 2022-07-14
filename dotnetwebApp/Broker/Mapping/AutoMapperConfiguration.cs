using AutoMapper;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Broker.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Post,PostDetailViewModel>()
                .ForMember(x => x.Image, y => y.MapFrom(b => b.Images))
                .ForMember(x => x.OwnerId, y => y.MapFrom(b => b.PostUserId))
                .ForMember(x => x.OwnerName, y => y.MapFrom(b => b.User.Name + " " + b.User.LastName))
                .ForMember(x => x.NewPrice, y => y.MapFrom(b => b.NewPrice));
            
            CreateMap<PostViewModel, Post>()
                .ForMember(x => x.OldPrice, y => y.MapFrom(b => b.Price))
                .ForMember(x => x.NewPrice, y => y.MapFrom(b => b.Price));

            CreateMap<AdsPaymentViewModel, AdsPayments>();

            CreateMap<RegisterUserViewModel, User>();
            CreateMap<LoginUserModel, User>()
                .ForMember(u=>u.UserName,o=>o.MapFrom(x=>x.Email));
        }
    }
}

//.ForMember(x=>x.Title,y=>y.MapFrom(b=>b.Title))
               //.ForMember(x => x.Description, y => y.MapFrom(b => b.Description))
                //.ForMember(x => x.Price, y => y.MapFrom(b => b.Price))