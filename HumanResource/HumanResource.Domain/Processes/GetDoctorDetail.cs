using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Contract;

namespace HumanResource.Domain.Processes
{
    public class GetDoctorDetail
    {
        private static readonly List<DoctorDetail> DoctorDetails = new List<DoctorDetail>
        {
            new DoctorDetail
            {
                DoctorId = 1,
                DoctorName = "张三",
                Age = 25,
                Gender = "男",
            },
            new DoctorDetail
            {
                DoctorId = 2,
                DoctorName = "李四",
                Age = 33,
                Gender = "男",
            },
            new DoctorDetail
            {
                DoctorId = 4,
                DoctorName = "小红",
                Age = 54,
                Gender = "女",
            }
        };

        public GetDoctorResponse QueryDoctorDetail(GetDoctorDetailRequest request)
        {
            return new GetDoctorResponse
            {
                DoctorDetail = DoctorDetails.Find(p => p.DoctorId == request.DoctorId),
                ResponseStatus = new ActResult
                {
                    IsSuccess = true,
                    ErrorMessage = string.Empty,
                }
            };
        }

        public GetDoctorsResponse QueryDoctorsDetail(GetDoctorsDetailRequest request)
        {
            var doctorList = new List<DoctorDetail>();
            if (request?.DoctorIds != null && request.DoctorIds.Count > 0)
            {
                request.DoctorIds.ForEach(p =>
                {
                    var item = DoctorDetails.Find(q => q.DoctorId == p);
                    if (item != null) doctorList.Add(item);
                });
            }
            return new GetDoctorsResponse
            {
                DoctorDetails = doctorList,
                ResponseStatus = new ActResult
                {
                    IsSuccess = true,
                    ErrorMessage = string.Empty
                }
            };
        }
    }
}
