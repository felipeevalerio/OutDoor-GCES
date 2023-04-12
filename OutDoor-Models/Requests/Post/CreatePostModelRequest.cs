using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Requests.Post
{
    public class CreatePostModelRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Description { get; set; }
        public string? Image { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 13)]
        public string ContactNumber { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
