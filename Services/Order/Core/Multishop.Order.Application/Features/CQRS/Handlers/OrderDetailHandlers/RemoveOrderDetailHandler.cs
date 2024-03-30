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
    public class RemoveOrderDetailHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveOrderDetailHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }


        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            await _repository.DeleteAsync(values);
        }
    }
}
