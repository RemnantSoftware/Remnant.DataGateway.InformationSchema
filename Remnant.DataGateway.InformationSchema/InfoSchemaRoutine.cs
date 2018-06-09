  
using System;
using System.Collections.Generic;
using Remnant.Core.Attributes;
using Remnant.DataGateway.Attributes;
using Remnant.DataGateway.Interfaces;
using Remnant.DataGateway.Core;

namespace Remnant.DataGateway.InformationSchema
{
  [DbName(Name = "information_schema.ROUTINES")]
	public class InfoSchemaRoutine : DbTableEntity<InfoSchemaRoutine>
  {
		[DbField(Name = "specific_name")]
		public string SpecificName { get; set; }

		[DbField(Name="routine_name")]
		public string RoutineName { get; set; }

		[DbField(Name = "routine_schema")]
		public string RoutineSchema { get; set; }

		[DbField(Name = "routine_catalog")]
		public string RoutineCatalog { get; set; }

		[DbField(Name = "routine_type")]
		public string RoutineType { get; set; }

		[DbField(Name = "data_type")]
		public string DataType { get; set; }
	
		[DbField(Name = "character_set_name")]
		public string CharacterSetName { get; set; }

		[DbField(Name = "collation_name")]
		public string CollationName { get; set; }

		[DbField(Name = "dtd_identifier")]
		public string DdtIdentifier { get; set; }

		[DbField(Name = "routine_body")]
		public string RoutineBody { get; set; }

		[DbField(Name = "routine_definition")]
		public string RoutineDefinition { get; set; }

		[DbField(Name = "external_name")]
		public string ExternalName { get; set; }

		[DbField(Name = "external_language")]
		public string ExternalLanguage { get; set; }

		[DbField(Name = "parameter_style")]
		public string ParameterStyle { get; set; }

		[DbField(Name = "is_deterministic")]
		public bool IsDetrministic { get; set; }

		[DbField(Name = "sql_data_access")]
		public string SqlDataAccess { get; set; }

		[DbField(Name = "sql_path")]
		public string SqlPath { get; set; }
	
		[DbField]
		public DateTime Created { get; set; }

		[DbField(Name="last_altered")]
		public DateTime LastAltered { get; set; }	

		#region Data Gateway specific

		public List<InfoSchemaParameter> Parameters { get; set; }

		public MetaAttribute Meta { get; set; }

		#endregion
	}
}
