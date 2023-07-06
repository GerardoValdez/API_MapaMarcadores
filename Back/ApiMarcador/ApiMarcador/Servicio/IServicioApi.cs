using ApiMarcador.Result.Marcador;

namespace ApiMarcador.Bussines;

public interface IServicioApi
{
    public Task<ListadoMarcadores> getMarcadores();
}