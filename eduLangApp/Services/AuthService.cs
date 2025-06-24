namespace eduLangApp.Services;

// public class AuthServices
// {
//     private readonly HttpClient _httpClient;
//     private const string BaseUrl = "";
//
//
//     public AuthServices()
//     {
//         _httpClient = new HttpClient();
//         _httpClient.DefaultRequestHeaders.Accept.Add(
//             new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
//         );
//
//     }
//
//     public async Task<bool> Login(string email, string password)
//     {
//         try
//         {
//             var requestData = new { email, password };
//             var json = JsonConvert.SerializeObject(requestData);
//             var content = new StringContent(json, Encoding.UTF8, "application/json");
//             var response = await _httpClient.PostAsync($"{BaseUrl}/auth/login", content);
//             if (!response.IsSuccessStatusCode)
//             {
//                 return false;
//             }
//
//             var responseContent = await response.Content.ReadAsStringAsync();
//             var result = JsonConvert.DeserializeObject<AuthResponse>(responseContent);
//             if (result?.Success == true)
//             {
//                 Preferences.Set("user", result.Usuario.Nombre);
//                 return true;
//             }
//
//             return false;
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex);
//             throw;
//         }
//     }
//
//