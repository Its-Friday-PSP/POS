﻿using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        public Service CreateService(Service service);
        public Service GetService(Guid serviceId);
        public Service UpdateService(Guid serviceId, Service service);
        public Service DeleteService(Guid serviceId);
    }
}
