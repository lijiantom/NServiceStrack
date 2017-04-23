using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Contract
{
    public class GetDoctorsResponse : ResponseStatusType
    {
        public List<DoctorDetail> DoctorDetails { get; set; }
    }
}
