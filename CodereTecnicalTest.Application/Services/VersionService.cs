using CodereTecnicalTest.Application.Extensions;
using CodereTecnicalTest.Domain.Abstractions;

namespace CodereTecnicalTest.Application.Services
{
    public class VersionService : IVersionService
    {
        public string GetVersion()
        {
            return VersionExtensions.GetInformationalVersion();
        }
    }
}
