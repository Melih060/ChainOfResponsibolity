using ChainOfResponsibolity.Models;
using ChainOfResponsibolity.DAL;

namespace ChainOfResponsibolity.ChainOfRespPatern
{
    public class Manager : Employee
    {
        private readonly Context _context;
        public Manager(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 250000)
            {
                CustomerProcesses customerProcesses = new CustomerProcesses();
                customerProcesses.Name = customerViewModel.Name;
                customerProcesses.Amount = customerViewModel.Amount;
                customerProcesses.EmployeeName = "Murat Yücedağ";
                customerProcesses.Description = "Talep Edilen Tutar Şube Müdürü Tarafından Ödendi";
                _context.CustumerProcesses.Add(customerProcesses);
                _context.SaveChanges();
            }
            else if(NextApprover != null)
            {

                CustomerProcesses customerProcesses = new CustomerProcesses();
                customerProcesses.Name = customerViewModel.Name;
                customerProcesses.Amount = customerViewModel.Amount;
                customerProcesses.EmployeeName = "Murat Yücedağ";
                customerProcesses.Description = "Talep Edilen Tutar Şube Müdürü Taranfından Ödenemedi,İşlem Bölge Müdürüne Aktarıldı";
                _context.CustumerProcesses.Add(customerProcesses);
                _context.SaveChanges();
                NextApprover.ProcessRequest(customerViewModel);
            }
        }
    }
}



