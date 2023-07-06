using ApiMarcador.Bussines;
using ApiMarcador.Result.Marcador;
using Microsoft.AspNetCore.Mvc;


namespace ApiMarcador.Controllers;

[ApiController]
[Route("api/marcador")]
public class MarcadorController : ControllerBase
{
    private readonly IServicioApi _servicioApi;

    public MarcadorController(IServicioApi servicioApi)
    {
        _servicioApi = servicioApi;
    }

    [HttpGet]
    [Route("getMarcadores")]
    public async Task<ListadoMarcadores> getMarcadores()
    {
        ListadoMarcadores listadoMarcadores = await _servicioApi.getMarcadores();
        return listadoMarcadores;
    }

}