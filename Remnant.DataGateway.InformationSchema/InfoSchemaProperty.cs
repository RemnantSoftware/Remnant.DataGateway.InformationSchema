using Remnant.DataGateway.Attributes;
using Remnant.DataGateway.Core;
using Remnant.DataGateway.Interfaces;

namespace Remnant.DataGateway.InformationSchema
{
	public class InfoSchemaProperty : DbTableEntity<InfoSchemaProperty>
	{
		public string Name { get; set; }

		public object Value { get; set; }
	}
}
