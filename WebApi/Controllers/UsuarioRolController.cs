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
    public class UsuarioRolController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioRolController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rols
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioRol>> GetUsuarioRol()
        {
            var array = _context.UsuarioRol.ToArray();
            List<UsuarioRol> usuarioRols = new List<UsuarioRol>();
            foreach (var usuarioRol in array)
            {
                if (usuarioRol.estado != false)
                {
                    usuarioRols.Add(usuarioRol);
                }
            }
            return usuarioRols;
        }
        //GET:      api/rols/n
        [HttpGet("{id}")]
        public ActionResult<UsuarioRol> GetUsuarioRolItem(int id)
        {
            var usuarioRolItem = _context.UsuarioRol.Find(id);

            if (usuarioRolItem == null)
            {
                return NotFound();
            }
            return usuarioRolItem;
        }
        //POST:     api/rols
        [HttpPost]
        public ActionResult<UsuarioRol> PostUsuarioRolItem(UsuarioRol usuarioRol)
        {
            _context.UsuarioRol.Add(usuarioRol);
            _context.SaveChanges();
            return Ok(usuarioRol);
        }

        //PUT:      api/rols/n
        [HttpPut("{id}")]
        public ActionResult<UsuarioRol> PutUsuarioRolItem(int id, UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.IdUsuarioRol)
            {
                return BadRequest();
            }
            _context.Entry(usuarioRol).State = EntityState.Modified;
            _context.SaveChanges();
            var usuarioRolItem = _context.UsuarioRol.Find(id);
            return usuarioRolItem;
        }

        //DELETE:   api/rols/n
        [HttpDelete("{id}")]
        public ActionResult<UsuarioRol> DeleteUsuarioRolItem(int id)
        {
            var usuarioRolItem = _context.UsuarioRol.Find(id);

            if (usuarioRolItem == null)
            {
                return NotFound();
            }
            usuarioRolItem.estado = false;
            _context.SaveChanges();
            return usuarioRolItem;
        }
    }
}