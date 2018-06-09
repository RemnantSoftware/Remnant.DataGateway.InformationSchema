using System.Collections.Generic;
using System.Linq;
using Remnant.Core;
using Remnant.Core.Attributes;
using Remnant.Core.Extensions;
using Remnant.DataGateway.Attributes;
using Remnant.DataGateway.Interfaces;
using Remnant.DataGateway.Core;

namespace Remnant.DataGateway.InformationSchema
{
  /// <summary>
  /// Standard Ansi-Sql standard information schema for tables
  /// Non-standard fields are implemented in specific database derived classes
  /// </summary>
  [DbName(Name = "information_schema.TABLES")]
	public class InfoSchemaTable : DbTableEntity<InfoSchemaTable>
  {
		public InfoSchemaTable()
		{
			Meta = new MetaAttribute();
		}

		[DbField(Name = "table_schema")]
		public string TableSchema { get; set; }

		[DbField(Name="table_name")]
		public string TableName { get; set; }

		[DbField(Name = "table_catalog")]
		public string TableCatalog { get; set; }

		[DbField(Name = "table_type")]
		public string TableType { get; set; }

		#region Data Gateway specific

		public List<InfoSchemaTableConstraint> Constraints { get; set; }

		public List<InfoSchemaColumn> Columns { get; set; }

		public MetaAttribute Meta { get; set; }

		public bool IsColumnPrimaryKey(InfoSchemaColumn column)
		{
			var x = (from colUsage in column.Usage
			         from constraint in Constraints
			         where colUsage.ConstraintName == constraint.ConstraintName &&
			               constraint.ConstraintType == ConstraintType.PrimaryKey.ToDescription()
			         select true).SingleOrDefault();
			return x;
		}

		public bool IsColumnForeignKey(InfoSchemaColumn column)
		{
			var x = (from colUsage in column.Usage
							 from constraint in Constraints
							 where colUsage.ConstraintName == constraint.ConstraintName &&
										 constraint.ConstraintType == ConstraintType.ForeignKey.ToDescription()
							 select true).SingleOrDefault();
			return x;
		}

		public bool IsColumnUnique(InfoSchemaColumn column)
		{
			var x = (from colUsage in column.Usage
							 from constraint in Constraints
							 where colUsage.ConstraintName == constraint.ConstraintName &&
										 constraint.ConstraintType == ConstraintType.Unique.ToDescription()
							 select true).SingleOrDefault();
			return x;
		}

		public string NetTableName
		{
			get { return TableName.ToCase(Case.Pascal); }
		}

		#endregion
	}
}
