using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Contract
{
    public class ActResult
    {
        public bool IsSuccess { get; set; }

        public int ErrrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
