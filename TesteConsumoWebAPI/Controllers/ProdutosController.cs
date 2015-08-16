using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using TesteConsumoWebAPI.Models;

namespace TesteConsumoWebAPI.Controllers
{
    public class ProdutosController : Controller
    {
        public ActionResult ExemploConsumoDotNet()
        {
            List<Produto> produtos;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(
                    ConfigurationManager.AppSettings["UrlCatalogoProdutos"]).Result;
                response.EnsureSuccessStatusCode();

                produtos = response.Content.ReadAsAsync<List<Produto>>().Result;
            }

            return View(produtos);
        }

        public ActionResult ExemploConsumojQuery()
        {
            ViewBag.UrlCatalogoProdutos =
                ConfigurationManager.AppSettings["UrlCatalogoProdutos"];
            return View();
        }
    }
}