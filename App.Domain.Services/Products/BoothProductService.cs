using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class BoothProductService : IBoothProductService
    {
        public Task Create(BoothProductDto boothProduct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int boothProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(BoothProductDto boothProduct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
