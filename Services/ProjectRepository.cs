using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IProjectRepository
    {
        List<ProjectDTO> GetProjectDTOs();
    }
    public class ProjectRepository: IProjectRepository
    {
        public List<ProjectDTO> GetProjectDTOs()
        {
            return new List<ProjectDTO>()
            {
                new ProjectDTO
                {
                    Title = "Amazon",
                    Description = "E-commerce realizado en ASP.NET",
                    Link = "https://www.amazon.com/",
                    ImageURL = "/images/amazon.png"
                },
                new ProjectDTO
                {
                    Title = "The New york Time",
                    Description = "Pagina de noticias en React",
                    Link = "https://www.amazon.com/",
                    ImageURL = "/images/nyt.png"
                },
                new ProjectDTO
                {
                    Title = "Steam",
                    Description = "Desarrollo de videojuegos",
                    Link = "https://www.steam.com/",
                    ImageURL = "/images/steam.png"
                },

            };
        }
    }
}