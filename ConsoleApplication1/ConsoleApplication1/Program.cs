using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using HumanResource.Client;
using HumanResource.Contract;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetDoctorDetail();
            GetDoctorDetailV2();
            //GetDoctorDetailV3();
        }

        private static void GetDoctorDetail()
        {
            try
            {

                Console.WriteLine("begin GetDoctorDetail");
                var request = new GetDoctorDetailRequest
                {
                    DoctorId = 2,
                };
                var response = HumanResourceClient.GetInstance().GetDoctorDetail(request);

                var strRet = string.Empty;
                if (response?.ResponseStatus != null && response.ResponseStatus.IsSuccess)
                {
                    var serializer = new DataContractJsonSerializer(response.GetType());
                    using (var ms = new MemoryStream())
                    {
                        serializer.WriteObject(ms, response);
                        strRet = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
                Console.WriteLine(strRet);
                Console.WriteLine("end GetDoctorDetail");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void GetDoctorDetailV2()
        {
            try
            {
                Console.WriteLine("begin GetDoctorDetail");
                var request = new GetDoctorDetailRequest
                {
                    DoctorId = 2,
                };
                var response = HumanResourceClientV2.GetInstance().GetDoctorDetail(request);

                var strRet = string.Empty;
                if (response?.ResponseStatus != null && response.ResponseStatus.IsSuccess)
                {
                    var serializer = new DataContractJsonSerializer(response.GetType());
                    using (var ms = new MemoryStream())
                    {
                        serializer.WriteObject(ms, response);
                        strRet = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
                Console.WriteLine(strRet);
                Console.WriteLine("end GetDoctorDetail");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void GetDoctorDetailV3()
        {
            try
            {
                var detailRequest = new GetDoctorDetailRequest
                {
                    DoctorId = 2,
                };

                string requestContent;
                var serializer = new DataContractJsonSerializer(detailRequest.GetType());
                using (var ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, detailRequest);
                    requestContent = Encoding.UTF8.GetString(ms.ToArray());
                }

                var request = (HttpWebRequest)WebRequest.Create("http://localhost/HumanResource.Host/");
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
                    Console.WriteLine("接口调用失败");
                }

                string content;
                using (var sr = new StreamReader(response))
                {
                    content = sr.ReadToEnd();
                }
                Console.WriteLine(content);
                var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(GetDoctorResponse));
                var MS = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var result = (GetDoctorResponse)dataContractJsonSerializer.ReadObject(MS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
