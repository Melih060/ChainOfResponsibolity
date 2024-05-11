using ChainOfResponsibolity.Models;
using ChainOfResponsibolity.DAL;

namespace ChainOfResponsibolity.ChainOfRespPatern
{
    public class AreaDirector : Employee
    {
        private readonly Context _context;
        public AreaDirector(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 360000)
            {
                CustomerProcesses customerProcesses = new CustomerProcesses();
                customerProcesses.Name = customerViewModel.Name;
                customerProcesses.Amount = customerViewModel.Amount;
                customerProcesses.EmployeeName = "Melih Zengin";
                customerProcesses.Description = "Talep Edilen Tutar Bölge Müdürü Tarafından Ödendi";
                _context.CustumerProcesses.Add(customerProcesses);
                _context.SaveChanges();
            }
            else
            {

                CustomerProcesses customerProcesses = new CustomerProcesses();
                customerProcesses.Name = customerViewModel.Name;
                customerProcesses.Amount = customerViewModel.Amount;
                customerProcesses.EmployeeName = "Melih Zengin";
                customerProcesses.Description = "Talep Edilen Tutar Bölge Müdürü Taranfından Ödenemedi,İşlem Gerçekleştirilemedi";
                _context.CustumerProcesses.Add(customerProcesses);
                _context.SaveChanges();
            }
        }
    }
}
