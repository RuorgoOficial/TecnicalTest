using CodereTecnicalTest.Domain.DTOs;
using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Application.Events.Queries
{
    public class ManageShowById(int id) : IRequest<Result<int>>
    {
        public int Id { get; set; } = id;
    }
}
