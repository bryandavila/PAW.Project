using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Model;
using PAW.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
