using PAW.Data.Models;
using PAW.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Repository.Repositories
{
    public class OfficeRequestDetailsRepository : RepositoryBase<OfficeRequestDetail>, IOfficeRequestDetailsRepository
    {
        public OfficeRequestDetailsRepository(CaseDbContext context) : base(context)
        {
        }
    }
}
