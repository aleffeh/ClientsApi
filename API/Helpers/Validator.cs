using System.Text.RegularExpressions;
using API.Models;

namespace API.Helpers
{
    public static class Validator
    {
        public static bool IsValidClient(Client client) => IsNotNull(client) &&
                                                           IsValidCpf(client.Cpf) && IsValidDate(client.Birthday) &&
                                                           IsValidCellPhoneNumber(client.PhoneNumber) &&
                                                           IsValidObs(client.Obs);

        public static bool IsValidCpf(string cpf)
        {
            var multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            var multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsValidObs(string obs) => obs == null || obs.Length < 300;

        public static bool IsNotNull(Client client) =>
            client.Adress != null && client.Birthday != null && client.Cpf != null && client.Email != null &&
            client.Name != null && client.PhoneNumber != null;

        public static bool IsValidCellPhoneNumber(string phoneNumber) => Regex.IsMatch(phoneNumber,
            "^\\([1-9]{2}\\) (?:[2-8]|9[1-9])[0-9]{3}\\-[0-9]{4}$", RegexOptions.Compiled);

        public static bool IsValidDate(string date) => Regex.IsMatch(date,
            "(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/((1[2-9]|[2-9][0-9])[0-9])", RegexOptions.Compiled);
    }
}