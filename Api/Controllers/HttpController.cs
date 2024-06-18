//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class HttpController : ControllerBase
//    {

//        private readonly IHttpClientFactory _httpClientFactory;

//        public HttpController(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
           
//            var client = _httpClientFactory.CreateClient("ApiService1");

           
//            var response = await client.GetAsync("https://www.mhc.ab.ca/");
 
//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                return Ok(content);
//            }

//            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            
//        }
//    }
//}

