using FactorAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorAPI.Models.Repositories
{
    public class InvoceRepository : IInvoiceRepository

    {
        private readonly FactorDBContext _context;

        public InvoceRepository(FactorDBContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteInvoice(Invoice invoice)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    _context.Invoices.Remove(invoice);
                    _context.InvoiceItems.RemoveRange(_context.InvoiceItems.Where(p => p.InvoiceID == invoice.InvoiceID));
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (System.Exception)
                {

                    transaction.Rollback();
                    return false;
                }

            }

            return true;
        }

        public async Task<Invoice> GetInvoice(long id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _context.Invoices.Include(p => p.InvoiceItems).ToListAsync();

        }

        public async Task<bool> UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InvoiceExists(long id)
        {
            return _context.Invoices.Any(e => e.InvoiceID == id);
        }
        public async Task<bool> AddInvoice(Invoice invoice)
        {
            var res = 0;
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    _context.Invoices.Add(invoice);
                    await _context.SaveChangesAsync();
                    foreach (var item in invoice.InvoiceItems)
                    {
                        item.InvoiceID = invoice.InvoiceID;
                    }
                    _context.InvoiceItems.AddRange(invoice.InvoiceItems.ToArray());
                    res = await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (System.Exception)
                {

                    transaction.Rollback();
                }

            }
            if (res > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
