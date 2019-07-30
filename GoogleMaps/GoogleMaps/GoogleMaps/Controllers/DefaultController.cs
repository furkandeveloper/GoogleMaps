using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.Geocoding;
using GoogleMaps.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoogleMaps.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new GoogleMapsViewModel());
        }

        [HttpPost]
        public IActionResult Index(GoogleMapsViewModel model)
        {
            GoogleSigned.AssignAllServices(new GoogleSigned("Your Api Key"));
            var request = new GeocodingRequest();
            request.Address = model.Adress.ToString().ToUpper().Trim();
            var response = new GeocodingService().GetResponse(request);
            if (response.Status == ServiceResponseStatus.Ok && response.Results.Count()>0)
            {
                var result = response.Results.First();
                model.FullAddress = result.FormattedAddress;
                model.xCordinat = result.Geometry.Location.Latitude.ToString();
                model.yCordinat = result.Geometry.Location.Longitude.ToString();
                model.Message = "Enlem ve boylam bilgisine ulaşıldı";
                return View(model);
            }
            else
            {
                model.Message = "Hata lütfen adresinizi kontrol ediniz";
                return View(model);
            }
        }
    }
}