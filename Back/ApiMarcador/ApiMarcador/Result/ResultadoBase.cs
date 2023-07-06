using System.Net;

namespace ApiMarcador.Result;

public class ResultadoBase
{
    public string MensajeError { get; set; }
    public bool Ok { get; set; } = true;
    public string MensajeInfo { get; set; } = " ";
    public HttpStatusCode StatusCode { get; set; }
    
    public void SetMensajeError(string mensajeError, HttpStatusCode statusCode)
    {
        Ok = false;
        MensajeError = mensajeError;
        StatusCode = statusCode;
    }
    
    public void SetMensajeInfo(string mensajeInfo, HttpStatusCode statusCode)
    {
        MensajeInfo = mensajeInfo;
        StatusCode = statusCode;
    }
    
    
}