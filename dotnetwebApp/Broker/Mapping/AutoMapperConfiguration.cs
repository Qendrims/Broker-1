using AutoMapper;
using Broker.Models;
using Broker.ViewModels;

namespace Broker.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Post,PostDetailViewModel>().ForMember(x=>x.Title,y=>y.MapFrom(b=>b.Title))
                .ForMember(x => x.Description, y => y.MapFrom(b => b.Description))
                .ForMember(x => x.Image, y => y.MapFrom(b => b.Images))
                .ForMember(x => x.OwnerId, y => y.MapFrom(b => b.PostUserId))
                .ForMember(x => x.OwnerName, y => y.MapFrom(b => b.User.Name + " " + b.User.LastName));
            
            CreateMap<PostViewModel, Post>();
            CreateMap<AdsPaymentViewModel, AdsPayments>();

            CreateMap< SUViewModel, SimpleUser>()
                .ForMember(x => x.Name, y => y.MapFrom(b => b.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(b => b.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(b => b.Email))
                .ForMember(x => x.Birthday, y => y.MapFrom(b => b.Birthday))
                .ForMember(x => x.Telephone, y => y.MapFrom(b => b.Telephone))
                .ForMember(x => x.Street, y => y.MapFrom(b => b.Street))
                .ForMember(x => x.State, y => y.MapFrom(b => b.State))
                .ForMember(x => x.City, y => y.MapFrom(b => b.City))
                .ForMember(x => x.ZipCode, y => y.MapFrom(b => b.ZipCode));
        }
    }
}

//.ForMember(x=>x.Title,y=>y.MapFrom(b=>b.Title))
               //.ForMember(x => x.Description, y => y.MapFrom(b => b.Description))
                //.ForMember(x => x.Price, y => y.MapFrom(b => b.Price))