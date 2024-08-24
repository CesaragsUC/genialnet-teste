using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

namespace web.Extensions;

public static class RazorExtensions
{
    public static string FormatCnpg(this RazorPage page, string documento)
    {
        return  Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
    }
    public static string formatRealBrazil(this RazorPage page, decimal valor)
    {
        return valor.ToString("C", new CultureInfo("pt-BR"));
    }
}
