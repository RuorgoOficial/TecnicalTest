using AutoFixture;
using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.DTOs;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Test.Integration.Mocks
{
    public class ShowHttpRepositoryMock : IHttpRepository<ShowDTO>
    {
        private readonly Fixture _fixture;
        public ShowHttpRepositoryMock() { _fixture = new Fixture(); }

        public Task<Option<ShowDTO>> GetAsync(int id)
        {
            ShowDTO? show = id != 100 ? _fixture.Build<ShowDTO>()
                .With(s => s.id, id)
                .Create() : null;

            return Task.FromResult<Option<ShowDTO>>(show);
        }
    }
}
