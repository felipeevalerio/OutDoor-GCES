using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Models
{
    public class CreateCommentRequestModel
    {
        public string Image { get; set; }
        public string Review { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public int rating { get; set; }

    }
}
