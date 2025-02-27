using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Model;
using System.Collections.Generic;

namespace PAW.Repository.Interfaces
{
    public interface IOfficeRequestRepository : IRepositoryBase<OfficeRequest>
    {
        IEnumerable<OfficeRequest> GetRequestsByStatus(string status);
    }
}
