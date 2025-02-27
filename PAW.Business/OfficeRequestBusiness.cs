using PAW.Data.Models;
using PAW.Repository.Interfaces;
using PAW.Repository.Repositories;
using System.Collections.Generic;
using System.Linq;


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

        public IEnumerable<OfficeRequest> GetRequestsOrderedByPriority()
        {
            var requests = _officeRequestRepository.FindAll()
                .OrderBy(r => r.Priority == "High" ? 0 : r.Priority == "Medium" ? 1 : 2)
                .ToList();

            return requests;
        }

        public void AddDetailToRequest(OfficeRequestDetail detail)
        {
            var request = _officeRequestRepository.FindByCondition(r => r.Id == detail.RequestId).FirstOrDefault();
            if (request != null && request.Status != "Completed")
            {
                _officeRequestDetailsRepository.Create(detail);
                _officeRequestDetailsRepository.Save();
            }
            else
            {
                throw new InvalidOperationException("No se puede agregar un detalle a una solicitud completada.");
            }
        }

        public IEnumerable<OfficeRequest> GetRequestsByStatus(string status)
        {
            return _officeRequestRepository.FindByCondition(r => r.Status == status)
                                           .OrderBy(r => r.Priority == "High" ? 0 : r.Priority == "Medium" ? 1 : 2)
                                           .ToList();
        }

        public void CompleteRequest(int requestId, OfficeRequestDetail details)
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

        public void CreateRequest(OfficeRequest request)
        {
            _officeRequestRepository.Create(request);
            _officeRequestRepository.Save();
        }

        public void DeleteRequest(int requestId)
        {
            var request = _officeRequestRepository.FindByCondition(r => r.Id == requestId).FirstOrDefault();
            if (request != null)
            {
                _officeRequestRepository.Delete(request);
                _officeRequestRepository.Save();
            }
        }

    }
}