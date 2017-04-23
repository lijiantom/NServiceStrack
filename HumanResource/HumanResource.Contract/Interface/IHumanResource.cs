
namespace HumanResource.Contract.Interface
{
    public interface IHumanResource
    {
        GetDoctorResponse Any(GetDoctorDetailRequest request);

        GetDoctorsResponse Any(GetDoctorsDetailRequest request);

    }
}
