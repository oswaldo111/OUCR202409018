using CRM.DTOs.ProducOUCRDTOs;

namespace CRM.AppWebBlazor.Data
{
    public class ProductService
    {
        readonly HttpClient _httpProductCRMAPI;

        // Constructor que recibe una instancia de IHttpClientFactory para crear el cliente HTTP
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpProductCRMAPI = httpClientFactory.CreateClient("CRMAPI");
            
        }
        
        // Método para buscar clientes utilizando una solicitud HTTP POST
        public async Task<SearchResultProductsDTO> Search(SearchQueryProductDTO searchQueryProductsDTO)
        {
            var response = await _httpProductCRMAPI.PostAsJsonAsync("/product/search", searchQueryProductsDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultProductsDTO>();
                return result ?? new SearchResultProductsDTO();
            }
            return new SearchResultProductsDTO(); // Devolver un objeto vacío en caso de error o respuesta no exitosa
        }

        // Método para obtener un cliente por su ID utilizando una solicitud HTTP GET
        public async Task<GetIdResultProductDTO> GetById(int id)
        {
            var response = await _httpProductCRMAPI.GetAsync("/product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();
                return result ?? new GetIdResultProductDTO();
            }
            return new GetIdResultProductDTO(); // Devolver un objeto vacío en caso de error o respuesta no exitosa
        }

        // Método para crear un nuevo cliente utilizando una solicitud HTTP POST
        public async Task<int> Create(CreateProducDTO createProducDTO)
        {
            int result = 0;
            var response = await _httpProductCRMAPI.PostAsJsonAsync("/product", createProducDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para editar un cliente existente utilizando una solicitud HTTP PUT
        public async Task<int> Edit(EditProductDTO editProductDTO)
        {
            int result = 0;
            var response = await _httpProductCRMAPI.PutAsJsonAsync("/product", editProductDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para eliminar un cliente por su ID utilizando una solicitud HTTP DELETE
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpProductCRMAPI.DeleteAsync("/product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }
    }
}
