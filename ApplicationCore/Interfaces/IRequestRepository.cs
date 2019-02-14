using ExperianTest.ApplicationCore.Entities;
using System;
using System.Threading.Tasks;

namespace ExperianTest.ApplicationCore.Interfaces
{
    public interface IRequestRepository
    {
        Task<Request> GetRequestByGuidAsync(Guid guid);
    }
}
