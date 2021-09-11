﻿namespace Cobra.Common
{
    public static class CnpjExtensions
    {
        public static bool IsCnpj(this string cnpj)
        {
            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                return false;
            }

            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (var i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            var resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (var i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
