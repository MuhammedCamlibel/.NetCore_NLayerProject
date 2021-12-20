using NLayerProject.WEB.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NLayerProject.WEB.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync() 
        {
            IEnumerable<CategoryDto> categories;

            var response = await  _httpClient.GetAsync("Categories");
            
            if(response.IsSuccessStatusCode) 
            {
                var data = await response.Content.ReadAsStringAsync(); 
                categories = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(data);
            }
            else 
            {
                categories = null;
            }

            return categories;
            
        }


        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto) 
        {
            var response = await _httpClient.PostAsync("categories",new StringContent(JsonSerializer.Serialize(categoryDto),Encoding.UTF8,"application/json"));

            if (response.IsSuccessStatusCode) 
            {
                categoryDto = JsonSerializer.Deserialize<CategoryDto>(await response.Content.ReadAsStringAsync());
                return categoryDto;
            }
            else 
            {
                return null;
            }
        }


        public async Task<CategoryDto> GetByIdAsync(int id) 
        {
            var response = await _httpClient.GetAsync($"Categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var categoryDto = JsonSerializer.Deserialize<CategoryDto>(data);
                return categoryDto;
            }
            else { return null; }

        }

        public async Task<bool> Update(CategoryDto categoryDto) 
        {
            var response = await _httpClient.PutAsync($"categories", new StringContent(JsonSerializer.Serialize(categoryDto), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode) 
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> Delete(int id) 
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");

            if (response.IsSuccessStatusCode)
                return true;
            else 
                return false; 
              
        }

    }
}
