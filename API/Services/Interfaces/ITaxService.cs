using API.Model;

namespace API.Services.Interfaces
{
    public interface ITaxService
    {
        public Tax CreateTax(Tax tax);
        public Tax UpdateTax(Guid taxId, Tax tax);
        public bool DeleteTax(Guid taxId);
        public Tax GetTax(Guid taxId);
        public IEnumerable<Tax> GetTaxes(IEnumerable<Guid> taxIds);
        public IEnumerable<Tax> GetAllTaxes();
    }
}
