using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperianTest.Persistence.Data
{
    public class RequestRepository : EfRepository<Request>, IRequestRepository
    {
        public RequestRepository(CardSearchDbContext context) 
                          : base(context)
        { }

        public async Task<Request> GetRequestByGuidAsync(Guid guid)
        {
            return await base._context.Requests.Where(r => r.UniqueId == guid)
                                               .FirstOrDefaultAsync();
        }
    }
}
