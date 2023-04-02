using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public List<CommentModel> comments { get; set; }
        public DateTime CreateAt { get; set; }
        
    }
}
