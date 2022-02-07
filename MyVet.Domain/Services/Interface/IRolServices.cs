using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Services.Interface
{
    public interface IRolServices
    {
        List<RolEntity> GetAll();
    }
}
