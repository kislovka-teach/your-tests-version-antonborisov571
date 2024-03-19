namespace Freelance.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ProjectType Type { get; set; }
    public decimal Budget { get; set; }
    public DateTime CreationDate { get; set; }
    public ProjectStatus Status { get; set; }
    public ICollection<Freelancer> Freelancers { get; set; }
    public ICollection<Bid> Proposals { get; set; }
    public ICollection<Review> Reviews { get; set; }
}