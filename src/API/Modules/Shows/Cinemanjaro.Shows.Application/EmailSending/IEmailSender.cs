using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.EmailSending
{
    public interface IEmailSender
    {
        public Task SendEmail(string to, string subject, string body);
    }
}
