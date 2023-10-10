using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyWebApp.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MyWebApp.Controllers
{
    public class ProductManagerController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public ProductManagerController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7075/api/products";
        }
        // GET: ProductManagerController
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string stringData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(stringData, options);
            return View(listProducts);
        }

        // GET: ProductManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string stringData = JsonSerializer.Serialize(product);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ProductApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Product inserted successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while calling Web API";
                }
            }
            return View(product);
            
        }

        // GET: ProductManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Product product)
        {
            if (ModelState.IsValid)
            {
                string stringData = JsonSerializer.Serialize(product);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{ProductApiUrl}/{id}", contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Product update successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while calling Web API";
                }
            }
            return View(product);
        }

        // GET: ProductManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{ProductApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Product delete successfully";
            }
            else
            {
                TempData["Message"] = "Error while calling Web API";
            }
            return RedirectToAction(nameof (Index));
        }
    }
}
