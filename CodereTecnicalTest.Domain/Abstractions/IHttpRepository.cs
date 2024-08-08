using CodereTecnicalTest.Domain.DTOs;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Abstractions
{
    public interface IHttpRepository<T> where T : BaseDTO
    {
        Task<Option<T>> GetAsync(int id);
    }
}
