using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutDoor_Models.Models;

namespace OutDoor_Models.Responses.Post
{
    public class InformationPostResponse
    {
        public string Id { get; set; }
        public UserModel User { get; set; }
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string ContactNumber { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public double? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<CommentModel>? Comments { get; set; }

    }
}
