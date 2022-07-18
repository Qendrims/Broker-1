using Broker.Models;
using System;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class AdminAllUsersAndPosts
    {
       public List<User> Users { get; set; }
       public List<Post> Posts { get; set; }
       
       public int Time = DateTime.Now.Month;


        public int SetPostCountForMonth(DateTime date)
        {
            int count = 0;
            foreach (var post in Posts)
                if(post.CreatedAt.Month == date.Month && post.CreatedAt.Year == date.Year) 
                    count++;
            return count;   
        }
        public int SetUserCountForMonth(DateTime date)
        {
            int count = 0;
            
            foreach (var user in Users)
                if (user.CreatedAt.Month == date.Month && user.CreatedAt.Year == date.Year)
                    count++;
            return count;
        }

    }
}
