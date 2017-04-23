using HumanResource.Contract;
using HumanResource.Contract.Interface;
using HumanResource.Domain.Processes;

namespace HumanResource.Domain.Implement
{
    public class HumanResourceServiceImp : ServiceStack.Service, IHumanResource
    {
        public GetDoctorResponse Any(GetDoctorDetailRequest request)
        {
            return new GetDoctorDetail().QueryDoctorDetail(request);
        }

        public GetDoctorsResponse Any(GetDoctorsDetailRequest request)
        {
            return new GetDoctorDetail().QueryDoctorsDetail(request);
        }
    }
}
