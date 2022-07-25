using System.Reflection;

namespace Our.Umbraco.Tables.ManifestFilters
{
	internal static class ManifestReader
	{
		public static string ReadManifest()
		{
			var assembly = Assembly.GetExecutingAssembly();
			const string resourceName = "Our.Umbraco.Tables.package.manifest";

			using Stream stream = assembly.GetManifestResourceStream(resourceName) ?? throw new InvalidOperationException();
			using StreamReader reader = new StreamReader(stream);
			string result = reader.ReadToEnd();
			return result;
		}
	}
}
