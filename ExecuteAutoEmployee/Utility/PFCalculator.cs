using ExecuteAutoEmployee.Models;
using System.Linq;

namespace ExecuteAutoEmployee.Utility
{
    public class PFCalculator
    {

        //Get the database
        EmployeeDb _employeeDb = new EmployeeDb();


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

        public bool IsPfEligible(int empId)
        {
            double? salary;
            salary = _employeeDb.Employee.Where(x => x.Id == empId).Select(x => x.Salary).FirstOrDefault();

            if (salary >= 4000)
                return true;
            else
                return false;
        }
    }
}