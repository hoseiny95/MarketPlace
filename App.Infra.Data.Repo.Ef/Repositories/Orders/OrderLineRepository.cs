using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Orders;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Orders;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Orders
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public OrderLineRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(OrderLineDto order, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderLine>(order);
            await _context.OrderLines.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task Delete(int orderLineId, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderLines.FindAsync(orderLineId, cancellationToken);
            _context.OrderLines.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<OrderLineDto>> GetAll(CancellationToken cancellationToken)
                       => _mapper.Map<List<OrderLineDto>>(await _context.OrderLines.ToListAsync(cancellationToken));


        public async Task<List<OrderLineDto>> GetAllByOrderId(int orderId, CancellationToken cancellationToken)
                       => _mapper.Map<List<OrderLineDto>>(await _context.OrderLines.Include(c => c.BothProduct)
                           .ThenInclude(c => c.Product).Include(c => c.BothProduct).ThenInclude(c => c.ProductImages)
                           .ThenInclude(c => c.Image).Include(c => c.BothProduct).ThenInclude(c => c.Both)
                           .Where(x=> x.OrderId==orderId).ToListAsync(cancellationToken));


        public async Task<OrderLineDto> GetById(int orderId, CancellationToken cancellationToken)
                    => _mapper.Map<OrderLineDto>(await _context.OrderLines.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken));
        
       


        public async Task<int> Update(OrderLineDto order, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderLines.FirstOrDefaultAsync(x => x.Id == order.Id, cancellationToken);
            entity.Count = order.Count;
            entity.PriceSum = order.PriceSum;
            var i = await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
