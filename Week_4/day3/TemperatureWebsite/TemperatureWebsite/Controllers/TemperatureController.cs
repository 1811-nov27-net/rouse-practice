using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemperatureWebsite.Models;

namespace TemperatureWebsite.Controllers
{
    public class TemperatureController : Controller
    {
        public HttpClient Client { get; set; }

        public TemperatureController(HttpClient client)
        {
            Client = client;
        }

        public async Task<ActionResult<List<TemperatureRecord>>> GetTemperatures()
        {
            // send "GET api/Temperature" to service, get headers of response
            HttpResponseMessage response = await Client.GetAsync("https://localhost:44336/api/temperature");

            // If status code is not 200 - 299 (for success)
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(404);
            }

            // Get the whole response body
            var responseBody = await response.Content.ReadAsStringAsync();

            // This is a string, so it must be deserialized into a C# object
            // We could use DataContractSerializer (built into .NET), but it's more awkwards than third-party Newtonsoft JSON (aka JSON.net)

            List<TemperatureRecord> temperatures = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody);

            return temperatures;
        }

        // GET: Temperature
        public ActionResult Index()
        {
            var allTemps = GetTemperatures();

            return View(allTemps);
        }

        // GET: Temperature/Details/5
        public async Task<ActionResult> Details(int id)
        {
            // send "GET api/Temperature" to service, get headers of response
            HttpResponseMessage response = await Client.GetAsync("https://localhost:44336/api/temperature");

            // If status code is not 200 - 299 (for success)
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(404);
            }

            // Get the whole response body
            var responseBody = await response.Content.ReadAsStringAsync();

            // This is a string, so it must be deserialized into a C# object
            // We could use DataContractSerializer (built into .NET), but it's more awkwards than third-party Newtonsoft JSON (aka JSON.net)

            TemperatureRecord temperature = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody).Where(x => x.Id == id).FirstOrDefault();

            return View(temperature);
        }

        // GET: Temperature/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Temperature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                TemperatureRecord createMe = new TemperatureRecord
                {
                    Id = Int32.Parse(collection["Id"]),
                    Time = DateTime.Now,
                    Value = Double.Parse(collection["Value"]),
                    Unit = Int32.Parse(collection["Unit"]),
                };



                HttpResponseMessage createJson = await Client.PostAsJsonAsync("https://localhost:44336/api/temperature", createMe);

                if (!createJson.IsSuccessStatusCode)
                {
                    return StatusCode(400);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Edit/5
        public ActionResult Edit(int id)
        {
            // send "GET api/Temperature" to service, get headers of response
            HttpResponseMessage response = await Client.GetAsync("https://localhost:44336/api/temperature");

            // If status code is not 200 - 299 (for success)
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(404);
            }

            // Get the whole response body
            var responseBody = await response.Content.ReadAsStringAsync();

            // This is a string, so it must be deserialized into a C# object
            // We could use DataContractSerializer (built into .NET), but it's more awkwards than third-party Newtonsoft JSON (aka JSON.net)

            TemperatureRecord temperature = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody).Where(x => x.Id == id).FirstOrDefault();

            return View(temperature);
        }

        // POST: Temperature/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Temperature/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}