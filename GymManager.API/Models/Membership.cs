namespace GymManager.API.Models;

public class Membership
{
    public int Id { get; set; }

    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;

    public int MembershipPlanId { get; set; }
    public MembershipPlan MembershipPlan { get; set; } = null!;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}