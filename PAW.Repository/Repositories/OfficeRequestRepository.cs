using System;
using System.Text;
using System.Threading.Tasks;
using PAW.Data.Models;
using System.Collections.Generic;
using System.Linq;
using PAW.Repository.Interfaces;

namespace PAW.Repository.Repositories
{
    public class OfficeRequestDetailsRepository : RepositoryBase<OfficeRequestDetail>, IOfficeRequestDetailsRepository
    {
        public OfficeRequestDetailsRepository(CaseDBContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}