namespace GymManager.API.Models;

public class MembershipPlan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public int DurationInDays { get; set; }
}