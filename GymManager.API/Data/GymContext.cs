using Microsoft.EntityFrameworkCore;    // EF core
using GymManager.API.Models;    // import modelu User

namespace GymManager.API.Data;

public class GymContext : DbContext // klasa dziedziczy po DBContext
{
    // konstruktor okreslajacy opcje
    public GymContext(DbContextOptions<GymContext> options) : base(options)
    {
    }

    // tabela w bazie danych
    public DbSet<User> Users => Set<User>();
    public DbSet<Member> Members { get; set; }
    public DbSet<MembershipPlan> MembershipPlans { get; set; }
    public DbSet<Membership> Memberships { get; set; }
}