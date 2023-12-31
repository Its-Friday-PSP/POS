﻿using API.Model;

namespace API.Services.Interfaces
{
    public interface IServiceService
    {
        public Service CreateService(Service service);
        public Service GetService(Guid serviceId);
        public Service UpdateService(Guid serviceId, Service service);
        public Service DeleteService(Guid serviceId);
    }
}
