using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PruebaNexos.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PruebaNexos.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILogger<LibroController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<LibroDTO> index = new List<LibroDTO>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://localhost:44390");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseTask = client.GetAsync("/api/Libro/ListadoLibro");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync().Result;
                        index = JsonConvert.DeserializeObject<List<LibroDTO>>(readTask);
                    }
                    else
                    {
                        index = null;
                        ModelState.AddModelError(string.Empty, "Server error !!!");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message.ToString());
                }
            }
            return View(index);
        }

        // GET: LibroController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LibroController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibroController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibroController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibroController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibroController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibroController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
