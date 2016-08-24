using System.ServiceModel;

namespace PFServiceClient
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPFService
    {

        [OperationContract]
        bool IsPfEligible(Employee employee);

        [OperationContract]
        double? GetPfEmployeeContribSofar(Employee employee);

        [OperationContract]
        double? GetPfEmployerContribSofar(Employee employee);

        [OperationContract]
        bool IsPfEligibleWithId(int empId);

        [OperationContract]
        double? GetPfEmployerControlSofarWithId(int empId);

        [OperationContract]
        double? GetPfEmployeeControlSofarWithId(int empId);
    }


}
