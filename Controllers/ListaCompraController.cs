using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class ListaCompraController : Controller
{
    private const string ApiUrl = "https://tuservicioweb.com/api/listacompras";

    public async Task<IActionResult> Index()
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<ListaCompra>>();
                    return View(data);
                }
                else
                {
                    // Manejo de errores si la solicitud no fue exitosa
                    // Puedes redirigir a una vista de error, mostrar un mensaje, etc.
                    return View(new List<ListaCompra>());
                }
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores si ocurre una excepción durante la solicitud
            // Puedes redirigir a una vista de error, mostrar un mensaje, etc.
            return View(new List<ListaCompra>());
        }
    }
}
