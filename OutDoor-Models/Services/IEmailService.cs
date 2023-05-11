using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Services
{
    public interface IEmailService
    {
        public void sendEmail(String email, String subject, String body, bool ishtml = false);
    }
}
