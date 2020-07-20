using FactorAPI.Models.Entities;
using FactorAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FactorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
        public async Task<IActionResult> GetInvoice(long id)
        {
            var invoice = await _repository.GetInvoice(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        // PUT: api/Invoices/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(long id, Invoice invoice)
        {
            if (id != invoice.InvoiceID || !_repository.InvoiceExists(id))
            {
                return BadRequest();
            }
            if (await _repository.UpdateInvoice(invoice))
                return Ok();
            else
                return StatusCode(500);
        }

        // POST: api/Invoices

        [HttpPost]
        public async Task<IActionResult> PostInvoice(Invoice invoice)
        {

            if (await _repository.AddInvoice(invoice))
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
        public async Task<IActionResult> DeleteInvoice(long id)
        {
            var invoice = await _repository.GetInvoice(id);

            if (invoice == null)
            {
                return BadRequest();
            }
            if (await _repository.DeleteInvoice(invoice))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }

        }


    }
}
