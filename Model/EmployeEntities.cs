using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Model
{
     public class EmployeEntities
    {
        public int EmployeEntitiesId { get; set; }

        public string? EmpName { get; set; }
        
        public double Salaree { get; set; }

        public string? Deparement { get; set; }

        public double Packege { get; set; }


    }
}
