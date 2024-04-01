using Multishop.Order.Application.Features.CQRS.Commands.AddresCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multishop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }


        public async Task Handle(UpdateOrderDetailCommand request)
        {
            var values = await _repository.GetByIdAsync(request.OrderDetailId);
            values.OrderingID = request.OrderingID;
            values.ProductId = request.ProductId;
            values.ProductPrice = request.ProductPrice;
            values.ProductAmount = request.ProductAmount;
            values.ProductName = request.ProductName;
            values.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(values);
        }
    }
}
