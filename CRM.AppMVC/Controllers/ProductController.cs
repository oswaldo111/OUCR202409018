using CRM.DTOs.ProducOUCRDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRM.AppMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClientCRAPI;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRAPI = httpClientFactory.CreateClient("CRMAPI");
        }
        // GET: ProductController
        public async Task<IActionResult> Index(SearchQueryProductDTO searchQueryProductDTO, int CountRow = 0)
        {
            if(searchQueryProductDTO.SendRowCount == 0)
                searchQueryProductDTO.SendRowCount = 2;

            if(searchQueryProductDTO.Take == 0)
                searchQueryProductDTO.Take = 10;

            var result = new SearchResultProductsDTO();

            var response = await _httpClientCRAPI.PostAsJsonAsync("/product/search", searchQueryProductDTO);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchResultProductsDTO>();

            result = result != null ? result : new SearchResultProductsDTO();

    
            if (result.CountRow == 0 && searchQueryProductDTO.SendRowCount == 1)
                result.CountRow = CountRow;
           

            ViewBag.CountRow = result.CountRow;
            searchQueryProductDTO.SendRowCount = 0;
            ViewBag.SearchQuery = searchQueryProductDTO;
           
            return View(result);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultProductDTO();

            var response = await _httpClientCRAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();

            return View(result ?? new GetIdResultProductDTO());
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProducDTO createProducDTO)
        {
            try
            {
                var resonse = await _httpClientCRAPI.PostAsJsonAsync("/product", createProducDTO);

                if (resonse.IsSuccessStatusCode) {

                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "no se guardo";
                return View();
            }   
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultProductDTO();

            var response = await _httpClientCRAPI.GetAsync("/product/" + id);

            if(response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();

            return View(new EditProductDTO(result ?? new GetIdResultProductDTO()));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductDTO editProductDTO)
        {
            try
            {
                var response = await _httpClientCRAPI.PutAsJsonAsync("/product" , editProductDTO);

                if(response.IsSuccessStatusCode )
                    return RedirectToAction(nameof(Index));

                ViewBag.Error = "no edito";
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Errors = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultProductDTO();
            var response = await _httpClientCRAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode) {
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();
                    }

            return View(result ?? new GetIdResultProductDTO());
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultProductDTO getIdResultProductDTO)
        {
            try
            {
                var response = await _httpClientCRAPI.DeleteAsync("/product/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "no elimina";
                return View(getIdResultProductDTO);
            }
            catch(Exception ex)
            {
                ViewBag.Errors = ex.Message;
                return View(getIdResultProductDTO);
            }
        }
    }
}
