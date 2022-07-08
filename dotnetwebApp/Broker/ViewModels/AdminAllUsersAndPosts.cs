using Broker.Models;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class AdminAllUsersAndPosts
    {
       public List<User> Users { get; set; }
       public List<Post> Posts { get; set; }
    }
}
