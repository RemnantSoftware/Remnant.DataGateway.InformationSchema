using System;
using System.ComponentModel;

namespace Remnant.DataGateway.InformationSchema
{
	[Flags]
	public enum TableType
	{
		[Description("VIEW")]
		View = 1,
		[Description("BASE TABLE")]
		BaseTable = 2,
		[Description("SYSTEM VIEW")]
		SystemView = 4
	}

	public enum RoutineType
	{
		Procedure = 0,
		Function
	}
	
	public enum ConstraintType
	{
		[Description("UNIQUE")]
		Unique = 0,
		[Description("PRIMARY KEY")]
		PrimaryKey,
		[Description("FOREIGN KEY")]
		ForeignKey
	}

}
