using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Contract
{
    public class DoctorDetail
    {
        public long DoctorId { get; set; }

        public string DoctorName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }
    }
}
