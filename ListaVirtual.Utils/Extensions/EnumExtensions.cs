using System.ComponentModel;
using System.Reflection;

namespace FilaVirtual.Util.Extensions
{
    public static class EnumExtensions
	{
		public static Int32 GetValor(this Enum valorEnum)
		{
			return Convert.ToInt32(valorEnum);
		}

		public static String GetDescricao(this Enum valorEnum)
		{
			FieldInfo infoElemento = valorEnum.GetType().GetField(valorEnum.ToString());
			DescriptionAttribute[] atributos = (DescriptionAttribute[])infoElemento.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (atributos.Length > 0)
			{
				if (atributos[0].Description != null)
					return atributos[0].Description;
				else
					return string.Empty;
			}
			else
				return valorEnum.ToString();

		}

		public static List<Object> ListaObjectEnum(Type enumerador)
		{
			List<Object> lista = new List<Object>();

			if (enumerador != null)
			{
				Array enumValores = Enum.GetValues(enumerador);
				foreach (Enum valor in enumValores)
				{
					lista.Add(new { Valor = valor.GetValor(), Texto = valor.GetDescricao(), Enum = valor });
				}
			}
			return lista;
		}

		public static String GetValorPorDescricao(Type enumerador, String desc)
		{
			if (enumerador != null && desc != null && !desc.Equals(""))
			{
				Array enumValores = Enum.GetValues(enumerador);
				foreach (Enum valor in enumValores)
				{
					if (valor.GetDescricao().ToLower().Equals(desc.ToLower()))
					{
						return valor.GetValor().ToString();
					}
				}
			}
			return "";
		}

		public static Int32 GetValorNumPorValorString(Type enumerador, String desc)
		{
			if (enumerador != null && desc != null && !desc.Equals(""))
			{
				Array enumValores = Enum.GetValues(enumerador);
				foreach (Enum valor in enumValores)
				{
					if (valor.ToString().Equals(desc))
					{
						return valor.GetValor();
					}
				}
			}
			return 0;
		}
		public static String GetDescricaoPorNomeEnum(Type typeEnum, string nomeEnum)
		{
			if (typeEnum != null && nomeEnum != null && !nomeEnum.Equals(""))
			{
				List<object> listaEnumeradores = EnumExtensions.ListaObjectEnum(typeEnum);
				var enumerador = listaEnumeradores.Find((e) => e.GetType().GetProperty("Enum").GetValue(e).ToString() == nomeEnum);
				if (enumerador == null)
					return "";
				return enumerador.GetType().GetProperty("Texto").GetValue(enumerador).ToString();				
			}
			return "";
		}

		public static String GetDescricaoPorValor(Type enumerador, String val)
		{
			if (enumerador != null && val != null && !val.Equals(""))
			{
				Int32 value = Convert.ToInt32(val);
				Array enumValores = Enum.GetValues(enumerador);
				foreach (Enum valor in enumValores)
				{
					if (valor.GetValor() == value)
					{
						return valor.GetDescricao();
					}
				}
			}
			return "";
		}

	}
}
