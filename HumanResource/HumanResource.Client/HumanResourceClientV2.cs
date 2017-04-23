
using System.IO;
using System.Net;
using HumanResource.Contract;
using System.Runtime.Serialization.Json;
using System.Text;

namespace HumanResource.Client
{
    public class HumanResourceClientV2
    {

        #region 单例
        private static readonly HumanResourceClientV2 Instance = new HumanResourceClientV2();

        private HumanResourceClientV2()
        {
        }

        public static HumanResourceClientV2 GetInstance()
        {
            return Instance;
        }
        #endregion

        public GetDoctorResponse GetDoctorDetail(GetDoctorDetailRequest detailRequest)
        {
            string requestContent;
            var serializer = new DataContractJsonSerializer(detailRequest.GetType());
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, detailRequest);
                requestContent = Encoding.UTF8.GetString(ms.ToArray());
            }

            var request = (HttpWebRequest)WebRequest.Create("http://localhost/HumanResource.Host/json/reply/GetDoctorDetailRequest");
            request.Timeout = 15000;
            request.ReadWriteTimeout = 15000;
            request.KeepAlive = false;
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Add("Accept-Language", "zh-cn,en-us;");
            request.Headers.Add("Accept-Encoding", "utf-8");

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(requestContent);
            }
            var response = request.GetResponse().GetResponseStream();
            if (response == null)
            {
                return new GetDoctorResponse
                {
                    ResponseStatus = new ActResult
                    {
                        IsSuccess = false,
                        ErrorMessage = "接口调用失败！"
                    }
                };
            }

            string content;
            using (var sr = new StreamReader(response))
            {
                content = sr.ReadToEnd();
            }
            var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(GetDoctorResponse));
            var MS = new MemoryStream(Encoding.UTF8.GetBytes(content));
            return (GetDoctorResponse)dataContractJsonSerializer.ReadObject(MS);
        }
    }
}
