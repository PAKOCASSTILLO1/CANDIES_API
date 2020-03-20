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
    public class RolController : ControllerBase
    {
        private readonly DataContext _context;

        public RolController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rols
        [HttpGet]
        public ActionResult<IEnumerable<Rol>> GetRols()
        {
            var array = _context.Rol.ToArray();
            List<Rol> rols = new List<Rol>();
            foreach (var rol in array)
            {
                if (rol.estado != false)
                {
                    rols.Add(rol);
                }
            }
            return rols;
        }
        //GET:      api/rols/n
        [HttpGet("{id}")]
        public ActionResult<Rol> GetRolItem(int id)
        {
            var rolItem = _context.Rol.Find(id);

            if (rolItem == null)
            {
                return NotFound();
            }
            return rolItem;
        }
        //POST:     api/rols
        [HttpPost]
        public ActionResult<Rol> PostRolItem(Rol rol)
        {
            _context.Rol.Add(rol);
            _context.SaveChanges();
            return Ok(rol);
        }

        //PUT:      api/rols/n
        [HttpPut("{id}")]
        public ActionResult<Rol> PutRolItem(int id, Rol rol)
        {
            if (id != rol.IdRol)
            {
                return BadRequest();
            }
            _context.Entry(rol).State = EntityState.Modified;
            _context.SaveChanges();
            var rolItem = _context.Rol.Find(id);
            return rolItem;
        }

        //DELETE:   api/rols/n
        [HttpDelete("{id}")]
        public ActionResult<Rol> DeleteRolItem(int id)
        {
            var rolItem = _context.Rol.Find(id);

            if (rolItem == null)
            {
                return NotFound();
            }
            rolItem.estado = false;
            _context.SaveChanges();
            return rolItem;
        }
    }
}