using bivaa_server_main.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bivaa_server_main.Services
{
    public class TaxRateService : ITaxRateService
    {
        public List<tax_rate> GetAllTaxRates()
        {
            using (var db = new AppDbContext())
            {
                var taxRates = (from tx in db.tax_rate select tx).ToList();
                return taxRates;
            }
        }

        public tax_rate GetTaxRateById(int id)
        {
            using (var db = new AppDbContext())
            {
                var taxRate = (from tx in db.tax_rate where tx.id == id select tx).SingleOrDefault();
                return taxRate;
            }
        }
        public tax_rate CreateTaxRate(tax_rate taxRate)
        {
            using (var db = new AppDbContext())
            {
                db.tax_rate.Add(taxRate);
                db.SaveChanges();
                return taxRate;
            }
        }

        public void DeleteTaxRate(int id)
        {
            using (var db = new AppDbContext())
            {
                var taxRate = new tax_rate { id = id };
                db.tax_rate.Attach(taxRate);
                db.tax_rate.Remove(taxRate);
                db.SaveChanges();
            }
        }

        public tax_rate UpdateTaxRate(int id, tax_rate requestRate)
        {
            var taxRate = GetTaxRateById(id);
            if (taxRate != null)
            {
                using (var db = new AppDbContext())
                {
                    taxRate.code = requestRate.code;
                    taxRate.name = requestRate.name;
                    taxRate.rate = requestRate.rate;
                    db.SaveChanges();
                }
                return taxRate;
            } 
            else
            {
                // log error
                return null;
            }
        }
    }
}