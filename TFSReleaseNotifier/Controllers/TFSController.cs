using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TFSReleaseNotifier.Models.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace TFSReleaseNotifier.Controllers
{
    
    public class TFSController : Controller
    {
        private const string TfsBaseUrl = "http://yourtfsserver:8080/tfs/DefaultCollection";
        private const string ProjectName = "YourProject";
        private const string IterationPath = "YourProject\\IterationName";
        private const string ApiVersion = "6.0"; // Use the appropriate API version

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                // Connect to TFS and get PBIs for the specified iteration using TFS REST API
                List<PBIViewModel> pbis = await GetPBIsFromTFS();

                // Display PBIs on the screen
                return View(pbis);
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail()
        {
            try
            {
                // Get PBIs again or use the data previously retrieved, as needed
                List<PBIViewModel> pbis = await GetPBIsFromTFS();

                // Send email with PBIs information
                await SendEmailAsync(pbis);

                ViewBag.SuccessMessage = "Email sent successfully!";
                return View("Success");
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

        private async Task<List<PBIViewModel>> GetPBIsFromTFS()
        {
            // Personal Access Token (PAT)
            string pat = "your_personal_access_token";

            // TFS REST API URL
            string apiUrl = $"{TfsBaseUrl}/{ProjectName}/_apis/wit/workitems?api-version={ApiVersion}&$filter=System.WorkItemType eq 'Product Backlog Item' and System.IterationPath eq '{IterationPath}'";

            // Create HTTP client
            using (HttpClient client = new HttpClient())
            {
                // Set authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($":{pat}")));

                // Make request to TFS REST API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Parse and process response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Convert JSON response to list of PBIViewModel
                    List<PBIViewModel> pbis = JsonConvert.DeserializeObject<List<PBIViewModel>>(responseBody);
                    return pbis;
                }
                else
                {
                    // Handle unsuccessful response
                    throw new Exception($"Failed to retrieve PBIs from TFS. Status code: {response.StatusCode}");
                }
            }
        }

        private async Task SendEmailAsync(List<PBIViewModel> pbis)
        {
            // Implement email sending logic using your preferred email service or library
            // You might use the System.Net.Mail or a third-party library like SendGrid or SmtpClient
            // Example: Send email with PBIs information to a specified recipient
        }
    }
}