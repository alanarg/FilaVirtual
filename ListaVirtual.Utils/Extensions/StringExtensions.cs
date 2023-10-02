using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIlaVirtual.Util.Extensions
{
    public static class StringExtensions
    {
        public static string RemoverMascaraCpf(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Replace(".", "").Replace("-", "").Replace("_", "");
        }

        public static string MascaraCpf(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var cpf = value.PadLeft(11, '0');
            return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }

        public static string ValorOuNenhum(this string value, bool masculino =true)
        {
            if (string.IsNullOrEmpty(value))
            {
                return masculino ? "Nenhum" : "Nenhuma";
            }
            return value;
        }

        public static string CpfOculto(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var cpf = value.PadLeft(11, '0').Remove(3, 6);
            return cpf.Insert(3, ".***.***-");
        }

        public static string LatitudeEmGraus(this decimal value)
        {
            string grauGMD = string.Empty;

            if (value != 0)
            {
                grauGMD = (value < 0) ? "S" : "N";
            }

            string grau = string.Empty;

            value = Math.Abs(value);

            // Grau 
            int calculo = (int)Math.Truncate(value);
            grau += $"{calculo.ToString()}°";

            // Minuto
            value = (value - calculo) * 60;
            calculo = (int)Math.Truncate(value);
            grau += $"{calculo.ToString()}'";

            // Segundo
            value = Math.Round(((value - calculo) * 60), 1);
            grau += $"{value.ToString().Replace(',', '.')}\"";

            return $"{grau} {grauGMD}";
        }

        public static string LongitudeEmGraus(this decimal value)
        {
            string grauGMD = string.Empty;

            if (value != 0)
            {
                grauGMD = (value < 0) ? "W" : "E";
            }

            string grau = string.Empty;

            value = Math.Abs(value);

            // Grau 
            int calculo = (int)Math.Truncate(value);
            grau += $"{calculo.ToString()}°";

            // Minuto
            value = (value - calculo) * 60;
            calculo = (int)Math.Truncate(value);
            grau += $"{calculo.ToString()}'";

            // Segundo
            value = Math.Round(((value - calculo) * 60), 1);
            grau += $"{value.ToString()}\"";

            return $"{grau} {grauGMD}";
        }

        public static string NuloRetornarEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value;
        }

        public static string NuloRetornarEmpty(this string value, string valorDeComparacao, string textoComparar)
        {
            if (string.IsNullOrEmpty(valorDeComparacao) || string.IsNullOrEmpty(textoComparar))
            {
                return string.Empty;
            }

            if (valorDeComparacao.ToUpper() != textoComparar.ToUpper())
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value;
        }

    
        public static string TrueEscreverNao(this bool value)
        {
            if (value)
            {
                return "Não";
            }

            return "Sim";
        }

        public static string TrueEscreverSim(this bool value)
        {
            if (value)
            {
                return "Sim";
            }

            return "Não";
        }

      
        public static string NumeroOrdinalExtenso(this int value)
        {
            if (value > 0)
            {
                string valor = value.ToString().PadLeft(2, '0');

                string[] unidade = { "", "Primeiro", "Segundo", "Terceiro", "Quarto", "Quinto", "Sexto", "Sétimo", "Oitavo", "Nono" };
                string[] dezena = { "", "Décimo", "Vigésimo", "Trigésimo", "Quadragésimo", "Qüinquagésimo", "Sexagésimo", "Septuagésimo", "Octogésimo", "Nonagésimo" };

                return $"{dezena[Convert.ToInt16(valor.Substring(0, 1))]} {unidade[Convert.ToInt16(valor.Substring(1, 1))]}".Trim();
            }

            return string.Empty;
        }

        public static string PrimeiroCaracter<T>(this T value)
        {
            return value.ToString().Substring(0, 1).ToUpper();
        }

        public static string RemoverCaracteresEspeciais(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            string caracteres = ",.;:<>/_-[]{}%&$#@!*()";
            for (int i = 0; i < caracteres.Length; i++)
            {
                value = value.Replace(caracteres.Substring(i, 1), "");
            }

            return value;
        }

        public static string QueryString(this object value)
        {
            List<string> querys = new List<string>();
            var propriedades = value.GetType().GetProperties();
            foreach (var propriedade in propriedades)
            {
                querys.Add($"{propriedade.Name}={value.GetType().GetProperty(propriedade.Name).GetValue(value, null)}");
            }

            return string.Join("&", querys);
        }

        public static string NuloRetornarTracos(this object value)
        {
            if (value == null)
            {
                return "---";
            }

            return value.ToString();
        }

        public static string InserirParagrafoHtml(this string value)
        {
            string novoParagrafoHtml = "</p><p style=\"text-align:justify;margin-bottom:0px;\">";

            value = value.Replace("\n\n", "\n&nbsp;\n");

            return $"{novoParagrafoHtml.Substring(4)}{value.Replace("\n", $"{novoParagrafoHtml}")}</p>";
        }

        public static string ExibirNivelQuestionario(this int value, bool exibir)
        {
            if (exibir)
                return $"{value} - ";

            return string.Empty;
        }

        public static string RetornarTamanhoDeBytes(this int value)
        {
            string[] tipoByte = { "bytes", "Kb", "Mb", "Gb", "Tb" };

            int i = 0;
            do
            {
                if (value < 1000)
                    return $"{value} {tipoByte[i]}";

                value = (int)Math.Truncate(value / 1000.0);

                i++;
            } while (i < 4);

            return $"{value} {tipoByte[i]}";
        }

        public static string RetornarBRchar10(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Replace("\r\n", "<br />").Replace("\n\r", "<br />").Replace("\r", "<br />").Replace("\n", "<br />");
        }

        public static string RetornarNomeDoMes(this int value)
        {
            if (value < 0)
                return "";

            if (value > 12)
                return "";

            return new[] { "", "Janeiro", "Fevereivo", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" }[value];
        }


        public static string MascaraTelefone(this string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Length == 11)
                value = "(" + value.Insert(2, ")").Insert(8, "-");
            if (value.Length == 10)
                value = "(" + value.Insert(2, ")").Insert(7, "-");
            return value;
        }
        public static string MascaraCEP(this string cep)
        {
            if (string.IsNullOrEmpty(cep)) return "";

            if (cep.Length == 8)
                cep = cep.Insert(5, "-");

            return cep;
        }

    }
}
