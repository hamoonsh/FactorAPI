using FactorAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorAPI.Models.Repositories
{
    public interface IInvoiceRepository
    {
        /// <summary>
        /// returns list of invoices
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Invoice>> GetInvoices();
        /// <summary>
        /// returns invoice by ID
        /// </summary>
        /// <param name="id">Invoice ID</param>
        /// <returns></returns>
        public Task<Invoice> GetInvoice(long id);
        /// <summary>
        /// Updates Invoice
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public Task<bool> UpdateInvoice(Invoice invoice);
        /// <summary>
        /// delete invoice
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public Task<bool> DeleteInvoice(Invoice invoice);
        /// <summary>
        /// checks existance of an invoice
        /// </summary>
        /// <param name="id">invoice id</param>
        /// <returns></returns>
        public bool InvoiceExists(long id);
        /// <summary>
        /// adds an invoice
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public Task<bool> AddInvoice(Invoice invoice);
    }
}
