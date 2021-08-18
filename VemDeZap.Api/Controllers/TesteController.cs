using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VemDeZap.Api.Controllers
{
    public class TesteController : Controller
    {
        public string Get()
        {
            return "1.0.0";
        }
    }
}
