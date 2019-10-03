using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MathTestGenerator;
using Microsoft.AspNetCore.Mvc;
using RequestTracker;

namespace MathProblemApi.Controllers
{
    [Route("api/math")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        public IEquationGenerator EquationGenerator { get; }
        public IRequestTracker RequestTracker { get; }

        public ProviderController(IEquationGenerator equationGenerator, IRequestTracker requestTracker)
        {
            EquationGenerator = equationGenerator;
            RequestTracker = requestTracker;
        }

       

        // GET api/math
        [HttpGet]
        
        public JsonResult Get()
        {
            string mathTest = "";
            string ipAddress = GetIPAddress();
            if (RequestTracker.IsRequestExpired(ipAddress))
            {
                mathTest = EquationGenerator.GenerateMathTest();
                RequestTracker.AddToTracker(ipAddress, mathTest);
            }
            else
            {
                mathTest = RequestTracker.GetPreviousMathTest(ipAddress);
            }
            return new JsonResult (new MathEquation() { Problem = mathTest });
        }
        public string GetIPAddress()
        {
            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            string ip = addr[1].ToString();
            return ip;
        }
    }
}
