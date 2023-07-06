using Newtonsoft.Json;

namespace ApiMarcador.Result.Marcador
{
    public class ListadoMarcadores : ResultadoBase
    {
        public List<ItemMarcador> LitadoMarcadores { get; set; }
    }

    public class ItemMarcador
    {
        public string Latitud { get; set; }
        
        public string Longitud { get; set; }
        
        public string Info { get; set; }
    }
}