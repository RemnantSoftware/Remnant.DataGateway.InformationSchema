using Remnant.Core.Attributes;
using Remnant.Core.Extensions;
using Remnant.Core.Services;
using Remnant.DataGateway.Core;
using Remnant.DataGateway.Interfaces;
using System;

using System.Collections.Generic;

namespace Remnant.DataGateway.InformationSchema
{
	public abstract class InfoSchema<TDataTypeEnum> : DbSchema<TDataTypeEnum>
		where TDataTypeEnum : struct
	{

    protected InfoSchema(IDbManager dbManager) : base(dbManager)
    {
    }

		protected static MetaAttribute CreateMetaFromExtProps(List<InfoSchemaProperty> extendedProperties)
		{
			var meta = new MetaAttribute();
			foreach (var extendedProperty in extendedProperties)
			{
				var propInfo = ReflectionService.GetProperty(meta, extendedProperty.Name, true);
				if (propInfo != null)
				{
					var value = Convert.ChangeType(extendedProperty.Value, propInfo.PropertyType.UnderlyingSystemType);
					propInfo.SetValue(meta, value, null);
				}
			}
			return meta;
		}
		
		protected List<InfoSchemaKeyColumnUsage> FetchKeyColumnUsage<TSchemaColumn>(TSchemaColumn column)
			where TSchemaColumn : InfoSchemaColumn
		{
			return _dbManager.Sql()
				.Select()
				.AllColumns()
				.From
				.Table<InfoSchemaKeyColumnUsage>("KeyUsage")
				.Where
				.Criteria("TableSchema", SqlOperand.Equal, column.TableSchema)
				.Criteria("TableCatalog", SqlOperand.Equal, column.TableCatalog)
				.Criteria("TableName", SqlOperand.Equal, column.TableName)
				.Criteria("ColumnName", SqlOperand.Equal, column.ColumnName)
				.OrderBy
				.Column("OrdinalPosition")
				.Execute<InfoSchemaKeyColumnUsage>();
		}

		protected List<TSchemaColumn> FetchTableColumns<TSchemaColumn>(InfoSchemaTable table)
			where TSchemaColumn : InfoSchemaColumn, new()
		{
			return _dbManager.Sql()
        .Select()
				.AllColumns()
				.From
				.Table<TSchemaColumn>("Columns")
				.Where
				.Criteria("TableSchema", SqlOperand.Equal, table.TableSchema)
				.Criteria("TableCatalog", SqlOperand.Equal, table.TableCatalog)
				.Criteria("TableName", SqlOperand.Equal, table.TableName)
				.OrderBy
				.Column("OrdinalPosition")
				.Execute<TSchemaColumn>();
		}

		protected List<TInfoSchemaParameter> FetchStoredProcParameters<TInfoSchemaParameter>(InfoSchemaRoutine sproc)
			where TInfoSchemaParameter : InfoSchemaParameter, new()
		{
			return _dbManager.Sql()
        .Select()
				.AllColumns()
				.From
				.Table<TInfoSchemaParameter>("Parameters")
				.Where
				.Criteria("SpecificSchema", SqlOperand.Equal, sproc.RoutineSchema)
				.Criteria("SpecificCatalog", SqlOperand.Equal, sproc.RoutineCatalog)
				.Criteria("RoutineName", SqlOperand.Equal, sproc.RoutineName)
				.OrderBy
				.Column("OrdinalPosition")
				.Execute<TInfoSchemaParameter>();
		}

		protected virtual List<TInfoSchemaRoutine> FetchUserStoredProcs<TInfoSchemaRoutine, TInfoSchemaParameter>(string schema, string catalog = null, params string[] ignoreStoredProcs)
				where TInfoSchemaRoutine : InfoSchemaRoutine, new()
				where TInfoSchemaParameter : InfoSchemaParameter, new()
		{
			var sql = _dbManager.Sql()
        .Select()
				.AllColumns()
				.From
				.Table<TInfoSchemaRoutine>("Routines")
				.Where
				.Criteria("RoutineSchema", SqlOperand.Equal, schema);

			if (catalog != null)
				sql.Criteria("RoutineCatalog", SqlOperand.Equal, catalog);

			foreach (var ignoreStoredProc in ignoreStoredProcs)
				sql.Criteria("RoutineName", SqlOperand.NotLike, ignoreStoredProc);

			var sprocs = sql.Execute<TInfoSchemaRoutine>();
			sprocs.ForEach(sproc =>
				sproc.Parameters = FetchStoredProcParameters<TInfoSchemaParameter>(sproc).ConvertAll(t => (InfoSchemaParameter)t));
			return sprocs;
		}

		protected List<TSchemaConstraint> FetchTableConstraints<TSchemaConstraint>(InfoSchemaTable table)
		where TSchemaConstraint : InfoSchemaTableConstraint, new()
		{
      return _dbManager.Sql()
        .Select()
				.AllColumns()
				.From
				.Table<TSchemaConstraint>("Constraints")
				.Where
				.Criteria("ConstraintSchema", SqlOperand.Equal, table.TableSchema)
				.Criteria("ConstraintCatalog", SqlOperand.Equal, table.TableCatalog)
				.Criteria("TableName", SqlOperand.Equal, table.TableName)
				.Execute<TSchemaConstraint>();
		}

		protected List<TSchemaTable> FetchUserTables<TSchemaTable>(string schema, string catalog = null, params string[] ignoreTables)
			where TSchemaTable : InfoSchemaTable, new()
		{
			var sql = _dbManager.Sql()
        .Select()
				.AllColumns()
				.From
				.Table<TSchemaTable>("tables")
				.Where
				.Criteria("TableSchema", SqlOperand.Equal, schema)
				.Criteria("TableType", SqlOperand.Equal, TableType.BaseTable.ToDescription());

			if (catalog != null)
				sql.Criteria("TableCatalog", SqlOperand.Equal, catalog);

			if (ignoreTables.Length > 0)
				sql.Criteria("TableName", SqlOperand.NotIn, ignoreTables);

			return sql.Execute<TSchemaTable>();
		}

		protected List<TSchemaTable> FetchUserViews<TSchemaTable>(string schema, string catalog = null, params string[] ignoreViews)
			where TSchemaTable : InfoSchemaTable, new()
		{
			throw new NotImplementedException();
		}
	}
}
