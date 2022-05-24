using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Models
{
    public class Feedback
    {
        public string PermbajtjaFeedBackut { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

    }
}
