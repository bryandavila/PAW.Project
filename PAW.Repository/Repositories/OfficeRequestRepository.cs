using System;
using System.Text;
using System.Threading.Tasks;
using PAW.Data.Models;
using System.Collections.Generic;
using System.Linq;
using PAW.Repository.Interfaces;

namespace PAW.Repository.Repositories
{
    public class OfficeRequestRepository : RepositoryBase<OfficeRequest>, IOfficeRequestRepository
    {
        public OfficeRequestRepository(CaseDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<OfficeRequest> GetRequestsByStatus(string status)
        {
            return this.RepositoryContext.OfficeRequests
                .Where(r => r.Status == status)
                .ToList();
        }
    }
}