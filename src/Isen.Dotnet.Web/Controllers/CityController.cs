using System;
using System.Linq;
using Isen.Dotnet.Library.Context;
using Isen.Dotnet.Library.Model;
using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public class CityController : BaseController<City>
    {
        public CityController(
            ILogger<CityController> logger,
            ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}