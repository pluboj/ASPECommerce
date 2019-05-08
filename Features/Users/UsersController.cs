using System.Threading.Tasks;
using ASP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Features.Users
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly Context _db;
    
        public UsersController(Context db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _db.Users.ToListAsync());
        }
    }
}