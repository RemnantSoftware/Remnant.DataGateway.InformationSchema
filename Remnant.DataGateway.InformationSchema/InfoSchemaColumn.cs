
using System;
using System.Collections.Generic;
using Remnant.Core.Attributes;
using Remnant.DataGateway.Attributes;
using Remnant.DataGateway.Core;
using Remnant.DataGateway.Interfaces;

namespace Remnant.DataGateway.InformationSchema
{
	[DbName(Name = "information_schema.COLUMNS")]
	public class InfoSchemaColumn : DbTableEntity<InfoSchemaColumn>	
	{
		public InfoSchemaColumn()
		{
			Usage = new List<InfoSchemaKeyColumnUsage>();
		}

		[DbField(Name = "table_schema")]
		public string TableSchema { get; set; }

		[DbField(Name="table_name")]
		public string TableName { get; set; }

		[DbField(Name = "table_catalog")]
		public string TableCatalog { get; set; }

		[DbField(Name = "column_name")]
		public string ColumnName { get; set; }

		[DbField(Name = "column_default")]
		public string ColumnDefault { get; set; }

		[DbField(Name = "is_nullable")]
		public string Nullable { get; set; }

		[DbField(Name = "data_type")]
		public string DataType { get; set; }
	
		[DbField(Name = "character_set_name")]
		public string CharacterSetName { get; set; }

		[DbField(Name = "collation_name")]
		public string CollationName { get; set; }

		#region Data Gateway specific

		public List<InfoSchemaKeyColumnUsage> Usage { get; set; }

		public MetaAttribute Meta { get; set; }

		public bool IsNullable
		{
			get {return Nullable == "YES"; }
		}

		#endregion
	}
}
