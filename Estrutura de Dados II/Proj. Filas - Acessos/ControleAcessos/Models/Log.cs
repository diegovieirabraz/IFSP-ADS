namespace ControleAcessos.Models;

public class Log
{
    public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso)
    {
        DtAcesso = dtAcesso;
        Usuario = usuario;
        TipoAcesso = tipoAcesso;
    }

    public DateTime DtAcesso { get; }

    public Usuario Usuario { get; }

    public bool TipoAcesso { get; }
}
