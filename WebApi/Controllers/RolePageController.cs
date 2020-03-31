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
    public class RolePageController : ControllerBase
    {
        private readonly DataContext _context;

        public RolePageController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rolePages
        [HttpGet]
        public ActionResult<IEnumerable<RolePage>> GetRolePages()
        {
            var array = _context.RolePage.ToArray();
            List<RolePage> rolePages = new List<RolePage>();
            foreach (var rolePage in array)
            {
                if (rolePage.state != false)
                {
                    rolePages.Add(rolePage);
                }
            }
            return rolePages;
        }
        
        //GET:      api/rolePages/n
        [HttpGet("{id}")]
        public ActionResult<RolePage> GetRolePageItem(int id)
        {
            var rolePageItem = _context.RolePage.Find(id);

            if (rolePageItem == null) 
            {
                return NotFound();
            }

            return rolePageItem;
        }
        
        //POST:     api/rolePages
        [HttpPost]
        public ActionResult<RolePage> PostRolePageItem(RolePage rolePage)
        {
            _context.RolePage.Add(rolePage);
            _context.SaveChanges();

            //return CreatedAtAction("GetRolePageItem", new RolePage{IdRolePage = rolePage.IdRolePage}, rolePage);
            //return CreatedAtAction("GetRolePageItem", new RolePage{IdRolePage = rolePage.IdRolePage}, rolePage);
            return Ok(rolePage);
        }

        //PUT:      api/rolePages/n
        [HttpPut("{id}")]
        public ActionResult<RolePage> PutRolePageItem(int id, RolePage rolePage)
        {
            if (id != rolePage.IdRolePage)
            {
                return BadRequest();
            }

            _context.Entry(rolePage).State = EntityState.Modified;
            _context.SaveChanges();
            var rolePageItem = _context.RolePage.Find(id);
            return rolePageItem;
        }

        //DELETE:   api/rolePages/n
        [HttpDelete("{id}")]
        public ActionResult<RolePage> DeleteRolePageItem(int id)
        {
            var rolePageItem = _context.RolePage.Find(id);

            if (rolePageItem == null)
            {
                return NotFound();
            }
            rolePageItem.state = false;
            //_context.RolePage.Remove(rolePageItem);
            _context.SaveChanges();

            return rolePageItem;
        }
    }
}