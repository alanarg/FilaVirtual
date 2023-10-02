
using Newtonsoft.Json;
using System.Globalization;

namespace FilaVirtual.Util.DateTimeConverter
{
	public class DateTimeConverter : JsonConverter<DateTime>
	{
		public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			if (reader.Value != null && !string.IsNullOrWhiteSpace(reader.Value.ToString()))
			{
				if (reader.Value.ToString().Length > 10)
				{
					return DateTime.ParseExact(reader.Value.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
				}
				else
				{
					return DateTime.ParseExact(reader.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
				}
			}
			else
			{
				return DateTime.Now;
			}
		}

		public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
		{
			writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy HH:mm:ss"));
		}
	}
}
