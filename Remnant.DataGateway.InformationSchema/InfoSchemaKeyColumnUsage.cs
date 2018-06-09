
using System;
using Remnant.DataGateway.Attributes;
using Remnant.DataGateway.Core;

namespace Remnant.DataGateway.InformationSchema
{
	/// <summary>
	/// Standard Ansi-Sql standard information schema for key column usage
	/// Non-standard fields are implemented in specific database derived classes
	/// </summary>
	[DbName(Name = "information_schema.KEY_COLUMN_USAGE")]
	public class InfoSchemaKeyColumnUsage : DbTableEntity<InfoSchemaKeyColumnUsage>
	{
		[DbField(Name = "constraint_catalog")]
		public string ConstraintCatalog { get; set; }

		[DbField(Name="constraint_schema")]
		public string ConstraintSchema { get; set; }

		[DbField(Name = "constraint_name")]
		public string ConstraintName { get; set; }

		[DbField(Name = "table_catalog")]
		public string TableCatalog { get; set; }

		[DbField(Name = "table_schema")]
		public string TableSchema { get; set; }

		[DbField(Name = "table_name")]
		public string TableName { get; set; }

		[DbField(Name = "column_name")]
		public string ColumnName { get; set; }

		[DbField(Name = "ordinal_position")]
		public Int32 OrdinalPosition { get; set; }
	}
}
