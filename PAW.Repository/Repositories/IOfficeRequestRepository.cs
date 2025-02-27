using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Data.Models;
using System.Collections.Generic;
using PAW.Repository.Interfaces;

namespace PAW.Repository.Repositories
{
    public interface IOfficeRequestRepository : IRepositoryBase<OfficeRequest>
    {
        IEnumerable<OfficeRequest> GetRequestsByStatus(string status);
    }
}
