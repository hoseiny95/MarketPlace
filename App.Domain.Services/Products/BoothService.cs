using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class BoothService : IBoothService
    {
        public Task Create(BoothDto booth, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int boothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(BoothDto booth, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
