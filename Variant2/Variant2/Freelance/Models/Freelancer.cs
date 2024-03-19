namespace Freelance.Models;

public class Freelancer
{
    public int Id { get; set; }
    public int ReferenceUserId { get; set; }
    public User ReferenceUser { get; set; }
    public string Username { get; set; }
    public string Experience { get; set; }
    public ICollection<Skill> Skills { get; set; }
    public decimal Rating { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Bid> Proposals { get; set; }
    public ICollection<Review> Reviews { get; set; }
}