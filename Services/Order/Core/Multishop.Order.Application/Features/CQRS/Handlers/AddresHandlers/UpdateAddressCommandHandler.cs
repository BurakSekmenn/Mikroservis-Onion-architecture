using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multishop.Order.Application.Features.CQRS.Commands.AddresCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddresHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand request)
        {
            var values = await _repository.GetByIdAsync(request.AddresId);
            values.Detail = request.Detail;
            values.City = request.City;
            values.District = request.District;
            values.UserId = request.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
