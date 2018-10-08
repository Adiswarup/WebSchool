using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCat7.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
