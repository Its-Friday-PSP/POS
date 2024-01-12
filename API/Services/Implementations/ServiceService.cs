using API.DTOs.Request;
using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Stripe;

namespace API.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ITaxRepository _taxRepository;

        public ServiceService(IServiceRepository serviceRepository, ITaxRepository taxRepository)
        {
            _serviceRepository = serviceRepository;
            _taxRepository = taxRepository;
        }

        public Service CreateService(Service service, IEnumerable<Guid> taxes)
        {
            var createdService = _serviceRepository.CreateService(service);
            var selectedTaxes = _taxRepository.GetTaxes(taxes);

            createdService.Taxes = selectedTaxes.Select(x => new ServiceTaxItem() { TaxId = x.Id, ServiceId = service.Id }).ToList();

            var offerOptions = new ProductCreateOptions
            {
                Name = createdService.Name,
                Description = createdService.Description,
            };

            var productService = new Stripe.ProductService();
            var stripeProduct = productService.Create(offerOptions);

            createdService.StripeId = stripeProduct.Id;

            _serviceRepository.UpdateService(createdService.Id, createdService);

            return createdService;
        }

        public bool DeleteService(Guid serviceId)
        {
            return _serviceRepository.DeleteService(serviceId);
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _serviceRepository.GetAllServices();
        }
        public Service GetService(Guid serviceId)
        {
            return _serviceRepository.GetService(serviceId);
        }

        public Service UpdateService(Guid serviceId, Service service)
        {
            return _serviceRepository.UpdateService(serviceId, service);
        }
    }
}
