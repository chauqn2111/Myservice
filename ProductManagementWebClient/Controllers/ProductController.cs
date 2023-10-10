using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpclient = null;
        private string ProductApiUrl = "";
        public ProductController() 
        {
            _httpclient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpclient.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7027/api/ProductsControllers";
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpclient.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return View(listProducts);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _httpclient.GetAsync($"{ProductApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Product p = JsonSerializer.Deserialize<Product>(strData, options);
                return View(p);
            }
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(p);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpclient.PostAsync(ProductApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Product inserted successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View(p);
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await _httpclient.GetAsync($"{ProductApiUrl}/{id}");
            if (response.IsSuccessStatusCode){
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Product p = JsonSerializer.Deserialize<Product>(strData, options);
                return View(p); }
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product p)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(p);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpclient.PutAsync($"{ProductApiUrl}/{id}", contentData);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Product update successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View(p);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpclient.GetAsync($"{ProductApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Product p = JsonSerializer.Deserialize<Product>(strData, options);
                return View(p);
            }
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _httpclient.DeleteAsync($"{ProductApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Product delete successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
