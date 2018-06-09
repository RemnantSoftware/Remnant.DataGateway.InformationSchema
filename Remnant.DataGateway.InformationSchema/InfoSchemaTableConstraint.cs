
using Remnant.DataGateway.Attributes;
using Remnant.DataGateway.Core;
using Remnant.DataGateway.Interfaces;

namespace Remnant.DataGateway.InformationSchema
{
  /// <summary>
  /// Standard Ansi-Sql standard information schema for table constraints
  /// Non-standard fields are implemented in specific database derived classes
  /// </summary>
  [DbName(Name = "information_schema.TABLE_CONSTRAINTS")]
	public class InfoSchemaTableConstraint : DbTableEntity<InfoSchemaTableConstraint>
	{
		[DbField(Name = "constraint_catalog")]
		public string ConstraintCatalog { get; set; }

		[DbField(Name="constraint_schema")]
		public string ConstraintSchema { get; set; }

		[DbField(Name = "constraint_name")]
		public string ConstraintName { get; set; }

		[DbField(Name = "constraint_type")]
		public string ConstraintType { get; set; }

		[DbField(Name = "table_schema")]
		public string TableSchema { get; set; }

		[DbField(Name = "table_name")]
		public string TableName { get; set; }

		
	}
}
