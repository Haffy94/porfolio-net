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
                    Title = _localizer["MyPortfolioTitle"],
                    Description = _localizer["MyPortfolioDescription"],
                    Link = "https://portfolio-lucas-hafner.onrender.com/",
                    ImageURL = "/images/MyPortfolio.png"
                },
                new ProjectDTO
                {
                    Title = _localizer["MariacelestebrunettiTitle"],
                    Description = _localizer["MariacelestebrunettiDescription"],
                    Link = "https://www.mariacelestebrunetti.com/",
                    ImageURL = "/images/mariacelestebrunetti.png"
                }
            };
        }
    }
}
