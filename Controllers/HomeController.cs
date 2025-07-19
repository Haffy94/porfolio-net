using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using Microsoft.AspNetCore.Localization;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly IProjectRepository projectRepository;
    private readonly IGmailService gmailService;

    public HomeController(ILogger<HomeController> logger, IProjectRepository projectRepository, IGmailService gmailService)
    {
        this.projectRepository = projectRepository;
        this.gmailService = gmailService;
    }

    public IActionResult Index()
    {
        var proyects = projectRepository.GetProjectDTOs().Take(3).ToList();
        var model = new HomeIndexViewModel() { Projects = proyects };
        return View(model);
    }

    public IActionResult Projects()
    {
        var projects = projectRepository.GetProjectDTOs();
        return View(projects);
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
    {
        await gmailService.SendContact(contactViewModel);
        return RedirectToAction("Thanks");
    }

    public IActionResult Knapp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            }
        );

        return LocalRedirect(returnUrl);
    }

    public IActionResult Thanks()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
