using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRCore2WebApp.Hubs;
using SignalRCoreWebApp.Models;

namespace SignalRCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<MessageHub> _messageHubContext;
        public HomeController(IHubContext<MessageHub> messageHubContext)
        {
            _messageHubContext = messageHubContext;
        }

        public IActionResult Index()
        {
            return View(); // show the view
        }

        [HttpPost]
        public async Task<IActionResult> Index(string message)
        {
            await _messageHubContext.Clients.All.SendAsync("Send", message);
            return View();
        }
    }
}
