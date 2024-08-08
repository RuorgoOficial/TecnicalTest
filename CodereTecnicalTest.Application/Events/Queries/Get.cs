using CodereTecnicalTest.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Application.Events.Queries
{
    public class Get<T> : IRequest<IEnumerable<T>>
        where T : BaseDTO
    {
    }
}
