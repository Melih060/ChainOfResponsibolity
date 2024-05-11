using ChainOfResponsibolity.Models;
using ChainOfResponsibolity.DAL;


namespace ChainOfResponsibolity.ChainOfRespPatern
{
    public class Treasurer : Employee
    {
        private readonly Context _context;
        public Treasurer(Context context)
        {
            _context = context;
        }
        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 80000)
            {
                CustomerProcesses customerProcess = new CustomerProcesses();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Emin Yılmaz";
                customerProcess.Description = "Talep Edilen Tutar Veznedar Tarafından Ödendi";
                _context.CustumerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcesses customerProcess = new CustomerProcesses();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Emin Yılmaz";
                customerProcess.Description = "Talep Edilen Tutar Veznedar Tarafından Ödenemedi, İşlem Şube Müdür Yardımcısına Aktarıldı";
                _context.CustumerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(customerViewModel);
            }
        }

       
    }
}