using bivaa_server_main.Core;
using bivaa_server_main.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace bivaa_server_main.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class TaxRateController : BaseController
    {
        private ITaxRateService taxRateService;
        public TaxRateController(ICommonService commonService, ITaxRateService taxRateService) : base(commonService) 
        {
            this.taxRateService = taxRateService;
        }

        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetAll()
        {
            var taxRates = taxRateService.GetAllTaxRates();
            return commonService.GetResponse(taxRates.toJson());
        }

        [HttpGet]
        [ActionName("detail")]
        public HttpResponseMessage GetDetail(int id)
        {
            var taxRate = taxRateService.GetTaxRateById(id);
            return commonService.GetResponse(taxRate.toJson());
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage Create(HttpRequestMessage req)
        {
            // request handling and deserialization
            var requestBody = req.Content.ReadAsStringAsync().Result;
            var requestTaxRate = requestBody.fromJson<tax_rate>();

            // create obj in database - service call
            var createdTaxRate = taxRateService.CreateTaxRate(requestTaxRate);

            // return created object
            return commonService.GetResponse(createdTaxRate.toJson());
        }

        [HttpPut]
        [ActionName("update")]
        public HttpResponseMessage Update(int id, HttpRequestMessage req)
        {
            // request handling and deserialization
            var requestBody = req.Content.ReadAsStringAsync().Result;
            var requestTaxRate = requestBody.fromJson<tax_rate>();

            // create obj in database - service call
            var updatedTaxRate = taxRateService.UpdateTaxRate(id, requestTaxRate);

            // return created object
            return commonService.GetResponse(updatedTaxRate.toJson());
        }

        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int id)
        {
            taxRateService.DeleteTaxRate(id);
            return commonService.GetResponse();
        }
    }
}