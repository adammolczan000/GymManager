using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GymManager.API.Data;
using GymManager.API.Models;
using GymManager.API.DTOs;

namespace GymManager.API.Controllers;

[ApiController]
[Route("api/memberships")]
[Authorize]
public class MembershipsController : ControllerBase
{
    private readonly GymContext _context;

    public MembershipsController(GymContext context)
    {
        _context = context;
    }

    // =========================
    // CREATE MEMBERSHIP
    // =========================
    [HttpPost]
    public async Task<IActionResult> Create(CreateMembershipDto dto)
    {
        var member = await _context.Members.FindAsync(dto.MemberId);
        var plan = await _context.MembershipPlans.FindAsync(dto.MembershipPlanId);

        if (member == null || plan == null)
            return BadRequest("Invalid member or plan");

        var membership = new Membership
        {
            MemberId = member.Id,
            MembershipPlanId = plan.Id,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(plan.DurationInDays)
        };

        _context.Memberships.Add(membership);
        await _context.SaveChangesAsync();

        return Ok(membership);
    }

    // =========================
    // GET ALL MEMBERSHIPS
    // =========================
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var memberships = await _context.Memberships
            .Include(m => m.Member)
            .Include(m => m.MembershipPlan)
            .ToListAsync();

        return Ok(memberships);
    }

    // =========================
    // GET ACTIVE MEMBERSHIPS
    // =========================
    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var now = DateTime.UtcNow;

        var active = await _context.Memberships
            .Include(m => m.Member)
            .Include(m => m.MembershipPlan)
            .Where(m => m.EndDate > now)
            .ToListAsync();

        return Ok(active);
    }

    // =========================
    // CHECK IF MEMBER IS ACTIVE
    // =========================
    [HttpGet("check/{memberId}")]
    public async Task<IActionResult> Check(int memberId)
    {
        var now = DateTime.UtcNow;

        var active = await _context.Memberships
            .AnyAsync(m => m.MemberId == memberId && m.EndDate > now);

        return Ok(new
        {
            memberId,
            isActive = active
        });
    }
}