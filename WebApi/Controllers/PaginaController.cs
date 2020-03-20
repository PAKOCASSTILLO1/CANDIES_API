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
    public class PaginaController : ControllerBase
    {
        private readonly DataContext _context;

        public PaginaController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rols
        [HttpGet]
        public ActionResult<IEnumerable<Pagina>> GetPaginas()
        {
            var array = _context.Pagina.ToArray();
            List<Pagina> paginas = new List<Pagina>();
            foreach (var pagina in array)
            {
                if (pagina.estado != false)
                {
                    paginas.Add(pagina);
                }
            }
            return paginas;
        }
        //GET:      api/rols/n
        [HttpGet("{id}")]
        public ActionResult<Pagina> GetPaginaItem(int id)
        {
            var paginaItem = _context.Pagina.Find(id);

            if (paginaItem == null)
            {
                return NotFound();
            }
            return paginaItem;
        }
        //POST:     api/rols
        [HttpPost]
        public ActionResult<Pagina> PostPaginaItem(Pagina pagina)
        {
            _context.Pagina.Add(pagina);
            _context.SaveChanges();
            return Ok(pagina);
        }

        //PUT:      api/rols/n
        [HttpPut("{id}")]
        public ActionResult<Pagina> PutPaginaItem(int id, Pagina pagina)
        {
            if (id != pagina.IdPagina)
            {
                return BadRequest();
            }
            _context.Entry(pagina).State = EntityState.Modified;
            _context.SaveChanges();
            var paginaItem = _context.Pagina.Find(id);
            return paginaItem;
        }

        //DELETE:   api/rols/n
        [HttpDelete("{id}")]
        public ActionResult<Pagina> DeletePaginaItem(int id)
        {
            var paginaItem = _context.Pagina.Find(id);

            if (paginaItem == null)
            {
                return NotFound();
            }
            paginaItem.estado = false;
            _context.SaveChanges();
            return paginaItem;
        }
    }
}