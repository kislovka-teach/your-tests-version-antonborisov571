using Freelance.Models;

namespace Freelance.Dtos;

public class ProjectDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ProjectType Type { get; set; }
    public decimal Budget { get; set; }
    public DateTime CreationDate { get; set; }
}