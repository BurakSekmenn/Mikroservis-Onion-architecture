using Multishop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Multishop.Order.Application.Features.CQRS.Results.AddresResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multishop.Order.Application.Features.CQRS.Queries.OrderDetailQueriess;
using Multishop.Order.Application.Features.CQRS.Results.OrderDetailResults;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }


        public async Task<GetOrderDetailQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailQueryResult
            {
              OrderDetailId = values.OrderDetailId,
              ProductAmount = values.ProductAmount,
              ProductId = values.ProductId,
              ProductName = values.ProductName,
              OrderingID = values.OrderingID,
              ProductPrice = values.ProductPrice,
              TotalPrice = values.TotalPrice
            };
        }
    }
}
