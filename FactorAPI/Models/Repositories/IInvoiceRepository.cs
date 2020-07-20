using FactorAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorAPI.Models.Repositories
{
    public interface IInvoiceRepository
    {
        public Task<IEnumerable<Invoice>> GetInvoices();
        public Task<Invoice> GetInvoice(long id);
        public Task<bool> UpdateInvoice(long id, Invoice invoice);
        public Task<bool> DeleteInvoice(Invoice invoice);
        public bool InvoiceExists(long id);
        public Task<bool> AddInvoice(Invoice invoice);
    }
}
