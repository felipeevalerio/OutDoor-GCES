using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Models
{
    public class PostModel
    {
        [Key]
        public string  Id { get; set; }
        [ForeignKey("Fk_User_Post")]
        public string UserId { get; set; }
        [ForeignKey("FK_Category_Post")]
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public double? Rating { get; set; }
        public int? NumberOfRatings { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}

