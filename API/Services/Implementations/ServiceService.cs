using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Stripe;

namespace API.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Service CreateService(Service service)
        {
            var createdService = _serviceRepository.CreateService(service);

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
