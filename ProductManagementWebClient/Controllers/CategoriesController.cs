using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _httpclient = null;
        private string CategoryApiUrl = "";
        public CategoriesController()
        {
            _httpclient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpclient.DefaultRequestHeaders.Accept.Add(contentType);
            CategoryApiUrl = "https://localhost:7027/api/Categories";
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
              HttpResponseMessage response = await _httpclient.GetAsync(CategoryApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Category> listCategorys = JsonSerializer.Deserialize<List<Category>>(strData, options);
            return View(listCategorys);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _httpclient.GetAsync($"{CategoryApiUrl}/{id}");
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

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category c)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(c);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpclient.PostAsync(CategoryApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Category inserted successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View(c);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await _httpclient.GetAsync($"{CategoryApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Category c = JsonSerializer.Deserialize<Category>(strData, options);
                return View(c);
            }
            return View();
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category c)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(c);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpclient.PutAsync($"{CategoryApiUrl}/{id}", contentData);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Category update successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View(c);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpclient.GetAsync($"{CategoryApiUrl}/{id}");
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

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _httpclient.DeleteAsync($"{CategoryApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Category delete successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool CategoryExists(int id)
        //{
        //  return (_context.Categorys?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        //}
    }
}
