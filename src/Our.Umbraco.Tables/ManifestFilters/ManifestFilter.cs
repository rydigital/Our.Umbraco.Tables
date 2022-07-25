using Umbraco.Cms.Core.Manifest;

namespace Our.Umbraco.Tables.ManifestFilters
{
	public class ManifestFilter : IManifestFilter
	{
		private readonly IManifestParser parser;

		public ManifestFilter(IManifestParser parser)
		{
			this.parser = parser;
		}

		void IManifestFilter.Filter(List<PackageManifest> manifests)
		{
			var manifestJson = ManifestReader.ReadManifest();
			var manifest = this.parser.ParseManifest(manifestJson);
			manifest.PackageName = "Our.Umbraco.Tables";
			manifests.Add(manifest);
		}
	}
}
