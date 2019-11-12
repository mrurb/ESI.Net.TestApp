using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESI.Net.TestApp.Data;
using ESI.NET;
using ESI.NET.Models.Skills;
using ESI.NET.Models.SSO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ESI.Net.TestApp.Controllers
{
    [Authorize]
    public class EVEController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEsiClient esiClient;
        private readonly UserManager<ApplicationUser> userManager;

        public EVEController(ILogger<HomeController> logger, IEsiClient esiClient, UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            this.esiClient = esiClient;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SkillQueue()
        {
            await Util.Esi.UpdateTokenAsync(await HttpContext.GetTokenAsync("refresh_token"), await userManager.GetUserAsync(User), esiClient);

            EsiResponse<List<SkillQueueItem>> esiResponse = await esiClient.Skills.Queue();
            if(esiResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Failed to get result", esiResponse.Exception);
            }
            return View(esiResponse.Data);
        }
        
    }
}