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
        public async Task<ActionResult> calculatePrice(InputModel input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new InputModel();
                    
                    using (var client = new HttpClient())
                    {
                        var APIurl = System.Configuration.ConfigurationManager.AppSettings["lawMowAPIUrl"];
                        client.BaseAddress = new Uri(APIurl);
                        //HTTP GET
                        var responseTask = client.GetAsync("calculatePrice/" + input.SqMeter);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            var responseString = await result.Content.ReadAsStringAsync();
                            var response = JsonConvert.DeserializeObject<ResponseModel>(responseString);
                            if (response.Success)
                            {
                                model = response.Data;
                                TempData["Success"] = "Get Weather Data Successfully";
                            }
                            else
                            {
                                TempData["Error"] = "Failed To Getting Weather Data";
                            }
                        }
                        else
                        {
                            TempData["Error"] = "Failed To Getting Weather Data";
                        }
                    }
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