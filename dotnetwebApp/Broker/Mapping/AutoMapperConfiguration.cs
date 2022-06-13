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
            CreateMap<Post, PostViewModel>();
        }
    }
}
