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
    public class RolPaginaController : ControllerBase
    {
        private readonly DataContext _context;

        public RolPaginaController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rolPaginas
        [HttpGet]
        public ActionResult<IEnumerable<RolPagina>> GetRolPaginas()
        {
            var array = _context.RolPagina.ToArray();
            List<RolPagina> rolPaginas = new List<RolPagina>();
            foreach (var rolPagina in array)
            {
                if (rolPagina.estado != false)
                {
                    rolPaginas.Add(rolPagina);
                }
            }
            return rolPaginas;
        }
        
        //GET:      api/rolPaginas/n
        [HttpGet("{id}")]
        public ActionResult<RolPagina> GetRolPaginaItem(int id)
        {
            var rolPaginaItem = _context.RolPagina.Find(id);

            if (rolPaginaItem == null) 
            {
                return NotFound();
            }

            return rolPaginaItem;
        }
        
        //POST:     api/rolPaginas
        [HttpPost]
        public ActionResult<RolPagina> PostRolPaginaItem(RolPagina rolPagina)
        {
            _context.RolPagina.Add(rolPagina);
            _context.SaveChanges();

            //return CreatedAtAction("GetRolPaginaItem", new RolPagina{IdRolPagina = rolPagina.IdRolPagina}, rolPagina);
            //return CreatedAtAction("GetRolPaginaItem", new RolPagina{IdRolPagina = rolPagina.IdRolPagina}, rolPagina);
            return Ok(rolPagina);
        }

        //PUT:      api/rolPaginas/n
        [HttpPut("{id}")]
        public ActionResult<RolPagina> PutRolPaginaItem(int id, RolPagina rolPagina)
        {
            if (id != rolPagina.IdRolPagina)
            {
                return BadRequest();
            }

            _context.Entry(rolPagina).State = EntityState.Modified;
            _context.SaveChanges();
            var rolPaginaItem = _context.RolPagina.Find(id);
            return rolPaginaItem;
        }

        //DELETE:   api/rolPaginas/n
        [HttpDelete("{id}")]
        public ActionResult<RolPagina> DeleteRolPaginaItem(int id)
        {
            var rolPaginaItem = _context.RolPagina.Find(id);

            if (rolPaginaItem == null)
            {
                return NotFound();
            }
            rolPaginaItem.estado = false;
            //_context.RolPagina.Remove(rolPaginaItem);
            _context.SaveChanges();

            return rolPaginaItem;
        }
    }
}