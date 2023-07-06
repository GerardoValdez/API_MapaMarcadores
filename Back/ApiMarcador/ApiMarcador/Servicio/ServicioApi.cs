using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using ApiMarcador.Models;
using ApiMarcador.Result;
using ApiMarcador.Result.Marcador;

namespace ApiMarcador.Bussines;

//esta clase la vamos a injectar para usarla en cualquier lado del proyecto
public class ServicioApi : IServicioApi
{
    private static string _nombreUsuario;
    private static string _password;
    private static string _baseUrl;
    private static string _token;

    public ServicioApi()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        _nombreUsuario = builder.GetSection("ApiSettings:nombreUsuario").Value;
        _password = builder.GetSection("ApiSettings:password").Value;
        _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
    }

    public async Task autenticar()
    {
        var cliente = new HttpClient();

        cliente.BaseAddress = new Uri(_baseUrl);

        var credenciales = new Credencial() { NombreUsuario = _nombreUsuario, Password = _password };
        //creamos el contenido para pasarle a la api de autenticacion
        var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");

        //ejecutamos y pasamos el contenido
        var response = await cliente.PostAsync("api/usuario/LoginUsuarioWeb", content);

        //json de la respuesta
        var json_respuesta = await response.Content.ReadAsStringAsync();

        //del json saco el token
        var resultado = JsonConvert.DeserializeObject<ResultadoCredencial>(json_respuesta);
        _token = resultado.Token;
    }


    public async Task<ListadoMarcadores> getMarcadores()
    {
        var listadoMarcadores = new ListadoMarcadores();

        await autenticar();

        var cliente = new HttpClient();
        cliente.BaseAddress = new Uri(_baseUrl);
        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        var response = await cliente.GetAsync("api/marcador/GetMarcadores");

        if (response.IsSuccessStatusCode)
        {
            var jsonRespuesta = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<ListadoMarcadores>(jsonRespuesta);

            if (resultado.Ok)
            {
                listadoMarcadores = resultado;
            }
            else
            {
                // Manejo de error de la petición HTTP
                listadoMarcadores.SetMensajeError(resultado.MensajeError, resultado.StatusCode);
            }
        }
        else
        {
            // Manejo de error de la petición HTTP
            listadoMarcadores.SetMensajeError("Error en la petición HTTP", response.StatusCode);
        }

        return listadoMarcadores;
    }

    
}