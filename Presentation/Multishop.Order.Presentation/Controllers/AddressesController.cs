using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.CQRS.Commands.AddresCommands;
using Multishop.Order.Application.Features.CQRS.Handlers.AddresHandlers;
using Multishop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace Multishop.Order.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _addressQueryHandler;
        private readonly GetAddressByIdQueryHandler _addressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly RemoveAddressComandHandler _removeAddressCommandHandler;
        private readonly UpdateAddressComandHandler _updateAddressCommandHandler;
        public AddressesController(GetAddressQueryHandler addressQueryHandler, GetAddressByIdQueryHandler addressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, RemoveAddressCommand removeAddressCommand, UpdateAddressComandHandler updateAddressCommandHandler, RemoveAddressComandHandler removeAddressCommand1)
        {
            _addressQueryHandler = addressQueryHandler;
            _addressByIdQueryHandler = addressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
        
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommand1;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressById()
        {
            var values = await _addressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var values = await _addressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres Bilgisi başarıyla silindi");
        }

    }
}
