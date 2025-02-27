using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Model;
using PAW.Repository.Interfaces;
using System.Collections.Generic;

namespace PAW.Business
{
    public class OfficeRequestBusiness
    {
        private readonly IOfficeRequestRepository _officeRequestRepository;
        private readonly IOfficeRequestDetailsRepository _officeRequestDetailsRepository;

        public OfficeRequestBusiness(IOfficeRequestRepository officeRequestRepository, IOfficeRequestDetailsRepository officeRequestDetailsRepository)
        {
            _officeRequestRepository = officeRequestRepository;
            _officeRequestDetailsRepository = officeRequestDetailsRepository;
        }

        public IEnumerable<OfficeRequest> GetRequestsByStatus(string status)
        {
            return _officeRequestRepository.GetRequestsByStatus(status);
        }

        public void CompleteRequest(int requestId, OfficeRequestDetails details)
        {
            var request = _officeRequestRepository.FindByCondition(r => r.Id == requestId).FirstOrDefault();
            if (request != null && request.Status != "Completed")
            {
                request.Status = "Completed";
                _officeRequestRepository.Update(request);
                _officeRequestDetailsRepository.Create(details);
                _officeRequestRepository.Save();
            }
        }
    }
}
