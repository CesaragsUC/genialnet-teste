namespace Domain.ValueObjects;

using System.Text.RegularExpressions;

public static class CnpjValidator
{
    public static bool Validate(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;


        cnpj = Regex.Replace(cnpj, @"[^\d]", "");

        if (cnpj.Length != 14)
            return false;


        string[] invalidCnpjs =
        {
            "00000000000000", "11111111111111", "22222222222222", "33333333333333",
            "44444444444444", "55555555555555", "66666666666666", "77777777777777",
            "88888888888888", "99999999999999"
        };

        if (Array.Exists(invalidCnpjs, element => element == cnpj))
            return false;


        int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj.Substring(0, 12);
        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        int resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        string digito = resto.ToString();
        tempCnpj += digito;

        // Validate the second check digit
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();

        // Check if the calculated check digits match the input
        return cnpj.EndsWith(digito);
    }
}

