using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _apiKey = "tuAPIAQUIXDPARAOPENIA";


        [HttpPost]
        [HttpGet]
        [IgnoreAntiforgeryToken]  // ¡No recomendado en producción!
        public async Task<ActionResult> Generar(string inputTexto,string tipoDiagrama,int modelo)
        {
            try
            {
                if (modelo==0) {
                if (string.IsNullOrEmpty(inputTexto))
                {
                    ViewBag.Documento = "Por favor, ingrese un tema válido.";
                    return View("Index");
                }

                var resultado = await GenerarDocumentoAsync(inputTexto +", quiero que sea con este diagrama "+tipoDiagrama);
                resultado = resultado.Replace("```mermaid", "").Replace("```","");
                ViewBag.Documento = resultado;

                ViewBag.DiagramaMermaid = resultado;
                return View("Index");
                }else 
                {
                    if (string.IsNullOrEmpty(inputTexto))
                    {
                        ViewBag.Documento = "Por favor, ingrese un tema válido.";
                        return View("Index");
                    }

                    var resultado = await GenerarDocumentoAsync2(inputTexto , tipoDiagrama);
                    resultado = resultado.Replace("```mermaid", "").Replace("```", "");
                    ViewBag.Documento = resultado;
                    String SoloDiagrama=resultado.Split("Este diagrama ")[0];
                    ViewBag.DiagramaMermaid = SoloDiagrama;
                    return View("Index");
                }
            }
            catch (Exception es)
            {
                ViewBag.Documento = "Por favor, ingrese un tema válido." + es.Message;
                return View("Index");

            }
         
       
        }

        [HttpPost]
        [HttpGet]
        [IgnoreAntiforgeryToken]  // ¡No recomendado en producción!
        public IActionResult Generar2(string SolotextoSoyyo)
        {
            try
            {
              
                    if (string.IsNullOrEmpty(SolotextoSoyyo))
                    {
                        ViewBag.Documento = "Por favor, ingrese un tema válido.";
                        return View("Index");
                    }
                ViewBag.Documento = SolotextoSoyyo;

                ViewBag.DiagramaMermaid = SolotextoSoyyo;
                return View("Index");
            }
            catch (Exception es)
            {
                ViewBag.Documento = "Por favor, ingrese un tema válido." + es.Message;
                return View("Index");

            }


        }
        [HttpPost]
        [HttpGet]
        [IgnoreAntiforgeryToken]  // ¡No recomendado en producción!
        public async Task<IActionResult> Generar3Async(string inputTexto2, int modelo2)
        {
            try
            {
                string inputTexto = inputTexto2;
                int modelo = modelo2;

                if (string.IsNullOrEmpty(inputTexto))
                {
                    ViewBag.Documento = "Por favor, ingrese un tema válido.";
                    return View("Index");
                }
                try
                {
                    if (modelo == 0)
                    {
                        if (string.IsNullOrEmpty(inputTexto))
                        {
                            ViewBag.Documento = "Por favor, ingrese un tema válido.";
                            return View("Index");
                        }

                        var resultado = await GenerarDocumentoAsync(inputTexto + ", has una correcion diagrama");
                        resultado = resultado.Replace("```mermaid", "").Replace("```", "");
                        ViewBag.Documento = resultado;

                        ViewBag.DiagramaMermaid = resultado;
                        return View("Index");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(inputTexto))
                        {
                            ViewBag.Documento = "Por favor, ingrese un tema válido.";
                            return View("Index");
                        }

                        var resultado = await GenerarDocumentoAsync2(inputTexto, " has una correcion diagrama");
                        resultado = resultado.Replace("```mermaid", "").Replace("```", "");
                        ViewBag.Documento = resultado;
                        String SoloDiagrama = resultado.Split("Este diagrama ")[0];
                        ViewBag.DiagramaMermaid = SoloDiagrama;
                        return View("Index");
                    }
                }
                catch (Exception esx)
                {
                    ViewBag.Documento = "Por favor, ingrese un tema válido." + esx.Message;
                    return View("Index");

                }
            }
            catch (Exception es)
            {
                ViewBag.Documento = "Por favor, ingrese un tema válido." + es.Message;
                return View("Index");

            }


        }

        public async Task<string> GenerarDocumentoAsync(string prompt)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
                    var requestData = new
                    {
                        model = "gpt-4-turbo",
                        messages = new[]
    {
        new { role = "system", content = "Eres un asistente experto en generación de documentación técnica, siempre dame solo la solucion sin explicarme" },
         //new { role = "system", content = "Para diagrama de flujo, utiliza esta nomeclatura: 1.Si es usuario usa circulo: ejemplo Usuario Inicia con el sistema o hace alguna accion va a ser circulo mas el tipo de usuario" +
        // ", 2.Si es desion usa rombo: cuando se tenga que hacer alguna desicion usa ejemplo: Rompo analisis de inventario," +
        // "3.Usa cuadrado para la accion siguiente del digrama de flujo" },
        //  new { role = "system", content = "Reduce tus respuestas y reemplazar Usuario por U, Circulo por Ci, Cuadrado por Cu, Rompo por Ro." },
           new { role = "system", content = "Genera un diagrama de flujo en formato Mermaid.js" },
                      new { role = "system", content = "Antes de generarlo revisa que cumpla con el formato de Mermaid.js" },
        new { role = "user", content = prompt },
                    new { role = "system", content = " Salida esperada: Un código en Mermaid.js listo para incrustar en HTML, devuelve solo el codigo sin texto adicional." }
    },
                        max_tokens = 600
                    };
                    string jsonBody = JsonConvert.SerializeObject(requestData);
                    Console.WriteLine($"JSON Sent: {jsonBody}");
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                    Console.WriteLine($"Response: {response.StatusCode} - {response.Content}");

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        dynamic jsonResult = JsonConvert.DeserializeObject(result);

                        String nuevo=jsonResult.choices[0].message.content;
                        return nuevo;
                    }

                    return "Error al generar la documentación"+ response.Content;
                }
            }
            catch (Exception es)
            {

                return "Error al generar la documentación" + es.Message;
            }
           
        }

        public async Task<string> GenerarDocumentoAsync2(string prompt,String prompt2)
        {
            try
            {
                String agregar=".Genera un diagrama de flujo de Mermaid de tipo " + prompt2 + " que describa";
                prompt = prompt+agregar+".Solo dame el diagrama no me respondas nada mas que eso porque es para insertarlo " +
                    "en un html de forma directa, que sea sin tildes porque mi procesador no las procesa bien";
                var processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    // Se utiliza /c para ejecutar el comando y cerrarlo
                    Arguments = $"/c ollama run mistral \"{prompt}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(processInfo))
                {
                    string result = await process.StandardOutput.ReadToEndAsync();
                    await process.WaitForExitAsync();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "Error al generar la documentación: " + ex.Message;
            }

        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
