using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JTW.MVC.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace JTW.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            string baseUrl = "https://localhost:44344/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            User userModel = new User();
            userModel.UserName = "admin";
            userModel.Password = "Password@123";

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/authenticate/login", contentData).Result;
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);

            HttpContext.Session.SetString("token", jwt.Token);
            ViewBag.Message = "User loggin in successfully!";

            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            ViewBag.Message = "User logged out";
            return View("Index");
        }

        public IActionResult ShowData()
        {
            string baseUrl = "https://localhost:44344/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            HttpResponseMessage response = client.GetAsync("/WeatherForecast").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Wheater> data = JsonConvert.DeserializeObject<List<Wheater>>(stringData);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Oh no no no!";
            }
            else
            {
                string strTable = "<table border='1' cellpadding='10'>";
                foreach (Wheater emp in data)
                {
                    strTable += "<tr>";
                    strTable += "<td>";
                    strTable += emp.Date;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += emp.Summary;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += emp.TemperatureC;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += emp.TemperatureF;
                    strTable += "</td>";
                    strTable += "</tr>";

                }
                strTable += "</table>";

                ViewBag.Message = strTable;
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
