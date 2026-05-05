using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GymManager.API.Data;
using GymManager.API.Models;
using GymManager.API.DTOs;

namespace GymManager.API.Controllers;

[ApiController]
[Route("api/members")]
[Authorize] // każdy zalogowany
public class MembersController : ControllerBase
{
    private readonly GymContext _context;

    public MembersController(GymContext context)
    {
        _context = context;
    }

    // ======================
    // CREATE MEMBER
    // ======================
    [HttpPost]
    public async Task<IActionResult> Create(MemberDto dto)
    {
        var member = new Member
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone
        };

        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return Ok(member);
    }

    // ======================
    // GET ALL
    // ======================
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members = await _context.Members.ToListAsync();
        return Ok(members);
    }

    // ======================
    // GET BY ID
    // ======================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
            return NotFound();

        return Ok(member);
    }

    // ======================
    // UPDATE
    // ======================
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MemberDto dto)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
            return NotFound();

        member.FirstName = dto.FirstName;
        member.LastName = dto.LastName;
        member.Email = dto.Email;
        member.Phone = dto.Phone;

        await _context.SaveChangesAsync();

        return Ok(member);
    }

    // ======================
    // DELETE
    // ======================
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
            return NotFound();

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}