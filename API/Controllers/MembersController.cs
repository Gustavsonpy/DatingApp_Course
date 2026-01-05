using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MembersController(AppDbContext context) : BaseApiController
    {
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers(){
            var users = await context.Users.ToListAsync();

            return users;
        }

        [HttpGet("/members/{Id}")]
        public async Task<ActionResult<AppUser>> GetMemberById(string Id)
        {
            var user = await context.Users.FindAsync(Id);

            if (user == null) return NotFound();

            return user;
        }
    }   
}
