using ChainOfResponsibolity.Models;
using ChainOfResponsibolity.Models;

namespace ChainOfResponsibolity.ChainOfRespPatern
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee employee)
        {
            this.NextApprover = employee;
        }
        public abstract void ProcessRequest(CustomerViewModel customerViewModel);
    }
   
}
