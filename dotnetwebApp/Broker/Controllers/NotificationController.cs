//using Broker.ApplicationDB;
//using Broker.Models;
//using Broker.Services.Interface;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;

//namespace Broker.Controllers
//{
//    public class NotificationController : INotification
//    {
//        public ApplicationDbContext _context { get; }
//        public NotificationController(ApplicationDbContext context)
//        {
//            _context=context;
//        }

       
//        public void Create(Notification notification)
//        {
//            _context.Notifications.Add(notification);
//            _context.SaveChanges();
//        }

//        public List<NotificationUser> GetUserNotifications(string userId)
//        {
//            return _context.UserNotifications.Where(u=>u.UserId.Equals(userId))
//                .Include(n=>n.Notification)
//                .ToList();
//        }

//        public void ReadNotification(int id)
//        {
//        }
//    }
//}
