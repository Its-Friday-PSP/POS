using API.Model;
using API.Repositories;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class TaxService : ITaxService
    {
        private readonly Context _context;
        public TaxService(Context context)
        {
            _context = context;
        }

        public Tax CreateTax(Tax tax)
        {
            _context.Taxes.Add(tax);
            _context.SaveChanges();

            return tax;
        }

        public bool DeleteTax(Guid taxId)
        {
            var tax = _context.Taxes.Find(taxId);

            if (tax == null)
            {
                return false;
            }

            _context.Taxes.Remove(tax);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Tax> GetAllTaxes()
        {
            return _context.Taxes;
        }

        public Tax GetTax(Guid taxId)
        {
            return _context.Taxes.Find(taxId);
        }

        public IEnumerable<Tax> GetTaxes(IEnumerable<Guid> taxIds)
        {
            return _context.Taxes.Where(x => taxIds.Contains(x.Id));
        }

        public Tax UpdateTax(Guid taxId, Tax tax)
        {
            var existingTax = _context.Taxes.Find(taxId);

            if (existingTax == null)
            {
                return null;
            }

            existingTax = tax;
            _context.SaveChanges();

            return tax;
        }
    }
}
