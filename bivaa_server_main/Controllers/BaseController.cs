using bivaa_server_main.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace bivaa_server_main.Controllers
{
    public class BaseController : ApiController
    {
        public ICommonService commonService;
        public BaseController(ICommonService commonService)
        {
            this.commonService = commonService;
        }
    }
}