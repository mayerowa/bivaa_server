using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bivaa_server_main.Core
{
    public interface ITaxRateService
    {
        List<tax_rate> GetAllTaxRates();
        tax_rate GetTaxRateById(int id);
        tax_rate CreateTaxRate(tax_rate taxRate);
        tax_rate UpdateTaxRate(int id, tax_rate taxRate);
        void DeleteTaxRate(int id);
    }
}
