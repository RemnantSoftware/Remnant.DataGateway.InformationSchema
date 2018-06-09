
using System;
using System.Data;
using Remnant.Core;
using Remnant.Core.Extensions;
using Remnant.DataGateway.Attributes;
using Remnant.DataGateway.Core;
using Remnant.DataGateway.Interfaces;

namespace Remnant.DataGateway.InformationSchema
{
	/// <summary>
	/// Weird, MySql returns int as Int32 but on others as UInt64
	/// </summary>
	[DbName(Name = "information_schema.PARAMETERS")]
	public class InfoSchemaParameter : DbTableEntity<InfoSchemaParameter>
  {
		[DbField(Name = "specific_name")]	
		public string RoutineName { get; set; }

		[DbField(Name="parameter_name")]
		public string ParameterName { get; set; }

		[DbField(Name = "specific_schema")]
		public string SpecificSchema { get; set; }

		[DbField(Name = "specific_catalog")]
		public string SpecificCatalog { get; set; }

		[DbField(Name = "ordinal_position")]
		public Int32 OrdinalPosition { get; set; }

		[DbField(Name = "parameter_mode")]
		public string ParameterMode { get; set; }

		[DbField(Name = "data_type")]
		public string DataType { get; set; }	

		[DbField(Name = "character_set_name")]
		public string CharacterSetName { get; set; }

		[DbField(Name = "collation_name")]
		public string CollationName { get; set; }

		[DbField(Name = "character_maximum_length")]
		public Int32? CharacterMaxLength { get; set; }

		[DbField(Name = "character_octet_length")]
		public Int32? CharacterOctetLength { get; set; }

		[DbField(Name = "numeric_scale")]
		public Int32? NumericScale { get; set; }

		public virtual string NetName
		{
			get { return ParameterName; }
		}
	
		public ParameterDirection Direction
		{
			get
			{
				switch (ParameterMode)
				{					
					case "OUT": return ParameterDirection.Output;
					case "INOUT": return ParameterDirection.InputOutput;
					default: return ParameterDirection.Input;
				}
			}
		}

	}
}
