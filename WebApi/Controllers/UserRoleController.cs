using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly DataContext _context;

        public UserRoleController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rols
        [HttpGet]
        public ActionResult<IEnumerable<UserRole>> GetUserRole()
        {
            var array = _context.UserRole.ToArray();
            List<UserRole> userRoles = new List<UserRole>();
            foreach (var UserRole in array)
            {
                if (UserRole.state != false)
                {
                    userRoles.Add(UserRole);
                }
            }
            return userRoles;
        }
        //GET:      api/rols/n
        [HttpGet("{id}")]
        public ActionResult<UserRole> GetUserRoleItem(int id)
        {
            var userRoleItem = _context.UserRole.Find(id);

            if (userRoleItem == null)
            {
                return NotFound();
            }
            return userRoleItem;
        }
        //POST:     api/rols
        [HttpPost]
        public ActionResult<UserRole> PostUserRoleItem(UserRole UserRole)
        {
            _context.UserRole.Add(UserRole);
            _context.SaveChanges();
            return Ok(UserRole);
        }

        //PUT:      api/rols/n
        [HttpPut("{id}")]
        public ActionResult<UserRole> PutUserRoleItem(int id, UserRole UserRole)
        {
            if (id != UserRole.idUserRole)
            {
                return BadRequest();
            }
            _context.Entry(UserRole).State = EntityState.Modified;
            _context.SaveChanges();
            var userRoleItem = _context.UserRole.Find(id);
            return userRoleItem;
        }

        //DELETE:   api/rols/n
        [HttpDelete("{id}")]
        public ActionResult<UserRole> DeleteUserRoleItem(int id)
        {
            var userRoleItem = _context.UserRole.Find(id);

            if (userRoleItem == null)
            {
                return NotFound();
            }
            userRoleItem.state = false;
            _context.SaveChanges();
            return userRoleItem;
        }
    }
}