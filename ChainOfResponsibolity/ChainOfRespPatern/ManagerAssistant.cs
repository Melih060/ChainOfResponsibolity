using ChainOfResponsibolity.Models;
using ChainOfResponsibolity.DAL;

namespace ChainOfResponsibolity.ChainOfRespPatern
{
    public class ManagerAssistant : Employee
    {
        private readonly Context _context;
        public ManagerAssistant(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 150000)
            {
                CustomerProcesses customerProcesses = new CustomerProcesses();
                customerProcesses.Name = customerViewModel.Name;
                customerProcesses.Amount = customerViewModel.Amount;
                customerProcesses.EmployeeName = "Emre Keskiner";
                customerProcesses.Description = "Talep Edilen Tutar Şube Müdür Yardımcısı Tarafından Ödendi";
                _context.CustumerProcesses.Add(customerProcesses);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {

                CustomerProcesses customerProcesses = new CustomerProcesses();
                customerProcesses.Name = customerViewModel.Name;
                customerProcesses.Amount = customerViewModel.Amount;
                customerProcesses.EmployeeName = "Emre Keskiner";
                customerProcesses.Description = "Talep Edilen Tutar Şube Müdür Yardımcısı Tarafından Ödenemedi,Şube Müdürüne Aktarıldı";
                _context.CustumerProcesses.Add(customerProcesses);
                _context.SaveChanges();
                NextApprover.ProcessRequest(customerViewModel);
            }
        }

      
    }
}
