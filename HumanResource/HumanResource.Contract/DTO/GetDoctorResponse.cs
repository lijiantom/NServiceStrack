using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Contract
{
    public class GetDoctorResponse : ResponseStatusType
    {
        public DoctorDetail DoctorDetail { get; set; }
    }
}
