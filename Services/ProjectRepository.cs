using Portfolio.Models;
using Microsoft.Extensions.Localization;

namespace Portfolio.Services
{
    public interface IProjectRepository
    {
        List<ProjectDTO> GetProjectDTOs();
    }

    public class ProjectRepository : IProjectRepository
    {
        private readonly IStringLocalizer<ProjectRepository> _localizer;

        public ProjectRepository(IStringLocalizer<ProjectRepository> localizer)
        {
            _localizer = localizer;
        }

        public List<ProjectDTO> GetProjectDTOs()
        {
            return new List<ProjectDTO>()
            {
                new ProjectDTO
                {
                    Title = _localizer["AmazonTitle"],
                    Description = _localizer["AmazonDescription"],
                    Link = "https://www.amazon.com/",
                    ImageURL = "/images/amazon.png"
                },
                new ProjectDTO
                {
                    Title = _localizer["NYTTitle"],
                    Description = _localizer["NYTDescription"],
                    Link = "https://www.nytimes.com/",
                    ImageURL = "/images/nyt.png"
                },
                new ProjectDTO
                {
                    Title = _localizer["SteamTitle"],
                    Description = _localizer["SteamDescription"],
                    Link = "https://www.steampowered.com/",
                    ImageURL = "/images/steam.png"
                }
            };
        }
    }
}
