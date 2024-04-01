using MediatR;
using Multishop.Order.Application.Features.CQRS.Results.AddresResults;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery:IRequest<GetOrderingByIdQueryResult> // sadece id göre döner    GetAddresByIdQueryResult
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
