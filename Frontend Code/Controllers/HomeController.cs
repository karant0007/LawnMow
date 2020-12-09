using Lawn_Mow_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lawn_Mow_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult calculatePrice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult calculatePrice(InputModel input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new InputModel();
                    if (input.SqMeter <= 15)
                    {
                        model.TotalSquareMeter = input.SqMeter;
                        model.PricePerSqMeter = 1;
                        model.Discount = "0%";
                        model.TotalAmount = input.SqMeter;
                        model.DiscountAmount = 0;
                        model.NetAmount = input.SqMeter;
                    }
                    else if (input.SqMeter > 15 && input.SqMeter <= 25)
                    {
                        var disAmnt = (input.SqMeter * 10) / 100;
                        var netAmnt = input.SqMeter - disAmnt;
                        model.TotalSquareMeter = input.SqMeter;
                        model.PricePerSqMeter = 1;
                        model.Discount = "10%";
                        model.TotalAmount = input.SqMeter;
                        model.DiscountAmount = disAmnt;
                        model.NetAmount = netAmnt;
                    }
                    else
                    {
                        var disAmnt = (input.SqMeter * 15) / 100;
                        var netAmnt = input.SqMeter - disAmnt;
                        model.TotalSquareMeter = input.SqMeter;
                        model.PricePerSqMeter = 1;
                        model.Discount = "15%";
                        model.TotalAmount = input.SqMeter;
                        model.DiscountAmount = disAmnt;
                        model.NetAmount = netAmnt;
                    }
                    TempData["Success"] = "Square Meter Calculation Done";
                    return View(model);
                }
                else
                {
                    TempData["Error"] = "Please Enter Square Meter";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Something Went Wrong";
            }
            return View();
        }

        public async Task<ActionResult> WeatherForecast()
        {
            var model = new WeatherForecast();
            try
            {
                var APIkey = System.Configuration.ConfigurationManager.AppSettings["weatherAPIKey"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
                    //HTTP GET
                    var responseTask = client.GetAsync("onecall?lat=40.751&lon=-73.997&units=metric&appid=" + APIkey);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        var responseString = await result.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<WeatherForecast>(responseString);
                        TempData["Success"] = "Next 7 Days Weather Report";
                    }
                    else
                    {
                        TempData["Error"] = "Failed To Getting Weather Data";
                    }
                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Something Went Wrong";
                model = null;
            }
            return View(model);
        }
    }
}