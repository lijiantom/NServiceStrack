using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace HumanResource.Contract
{
    public class HumanResourceClient
    {
        #region 单例
        private static readonly HumanResourceClient Instance = new HumanResourceClient();

        private HumanResourceClient()
        {
        }

        public static HumanResourceClient GetInstance()
        {
            return Instance;
        }
        #endregion

        readonly JsonServiceClient _client = new JsonServiceClient("http://localhost/HumanResource.Host/");

        public GetDoctorResponse GetDoctorDetail(GetDoctorDetailRequest request)
        {
            return _client.Get<GetDoctorResponse>(request);
        }

        public GetDoctorsResponse GetDoctorsDetail(GetDoctorsDetailRequest request)
        {
            return _client.Get<GetDoctorsResponse>(request);
        }
    }
}
