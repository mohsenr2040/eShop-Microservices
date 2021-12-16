using MediatR;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Query
{
    public class GetPaidOrdersQuery:IRequest<OrderState>
    {
        public enum _State {get };
    }
}
