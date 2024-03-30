﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Commands.AddresCommands
{
    public class RemoveAddressCommand
    {
        public RemoveAddressCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
