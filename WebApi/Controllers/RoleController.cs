using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Helpers;
using WebApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rols
        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles()
        {
            var array = _context.Role.ToArray();
            List<Role> rols = new List<Role>();
            foreach (var rol in array)
            {
                if (rol.state != false)
                {
                    rols.Add(rol);
                }
            }
            return rols;
        }
        //GET:      api/rols/n
        [HttpGet("{id}")]
        public ActionResult<Role> GetRoleItem(int id)
        {
            var rolItem = _context.Role.Find(id);

            if (rolItem == null)
            {
                return NotFound();
            }
            return rolItem;
        }
        //POST:     api/rols
        [HttpPost]
        public ActionResult<Role> PostRoleItem(Role rol)
        {
            _context.Role.Add(rol);
            _context.SaveChanges();
            return Ok(rol);
        }

        //PUT:      api/rols/n
        [HttpPut("{id}")]
        public ActionResult<Role> PutRoleItem(int id, Role rol)
        {
            if (id != rol.idRole)
            {
                return BadRequest();
            }
            _context.Entry(rol).State = EntityState.Modified;
            _context.SaveChanges();
            var rolItem = _context.Role.Find(id);
            return rolItem;
        }

        //DELETE:   api/rols/n
        [HttpDelete("{id}")]
        public ActionResult<Role> DeleteRoleItem(int id)
        {
            var rolItem = _context.Role.Find(id);

            if (rolItem == null)
            {
                return NotFound();
            }
            rolItem.state = false;
            _context.SaveChanges();
            return rolItem;
        }
    }
}