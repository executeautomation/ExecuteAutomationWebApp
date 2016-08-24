using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PFServiceClient
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PFService : IPFService
    {

        public double? GetPfEmployeeContribSofar(Employee employee)
        {
            double? salary;
            int? totalDuration;

            salary = employee.Salary;

            totalDuration = employee.DurationWorked;

            //Salary * 18% of basic (considering basic as 30% of salary)

            //Basic salary
            var basic = (salary * 30) / 100;

            //12% of basic
            var contribution = (basic * 18) / 100;

            return (contribution * totalDuration);


        }

        public double? GetPfEmployerContribSofar(Employee employee)
        {
            double? salary;
            int? totalDuration;

            salary = employee.Salary;

            totalDuration = employee.DurationWorked;
            //Salary * 12% of basic (considering basic as 30% of salary)

            //Basic salary
            var basic = (salary * 30) / 100;

            //12% of basic
            var contribution = (basic * 12) / 100;

            return (contribution * totalDuration);
        }
        public bool IsPfEligible(Employee employee)
        {
            double? salary;
            salary = employee.Salary;

            if (salary >= 4000)
                return true;
            else
                return false;
        }

        public double? GetPfEmployeeControlSofarWithId(int empId)
        {
            double? salary;
            int? totalDuration;

            using (var employeeEntity = new EmployeeModel())
            {
                salary = employeeEntity.Employees.Where(x => x.Id == empId).Select(x => x.Salary).FirstOrDefault();
                totalDuration = employeeEntity.Employees.Where(x => x.Id == empId).Select(x => x.DurationWorked).FirstOrDefault();
            }

            //Salary * 18% of basic (considering basic as 30% of salary)

            //Basic salary
            var basic = (salary * 30) / 100;

            //18% of basic
            var contribution = (basic * 18) / 100;

            return (contribution * totalDuration);


        }

        public double? GetPfEmployerControlSofarWithId(int empId)
        {
            double? salary;
            int? totalDuration;
            using (var employeeEntity = new EmployeeModel())
            {
                salary = employeeEntity.Employees.Where(x => x.Id == empId).Select(x => x.Salary).FirstOrDefault();
                totalDuration = employeeEntity.Employees.Where(x => x.Id == empId).Select(x => x.DurationWorked).FirstOrDefault();
            }

            //Salary * 12% of basic (considering basic as 30% of salary)

            //Basic salary
            var basic = (salary * 30) / 100;

            //12% of basic
            var contribution = (basic * 12) / 100;

            return (contribution * totalDuration);
        }

        public bool IsPfEligibleWithId(int empId)
        {
            double? salary;
            using (var employeeEntity = new EmployeeModel())
            {
                salary = employeeEntity.Employees.Where(x => x.Id == empId).Select(x => x.Salary).FirstOrDefault();
            }

            if (salary >= 4000)
                return true;
            else
                return false;
        }


    }
}
