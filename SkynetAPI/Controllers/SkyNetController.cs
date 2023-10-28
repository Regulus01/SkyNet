using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkynetAPI.Entities;

namespace SkynetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SkyNetController : ControllerBase
{
    private readonly string _apiKey = "d771db2ed9234233b86c46b9ec0a238f";
    private readonly string _endPointTranlatorBase = "https://api.cognitive.microsofttranslator.com";

    [HttpGet]
    [Route("ObterTraducao")]
    public async Task<IActionResult> ObterTraducao(string textoParaTraducao, string idiomaDestino = "en")
    {
        var route = $"/translate?api-version=3.0&from=pt&to={idiomaDestino}";
        var body = new object[] { new { Text = textoParaTraducao } };
        var requestBody = JsonConvert.SerializeObject(body);

        var client = new HttpClient();
        var request = new HttpRequestMessage();
        
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(_endPointTranlatorBase + route);
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        request.Headers.Add("Ocp-Apim-Subscription-Key", _apiKey);
        request.Headers.Add("Ocp-Apim-Subscription-Region", "eastus");

        var response = await client.SendAsync(request).ConfigureAwait(false);
        var result = await response.Content.ReadAsStringAsync();
        var textoTraduzido = JsonConvert.DeserializeObject<Root[]>(result);
        
        return Ok(textoTraduzido.FirstOrDefault().Translations.FirstOrDefault());   
    }
}