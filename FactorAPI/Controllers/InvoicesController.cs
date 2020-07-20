using FactorAPI.Models.Entities;
using FactorAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FactorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly FactorDBContext _context;
        private readonly IInvoiceRepository _repository;

        public InvoicesController(FactorDBContext context, IInvoiceRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var list = await _repository.GetInvoices();
            if (list.Count() > 0)
            {
                return Ok(list);

            }
            else
            {
                return NotFound();
            }

        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(long id)
        {
            var invoice = _repository.GetInvoice(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(long id, Invoice invoice)
        {
            if (id != invoice.InvoiceID)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Invoices

        [HttpPost]
        public async Task<IActionResult> PostInvoice(Invoice invoice)
        {


            if (res > 0)
            {
                return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceID }, invoice);

            }
            else
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(long id)
        {


            return invoice;
        }


    }
}
