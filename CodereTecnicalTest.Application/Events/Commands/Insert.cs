using CodereTecnicalTest.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Application.Events.Commands
{
    public class Insert<T> : IRequest<T>
        where T : BaseDTO
    {
        public T Entity { get; set; }
        public Insert(T entity) 
        { 
            Entity = entity;
        }
    }
}
