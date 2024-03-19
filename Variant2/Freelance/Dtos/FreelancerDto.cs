namespace Freelance.Dtos;

public class FreelancerDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Experience { get; set; }
    public List<string> Skills { get; set; }
    public decimal Rating { get; set; }
    public List<int> ProjectIds { get; set; }
}