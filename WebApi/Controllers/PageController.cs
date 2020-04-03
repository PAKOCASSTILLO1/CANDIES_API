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
    public class PageController : ControllerBase
    {
        private readonly DataContext _context;

        public PageController(DataContext context)
        {
            _context = context;
        }

        //GET:      api/rols
        [HttpGet]
        public ActionResult<IEnumerable<Page>> GetPages()
        {
            var array = _context.Page.ToArray();
            List<Page> pages = new List<Page>();
            foreach (var page in array)
            {
                if (page.state != false)
                {
                    pages.Add(page);
                }
            }
            return pages;
        }
        //GET:      api/rols/n
        [HttpGet("{id}")]
        public ActionResult<Page> GetPageItem(int id)
        {
            var pageItem = _context.Page.Find(id);

            if (pageItem == null)
            {
                return NotFound();
            }
            return pageItem;
        }
        //POST:     api/rols
        [HttpPost]
        public ActionResult<Page> PostPageItem(Page page)
        {
            _context.Page.Add(page);
            _context.SaveChanges();
            return Ok(page);
        }

        //PUT:      api/rols/n
        [HttpPut("{id}")]
        public ActionResult<Page> PutPageItem(int id, Page page)
        {
            if (id != page.idPage)
            {
                return BadRequest();
            }
            _context.Entry(page).State = EntityState.Modified;
            _context.SaveChanges();
            var pageItem = _context.Page.Find(id);
            return pageItem;
        }

        //DELETE:   api/rols/n
        [HttpDelete("{id}")]
        public ActionResult<Page> DeletePageItem(int id)
        {
            var pageItem = _context.Page.Find(id);

            if (pageItem == null)
            {
                return NotFound();
            }
            pageItem.state = false;
            _context.SaveChanges();
            return pageItem;
        }
    }
}