using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Serialization;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.Tables.Components
{
	public class OurUmbracoTablesRteComponent : IComponent
	{
		private readonly IDataTypeService _dataTypeService;
		private readonly IConfigurationEditorJsonSerializer _configurationEditorJsonSerializer;
		private readonly PropertyEditorCollection _propertyEditorCollection;

		public OurUmbracoTablesRteComponent(IDataTypeService dataTypeService, IConfigurationEditorJsonSerializer configurationEditorJsonSerializer, PropertyEditorCollection propertyEditorCollection)
		{
			this._dataTypeService = dataTypeService;
			this._configurationEditorJsonSerializer = configurationEditorJsonSerializer;
			this._propertyEditorCollection = propertyEditorCollection;
		}

		public void Initialize()
		{
			CreateRteDataType();
		}

		public void Terminate(){}

		private void CreateRteDataType()
		{
			if (_dataTypeService.GetDataType(Constants.DataTypeName) != null || !_propertyEditorCollection.TryGet(global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TinyMce, out var editor))
			{
				return;
			}

			var ourUmbracoTablesRte = new DataType(editor, _configurationEditorJsonSerializer)
			{
				Name = Constants.DataTypeName,
				Configuration = new RichTextConfiguration
				{
					Editor = Newtonsoft.Json.Linq.JObject.FromObject(new Dictionary<string, object>
					{
						["toolbar"] = new[] { 
							"ace", 
							"bold", 
							"italic",
							"alignleft",
							"aligncenter",
							"alignright", 
							"bullist", 
							"numlist", 
							"link",
							"umbmediapicker"
						},
						["stylesheets"] = Array.Empty<string>(),
						["maxImageSize"] = 500,
						["mode"] = "classic"
					}),
					HideLabel = false,
					IgnoreUserStartNodes = false,
					MediaParentId = null
				}
			};

			_dataTypeService.Save(ourUmbracoTablesRte);
		}
	}
}
