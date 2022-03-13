using System;

namespace ApprenticeNET
{
    /// <summary>
    /// Summary description for ContentManager.
    /// </summary>
    public class ContentManager : ManagerObject
	{
		public ContentManager() :base()
		{
		}
		public ContentManager(string sName) :base(sName)
		{
		}
		public virtual void SetUnitsToIPS()
		{
			UnitCategory oCategory;

			oCategory = UnitCategory("Length","in");
			UnitsU("in","inches",oCategory);
			UnitsU("ft","feet",oCategory);
			UnitsU("m","meters",oCategory);
			UnitsU("mm","millimeters",oCategory);
			oCategory.Conversion(12,"in",1,"ft");
			oCategory.Conversion(0.0254,"m",1,"in");
			oCategory.Conversion(25.4,"mm",1,"in");

			oCategory = UnitCategory("Angle","rad");
			UnitsU("rad","radians",oCategory);
			UnitsU("deg","degees",oCategory);
			UnitsU("rev","revolution",oCategory);
			oCategory.Conversion(180,"deg",System.Math.PI,"rad");
			oCategory.Conversion(1,"rev",2 * System.Math.PI,"rad");
			oCategory.Conversion(1,"rev",360,"deg");

			oCategory = UnitCategory("Time","sec");
			UnitsU("sec","seconds",oCategory);
			UnitsU("min","minutes",oCategory);
			UnitsU("hr","hours",oCategory);
			oCategory.Conversion(60,"sec",1,"min");
			oCategory.Conversion(60*60,"sec",1,"hr");

			oCategory = UnitCategory("Quantity","ea");
			UnitsU("ea","each",oCategory);
			UnitsU("%","percent",oCategory);
			oCategory.Conversion(1,"ea",100,"%");

			oCategory = UnitCategory("Mass","lb-sec2/in");
			UnitsU("lb-sec2/in","pounds sec2 per inch",oCategory);
			UnitsU("lbm","pounds mass",oCategory);
			oCategory.Conversion(386.089,"lbm",1,"lb-sec2/in");

			oCategory = UnitCategory("Force","lb");
			UnitsU("lb","pounds",oCategory);

			oCategory = UnitCategory("Velocity","in/sec");
			UnitsU("in/sec","inches per second",oCategory);
			UnitsU("ft/sec","feet per second",oCategory);
			UnitsU("ft/min","feet per minute",oCategory);
			oCategory.Conversion(12,"in/sec",1,"ft/sec");
			oCategory.Conversion(1,"in/sec",5,"ft/min");

			oCategory = UnitCategory("AngularVelocity","rad/sec");
			UnitsU("rad/sec","radians per second",oCategory);
			UnitsU("rev/sec","revolutions per second",oCategory);
			UnitsU("rpm","revolutions per minute",oCategory);
			oCategory.Conversion(2*System.Math.PI,"rad/sec",1,"rev/sec");
			oCategory.Conversion(1,"rpm",System.Math.PI/30,"rad/sec");

			oCategory = UnitCategory("Area","in2");
			oCategory.Conversion(12 * 12,"in2",1,"ft2");
			oCategory.Conversion(1,"in2",0.0254 * 0.0254,"M2");
			oCategory.Conversion(1,"in2", 25.4 * 25.4, "mm2");
			UnitsU("in2","square inches",oCategory);
			UnitsU("ft2","square feet",oCategory);
			UnitsU("M2","square meters",oCategory);
			UnitsU("mm2","square millimeters",oCategory);

			oCategory = UnitCategory("Volume","in3");
			UnitsU("in3","cubic inches",oCategory);
			UnitsU("ft3","cubic feet",oCategory);
			UnitsU("M3","cubic meters",oCategory);
			UnitsU("mm3","cubic millimeters",oCategory);
			oCategory.Conversion(12*12*12,"in3",1,"ft3");
			oCategory.Conversion(1,"in3",0.0254 * 0.0254 * 0.0254,"M3");
			oCategory.Conversion(1,"in3",25.4 * 25.4 * 25.4,"mm3");

			oCategory = UnitCategory("Torque","in-lbs");
			UnitsU("in-lbs","inch pounds",oCategory);
			UnitsU("ft-lbs","foot pounds",oCategory);
			oCategory.Conversion(12,"in-lbs",1,"ft-lbs");

			oCategory = UnitCategory("Power","in-lbs/sec");
			UnitsU("in-lbs/sec","inch pounds per second",oCategory);
			UnitsU("hp","horsepower",oCategory);
			oCategory.Conversion(6600,"in-lbs/sec",1,"hp");

			oCategory = UnitCategory("PowerFlux","in-lb/sec-in2");
			UnitsU("in-lb/sec-in2","inch pounds per second squared inch",oCategory);
			UnitsU("ft-lb/min-in2","foot pounds per minute squared inch",oCategory);
			oCategory.Conversion(1,"in-lb/sec-in2",5,"ft-lb/min-in2");

			oCategory = UnitCategory("Pressure","psi");
			UnitsU("psi","pounds per square inch",oCategory);
			UnitsU("kpsi","kilo pounds per square inch",oCategory);
			UnitsU("Pa","Pascals",oCategory);
			UnitsU("MPa","MegaPascals",oCategory);
			UnitsU("lb/ft2","pounds per square feet",oCategory);
			oCategory.Conversion(6894.7573,"Pa",1,"psi");
			oCategory.Conversion(.0068947573,"MPa",1,"psi");
			oCategory.Conversion(1,"kpsi",1000,"psi");
			oCategory.Conversion(1.0,"lb/ft2",1.0/144.0,"psi");

			oCategory = UnitCategory("Temperature","F");
			UnitsU("F","degees",oCategory);

			UnitCategoryU("Acceleration");
			oCategory = UnitCategory("Acceleration","in/sec2");
			UnitsU("in/sec2","inch per square second",oCategory);

			oCategory = UnitCategory("AngularAcceleration","rad/sec2");
			UnitsU("rad/sec2","radians per square second",oCategory);

			oCategory = UnitCategory("Density","lbm/in3");
			UnitsU("lbm/in3","pounds mass per cubic inch",oCategory);
		}

		public virtual void SetUnitsToMKS()
		{
//			//this is mmks
//			UnitCategory oCategory;
//
//			oCategory = UnitCategory("Length","mm");
//			UnitsU("in","inches",oCategory);
//			UnitsU("ft","feet",oCategory);
//			UnitsU("m","meters",oCategory);
//			UnitsU("mm","millimeters",oCategory);
//			oCategory.Conversion(1.0,"in",25.4,"mm");
//			oCategory.Conversion(1.0,"ft",304.8,"mm");
//			oCategory.Conversion(1.0,"m",1000.0,"mm");
//
//			oCategory = UnitCategory("Angle","rad");
//			UnitsU("rad","radians",oCategory);
//			UnitsU("deg","degees",oCategory);
//			UnitsU("rev","revolution",oCategory);
//			oCategory.Conversion(180.0,"deg",System.Math.PI,"rad");
//			oCategory.Conversion(1.0,"rev",2.0 * System.Math.PI,"rad");
//			oCategory.Conversion(1.0,"rev",360.0,"deg");
//
//			oCategory = UnitCategory("Time","sec");
//			UnitsU("sec","seconds",oCategory);
//			UnitsU("min","minutes",oCategory);
//			UnitsU("hr","hours",oCategory);
//			oCategory.Conversion(60,"sec",1,"min");
//			oCategory.Conversion(3600,"sec",1,"hr");
//
//			oCategory = UnitCategory("Quantity","ea");
//			UnitsU("ea","each",oCategory);
//			UnitsU("%","percent",oCategory);
//			oCategory.Conversion(1,"ea",100,"%");
//
//			oCategory = UnitCategory("Mass","tonne");
//			UnitsU("tonne","metric ton",oCategory);
//			UnitsU("lbf-sec^2/in","pounds second squared per inch",oCategory);
//			UnitsU("lbm","pounds mass",oCategory);
//			UnitsU("kg","kilograms",oCategory);
//			oCategory.Conversion(2204.62262,"lbm",1,"tonne");
//			oCategory.Conversion(5.71014715,"lbf-sec^2/in",1,"tonne");
//			oCategory.Conversion(1000.0,"kg",1,"tonne");
//
//			oCategory = UnitCategory("Force","N");
//			UnitsU("N","newtons",oCategory);
//			UnitsU("lbf","pounds force",oCategory);
//			oCategory.Conversion(1.0,"lbf",4.44822162,"N");
//
//			oCategory = UnitCategory("Velocity","mm/sec");
//			UnitsU("mm/sec","millimeters per second",oCategory);
//			UnitsU("m/sec","meters per second",oCategory);
//			UnitsU("in/sec","inches per second",oCategory);
//			UnitsU("ft/sec","feet per second",oCategory);
//			UnitsU("ft/min","feet per minute",oCategory);
//			oCategory.Conversion(1.0,"m/sec",1000.0,"mm/sec");
//			oCategory.Conversion(1.0,"in/sec",25.4,"mm/sec");
//			oCategory.Conversion(1.0,"ft/sec",304.8,"mm/sec");
//			oCategory.Conversion(1.0,"ft/min",5.08,"mm/sec");
//
//			oCategory = UnitCategory("AngularVelocity","rad/sec");
//			UnitsU("rad/sec","radians per second",oCategory);
//			UnitsU("rev/sec","revolutions per second",oCategory);
//			UnitsU("rpm","revolutions per minute",oCategory);
//			oCategory.Conversion(2*System.Math.PI,"rad/sec",1,"rev/sec");
//			oCategory.Conversion(1.0,"rpm",System.Math.PI/30,"rad/sec");
//
//			oCategory = UnitCategory("Area","mm^2");
//			UnitsU("mm^2","millimeters squared",oCategory);
//			UnitsU("m^2","meters squared",oCategory);
//			UnitsU("in^2","inches squared",oCategory);
//			UnitsU("ft^2","feet squared",oCategory);
//			oCategory.Conversion(1.0,"in^2",645.16,"mm^2");
//			oCategory.Conversion(1.0,"ft^2",92903.04,"mm^2");
//			oCategory.Conversion(1.0,"m^2",1000000.0,"mm^2");
//
//			oCategory = UnitCategory("Volume","mm^3");
//			UnitsU("mm^3","millimeters cubed",oCategory);
//			UnitsU("in^3","inches cubed",oCategory);
//			UnitsU("ft^3","feet cubed",oCategory);
//			UnitsU("m^3","meters cubed",oCategory);
//			oCategory.Conversion(1728.0,"in^3",1.0 ,"mm^3");
//			oCategory.Conversion(1.0,"ft^3",28316846.6,"mm^3");
//			oCategory.Conversion(1.0,"m^3",1000000000.0,"mm^3");
//
//			oCategory = UnitCategory("Torque","N-mm");
//			UnitsU("N-mm","newton millimeters",oCategory);
//			UnitsU("N-m","newton meters",oCategory);
//			UnitsU("lbf-in","pounds force inches",oCategory);
//			UnitsU("lbf-ft","pounds force feet",oCategory);
//			oCategory.Conversion(1.0,"lbf-in",112.984829,"N-mm");
//			oCategory.Conversion(1.0,"lbf-ft",1355.81795,"N-mm");
//			oCategory.Conversion(1.0,"N-m",1000.0,"N-mm");
//
//			oCategory = UnitCategory("Power","mm-N/sec");
//			UnitsU("N-mm/sec","newton mm per second",oCategory);
//			UnitsU("N-m/sec","newton meters per second (Watts)",oCategory);
//			UnitsU("W","Watts",oCategory); // N-m/sec
//			UnitsU("in-lbf/sec","inch pounds force per second",oCategory);
//			UnitsU("hp","horsepower",oCategory);
//			oCategory.Conversion(1.0,"W",1000.0,"N-mm/sec");
//			oCategory.Conversion(1.0,"N-m/sec",1000.0,"N-mm/sec");
//			oCategory.Conversion(1.0,"in-lbf/sec",112.984829,"N-mm/sec");
//			oCategory.Conversion(1.0,"hp",745699.872 ,"N-mm/sec");
//
//			oCategory = UnitCategory("PowerFlux","mm-N/sec-mm^2");
//			UnitsU("mm-N/sec-mm^2","millimeter newton per second millimeter squared",oCategory);
//			UnitsU("m-N/sec-m^2","meter newton per second meter squared",oCategory);
//			UnitsU("in-lbf/sec-in^2","inch pounds force per second inch squared",oCategory);
//			UnitsU("ft-lbf/min-in^2","foot pounds force per minute inch squared",oCategory);
//			oCategory.Conversion(1.0,"m-N/sec-m^2",1000.0,"mm-N/sec-mm^2");
//			oCategory.Conversion(1.0,"in-lbf/sec-in^2",72893.2923,"mm-N/sec-mm^2");
//			oCategory.Conversion(1.0,"ft-lbf/min-ft^2",6074.441025,"mm-N/sec-mm^2");
//
//			oCategory = UnitCategory("Pressure","psi");
//			UnitsU("MPa","MegaPascals",oCategory);
//			UnitsU("N/mm^2","newtons per millimeters squared (MPa)",oCategory);
//			UnitsU("psi","pounds force per inch squared",oCategory);
//			UnitsU("kpsi","kilo pounds per inch squared",oCategory);
//			UnitsU("lb/ft2","pounds per square feet",oCategory);
//			UnitsU("Pa","Pascals",oCategory);
//			oCategory.Conversion(1.0,"MPa",1.0,"N/mm^2");
//			oCategory.Conversion(1000000.0,"Pa",1,"N/mm^2");
//			oCategory.Conversion(145.037738,"psi",1.0,"N/mm^2");
//			oCategory.Conversion(145.037738/144.0,"lb/ft2",1.0,"N/mm^2");
//			oCategory.Conversion(0.145037738,"kpsi",1.0,"N/mm^2");
//
//			oCategory = UnitCategory("Temperature","C");
//			UnitsU("C","degees",oCategory);
//
//			UnitCategoryU("Acceleration");
//			oCategory = UnitCategory("Acceleration","mm/sec^2");
//			UnitsU("mm/sec^2","millimeters per second squared",oCategory);
//			UnitsU("m/sec^2","meters per second squared",oCategory);
//			UnitsU("ft/sec^2","feet per second squared",oCategory);
//			UnitsU("in/sec^2","inches per second squared",oCategory);
//			oCategory.Conversion(1.0,"m/sec^2",1000.0,"mm/sec^2");
//			oCategory.Conversion(1.0,"ft/sec^2",304.8,"mm/sec^2");
//			oCategory.Conversion(1.0,"in/sec^2",25.4,"mm/sec^2");
//
//			oCategory = UnitCategory("AngularAcceleration","rad/sec^2");
//			UnitsU("rad/sec^2","radians per second squared",oCategory);
//			UnitsU("deg/sec^2","degrees per second squared",oCategory);
//			oCategory.Conversion(57.2957795,"deg/sec^2",1.0,"rad/sec^2");
//
//			oCategory = UnitCategory("Density","tonne/mm^3");
//			UnitsU("tonne/mm^3","metric tonne per millimeter cubed",oCategory);
//			UnitsU("lbm/in^3","pounds mass per inch cubed",oCategory);
//			oCategory.Conversion(36127292.0,"lbm/in^3",1.0,"tonne/mm^3");
		}
		public virtual void SetUnitsToCGS()
		{
		}
		public virtual void SetUnitsToFPS()
		{
		}
		public virtual void SetUnitsTommNs()
		{
			UnitCategory oCategory;

			oCategory = UnitCategory("Length","mm");
			UnitsU("in","inches",oCategory);
			UnitsU("ft","feet",oCategory);
			UnitsU("m","meters",oCategory);
			UnitsU("mm","millimeters",oCategory);
			oCategory.Conversion(1.0,"in",25.4,"mm");
			oCategory.Conversion(1.0,"ft",304.8,"mm");
			oCategory.Conversion(1.0,"m",1000.0,"mm");

			oCategory = UnitCategory("Angle","rad");
			UnitsU("rad","radians",oCategory);
			UnitsU("deg","degees",oCategory);
			UnitsU("rev","revolution",oCategory);
			oCategory.Conversion(180.0,"deg",System.Math.PI,"rad");
			oCategory.Conversion(1.0,"rev",2.0 * System.Math.PI,"rad");
			oCategory.Conversion(1.0,"rev",360.0,"deg");

			oCategory = UnitCategory("Time","sec");
			UnitsU("sec","seconds",oCategory);
			UnitsU("min","minutes",oCategory);
			UnitsU("hr","hours",oCategory);
			oCategory.Conversion(60,"sec",1,"min");
			oCategory.Conversion(3600,"sec",1,"hr");

			oCategory = UnitCategory("Quantity","ea");
			UnitsU("ea","each",oCategory);
			UnitsU("%","percent",oCategory);
			oCategory.Conversion(1,"ea",100,"%");

			oCategory = UnitCategory("Mass","tonne");
			UnitsU("tonne","metric ton",oCategory);
			UnitsU("lbf-sec^2/in","pounds second squared per inch",oCategory);
			UnitsU("lbm","pounds mass",oCategory);
			UnitsU("kg","kilograms",oCategory);
			oCategory.Conversion(2204.62262,"lbm",1,"tonne");
			oCategory.Conversion(5.71014715,"lbf-sec^2/in",1,"tonne");
			oCategory.Conversion(1000.0,"kg",1,"tonne");

			oCategory = UnitCategory("Force","N");
			UnitsU("N","newtons",oCategory);
			UnitsU("lbf","pounds force",oCategory);
			oCategory.Conversion(1.0,"lbf",4.44822162,"N");

			oCategory = UnitCategory("Velocity","mm/sec");
			UnitsU("mm/sec","millimeters per second",oCategory);
			UnitsU("m/sec","meters per second",oCategory);
			UnitsU("in/sec","inches per second",oCategory);
			UnitsU("ft/sec","feet per second",oCategory);
			UnitsU("ft/min","feet per minute",oCategory);
			oCategory.Conversion(1.0,"m/sec",1000.0,"mm/sec");
			oCategory.Conversion(1.0,"in/sec",25.4,"mm/sec");
			oCategory.Conversion(1.0,"ft/sec",304.8,"mm/sec");
			oCategory.Conversion(1.0,"ft/min",5.08,"mm/sec");

			oCategory = UnitCategory("AngularVelocity","rad/sec");
			UnitsU("rad/sec","radians per second",oCategory);
			UnitsU("rev/sec","revolutions per second",oCategory);
			UnitsU("rpm","revolutions per minute",oCategory);
			oCategory.Conversion(2*System.Math.PI,"rad/sec",1,"rev/sec");
			oCategory.Conversion(1.0,"rpm",System.Math.PI/30,"rad/sec");

			oCategory = UnitCategory("Area","mm^2");
			UnitsU("mm^2","millimeters squared",oCategory);
			UnitsU("m^2","meters squared",oCategory);
			UnitsU("in^2","inches squared",oCategory);
			UnitsU("ft^2","feet squared",oCategory);
			oCategory.Conversion(1.0,"in^2",645.16,"mm^2");
			oCategory.Conversion(1.0,"ft^2",92903.04,"mm^2");
			oCategory.Conversion(1.0,"m^2",1000000.0,"mm^2");

			oCategory = UnitCategory("Volume","mm^3");
			UnitsU("mm^3","millimeters cubed",oCategory);
			UnitsU("in^3","inches cubed",oCategory);
			UnitsU("ft^3","feet cubed",oCategory);
			UnitsU("m^3","meters cubed",oCategory);
			oCategory.Conversion(1728.0,"in^3",1.0 ,"mm^3");
			oCategory.Conversion(1.0,"ft^3",28316846.6,"mm^3");
			oCategory.Conversion(1.0,"m^3",1000000000.0,"mm^3");

			oCategory = UnitCategory("Torque","N-mm");
			UnitsU("N-mm","newton millimeters",oCategory);
			UnitsU("N-m","newton meters",oCategory);
			UnitsU("lbf-in","pounds force inches",oCategory);
			UnitsU("lbf-ft","pounds force feet",oCategory);
			oCategory.Conversion(1.0,"lbf-in",112.984829,"N-mm");
			oCategory.Conversion(1.0,"lbf-ft",1355.81795,"N-mm");
			oCategory.Conversion(1.0,"N-m",1000.0,"N-mm");

			oCategory = UnitCategory("Power","mm-N/sec");
			UnitsU("N-mm/sec","newton mm per second",oCategory);
			UnitsU("N-m/sec","newton meters per second (Watts)",oCategory);
			UnitsU("W","Watts",oCategory); // N-m/sec
			UnitsU("in-lbf/sec","inch pounds force per second",oCategory);
			UnitsU("hp","horsepower",oCategory);
			oCategory.Conversion(1.0,"W",1000.0,"N-mm/sec");
			oCategory.Conversion(1.0,"N-m/sec",1000.0,"N-mm/sec");
			oCategory.Conversion(1.0,"in-lbf/sec",112.984829,"N-mm/sec");
			oCategory.Conversion(1.0,"hp",745699.872 ,"N-mm/sec");

			oCategory = UnitCategory("PowerFlux","mm-N/sec-mm^2");
			UnitsU("mm-N/sec-mm^2","millimeter newton per second millimeter squared",oCategory);
			UnitsU("m-N/sec-m^2","meter newton per second meter squared",oCategory);
			UnitsU("in-lbf/sec-in^2","inch pounds force per second inch squared",oCategory);
			UnitsU("ft-lbf/min-in^2","foot pounds force per minute inch squared",oCategory);
			oCategory.Conversion(1.0,"m-N/sec-m^2",1000.0,"mm-N/sec-mm^2");
			oCategory.Conversion(1.0,"in-lbf/sec-in^2",72893.2923,"mm-N/sec-mm^2");
			oCategory.Conversion(1.0,"ft-lbf/min-ft^2",6074.441025,"mm-N/sec-mm^2");

			oCategory = UnitCategory("Pressure","psi");
			UnitsU("MPa","MegaPascals",oCategory);
			UnitsU("N/mm^2","newtons per millimeters squared (MPa)",oCategory);
			UnitsU("psi","pounds force per inch squared",oCategory);
			UnitsU("kpsi","kilo pounds per inch squared",oCategory);
			UnitsU("lb/ft2","pounds per square feet",oCategory);
			UnitsU("Pa","Pascals",oCategory);
			oCategory.Conversion(1.0,"MPa",1.0,"N/mm^2");
			oCategory.Conversion(1000000.0,"Pa",1,"N/mm^2");
			oCategory.Conversion(145.037738,"psi",1.0,"N/mm^2");
			oCategory.Conversion(145.037738/144.0,"lb/ft2",1.0,"N/mm^2");
			oCategory.Conversion(0.145037738,"kpsi",1.0,"N/mm^2");

			oCategory = UnitCategory("Temperature","C");
			UnitsU("C","degees",oCategory);

			UnitCategoryU("Acceleration");
			oCategory = UnitCategory("Acceleration","mm/sec^2");
			UnitsU("mm/sec^2","millimeters per second squared",oCategory);
			UnitsU("m/sec^2","meters per second squared",oCategory);
			UnitsU("ft/sec^2","feet per second squared",oCategory);
			UnitsU("in/sec^2","inches per second squared",oCategory);
			oCategory.Conversion(1.0,"m/sec^2",1000.0,"mm/sec^2");
			oCategory.Conversion(1.0,"ft/sec^2",304.8,"mm/sec^2");
			oCategory.Conversion(1.0,"in/sec^2",25.4,"mm/sec^2");

			oCategory = UnitCategory("AngularAcceleration","rad/sec^2");
			UnitsU("rad/sec^2","radians per second squared",oCategory);
			UnitsU("deg/sec^2","degrees per second squared",oCategory);
			oCategory.Conversion(57.2957795,"deg/sec^2",1.0,"rad/sec^2");

			oCategory = UnitCategory("Density","tonne/mm^3");
			UnitsU("tonne/mm^3","metric tonne per millimeter cubed",oCategory);
			UnitsU("lbm/in^3","pounds mass per inch cubed",oCategory);
			oCategory.Conversion(36127292.0,"lbm/in^3",1.0,"tonne/mm^3");
		}
		public virtual void EstablishUnitCategories()
		{
			//the internal units used for conversion
			UnitCategoryU("Length");
			UnitCategoryU("Angle");
			UnitCategoryU("Quantity");
			UnitCategoryU("Force");
			UnitCategoryU("Time");

			UnitCategoryU("Mass");
			UnitCategoryU("Area");
			UnitCategoryU("Volume");
			UnitCategoryU("Velocity");
			UnitCategoryU("Acceleration");
			UnitCategoryU("AngularVelocity");
			UnitCategoryU("AngularAcceleration");
			UnitCategoryU("Density");
			UnitCategoryU("Torque");
			UnitCategoryU("Power");
			UnitCategoryU("PowerFlux");
			UnitCategoryU("Pressure");
			UnitCategoryU("Storage");
			UnitCategoryU("DataTransfer");
			UnitCategoryU("WorkTime");
		}
		public virtual void EstablishCommonUnit()
		{
			UnitCategory oCategory = UnitCategory("Storage","KB");
			UnitsU("KB","KiloBytes",oCategory);
			UnitsU("GB","GigaBytes",oCategory);
			UnitsU("TB","TeraBytes",oCategory);
			UnitsU("Bytes","Bytes",oCategory);
			oCategory.Conversion(1000,"KB",1,"GB");
			oCategory.Conversion(1000,"Bytes",1,"KB");
			oCategory.Conversion(1000000,"KB",1,"TB");

			oCategory = UnitCategory("DataTransfer","Bytes/sec");
			UnitsU("Bytes/sec","Bytes per second",oCategory);
			UnitsU("KB/sec","KiloBytes per second",oCategory);
			UnitsU("GB/sec","GigaBytes per second",oCategory);
			oCategory.Conversion(1000,"Bytes/sec",1,"KB/sec");
			oCategory.Conversion(1000000,"Bytes/sec",1,"GB/sec");

			//these units must map an object to a DataType
			oCategory = UnitCategoryU("WorkTime");
			Units("Hrs",oCategory,"Hours");
			Units("Days",oCategory,"Days");
			Units("Wdays",oCategory,"WorkDays");
			Units("Wks",oCategory,"Weeks");
			Units("Mins",oCategory,"Mins");
		}
		public virtual void EstablishUnitSystem()
		{
			//the internal units used for conversion
			EstablishUnitCategories();

			switch(MyApplication.BaseUnitSystem)
			{
				case UnitSystem.IPS:
					SetUnitsToIPS();
					break;
				case UnitSystem.FPS:
					SetUnitsToIPS();
					break;
				case UnitSystem.MKS:
					SetUnitsToMKS();
					break;
				case UnitSystem.CGS:
					SetUnitsToCGS();
					break;
				case UnitSystem.mmNs:
					SetUnitsTommNs();
					break;
			}

			EstablishCommonUnit();
		}


		public override void EstablishDefaultKnowledge()
		{
			EstablishUnitSystem();

			Property("Number",typeof(NumberParameter));
			Property("Text",typeof(TextParameter));
			Property("URL",typeof(URLParameter));
			Property("FilePath",typeof(FilePathParameter));
			Property("WorkFile",typeof(FilePathParameter));
			Property("Integer",typeof(IntegerParameter));
			Property("PositiveInteger",typeof(IntegerParameter));
			Property("VisioCell",typeof(VisioCell));

			Property("ProcessStep",typeof(ProcessStepParameter));

			Property("MyCatalog",typeof(PointerParameter));
			Property("MyTable",typeof(PointerParameter));

			Property("MyDataSet",typeof(DataSetParameter)).Formula = "FillMyDataSet()";
			Property("MyDataRows",typeof(DataRowsParameter)).Formula = "FillMyDataRows()";
			Property("MyDataView",typeof(DataViewParameter)).Formula = "FillMyDataView()";
			Property("MyFilter",typeof(Parameter)).Formula = "FillMyFilter()";
			Property("MyOptions",typeof(Parameter)).Formula = "FillMyOptions()";
			Property("MySelection",typeof(Parameter)).Formula = "GetMySelection()";

			Property("_Area",typeof(NumberParameterWithUnits),UnitCategoryU("Area"));
			Property("_Length",typeof(NumberParameterWithUnits),UnitCategoryU("Length"));

			//Property("SQL",typeof(SQLParameter));
			//Property("Scripted",typeof(ScriptedParameter));

			//Property("Quantity",typeof(NumberParameter),UnitCategoryU("Quantity"));
			Property("Quantity",typeof(NumberParameter));
			Property("Count",typeof(NumberParameter));

			Concept("Context",typeof(ContextComponent)).Private = true;
			Property("ContextVariable",typeof(Parameter)).Private = true;;

			Concept("Combiner",typeof(Combiner)).Private = true;
			Concept("Role",typeof(ModelComponent)).Private = true;
			Concept oSolution = Concept("Solution",typeof(Solution));
			oSolution.Private = true;
			oSolution.ParameterPackageU("Design Name");
			oSolution.ParameterPackageU("Version").Formula = "1";
			oSolution.ParameterPackageU("Revision").Formula = "0";

			Concept oFeature = Concept("Feature",typeof(ConfigurableComponent));
			oFeature.Private = true;
			oFeature.ParameterPackageU("MyDataSet");
			oFeature.ParameterPackageU("MyDataView");
			oFeature.ParameterPackageU("MyFilter");
			oFeature.ParameterPackageU("MyDataRows");
			oFeature.ParameterPackageU("MyOptions");
			oFeature.ParameterPackageU("MySelection");

			Concept("Clones",typeof(ComponentArray)).Private = true;

			Property("ValidValues",typeof(PhantomParameter)).Private = true;
			Property("DisplayValues",typeof(PhantomParameter)).Private = true;

			Concept("Virtual",typeof(VirtualComponent)).Private = true;
			Concept oVirtualList = Concept("VirtualList",typeof(VirtualListComponent));
			//oVirtualList.ParameterPackageU("ValidValues");
			oVirtualList.Private = true;

			Concept("Phantom",typeof(PhantomComponent)).Private = true;
			Concept oPhantomList = Concept("PhantomList",typeof(PhantomListComponent));
			//oPhantomList.ParameterPackageU("ValidValues");
			oPhantomList.Private = true;

			Concept oGridView = Concept("GridView",typeof(GridViewComponent));
			oGridView.ParameterPackageU("ValidValues");
			oGridView.ParameterPackageU("MyDataSet");
			oGridView.ParameterPackageU("ReadOnly");
			oGridView.Private = true;

			Concept("Error",typeof(ErrorComponent)).Private = true;
			Concept("Folder",typeof(FolderComponent)).Private = true;
			Concept("File",typeof(FileComponent)).Private = true;
			Concept("Tool",typeof(ToolComponent)).Private = true;
			Concept("Timer",typeof(TimerComponent)).Private = true;
			Concept("Component",typeof(ModelComponent)).Private = true;

			InverseRelationships("HasSubparts","SubpartOf",typeof(Composition));
			InverseRelationships("HasDependentViews","ViewDependsOn",typeof(Composition));
			InverseRelationships("HasLink","LinkedTo",typeof(Composition));
		}
		
		public override void ResetInstanceCount()
		{
			foreach(ClassObject oClass in Concepts())
				oClass.ResetInstanceCount();
		}

		public virtual void ClearCapture()
		{
			foreach(ClassObject oClass in Concepts())
				oClass.ClearCapture(false);
		}



		public Interface InterfaceU(string sName)
		{
			return CreateFiledObjectU(sName,typeof(Interface)) as Interface;
		}
		public Interface InterfaceU(string sName, Interface oBase)
		{
			Interface oInterface = InterfaceU(sName);
			oInterface.InheritFromInterface(oBase);
			return oInterface;
		}
		public Interface Interface(string sName, bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(Interface),bCreate) as Interface;
		}
		public FolderObject InterfaceFolder
		{
			get
			{
				return EstablishFolder(typeof(Interface));
			}
		}
		public ObjectCollection Interfaces()
		{
			return InterfaceFolder.Slots;
		}
		public ObjectCollection PublicInterfaces()
		{
			ObjectCollection oInterfaces = NewCollection();
			foreach(Interface oInterface in InterfaceFolder.Slots)
				if ( !oInterface.Private ) 
					oInterfaces.Add(oInterface);

			return oInterfaces;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sName"></param>
		/// <returns></returns>
		public Concept ConceptU(string sName)
		{
			if ( StringCompare(sName,"NULL") )
				return null;

			return CreateFiledObjectU(sName,typeof(Concept)) as Concept;
		}
		public Concept ConceptU(string sName, Concept oBase)
		{
			Concept oConcept = ConceptU(sName);
			oConcept.InheritFromConcept(oBase);
			return oConcept;
		}
		public Concept Concept(string sName, bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(Concept),bCreate) as Concept;
		}
		public FolderObject ConceptFolder
		{
			get
			{
				return EstablishFolder(typeof(Concept));
			}
		}
		public ObjectCollection Concepts()
		{
			return ConceptFolder.Slots;
		}

		public virtual Concept Concept(string sName, string sType)
		{
			return Concept(sName,ApprenticeType(sType));
		}

		public virtual Concept Concept(string sName, Type oType)
		{
			Concept oConcept = ConceptU(sName);
			oConcept.ConstructionType = oType;
			return oConcept;
		}
//		public virtual Analytical AnalyticalU(string sName)
//		{
//			return CreateFiledObjectU(sName,typeof(Analytical)) as Analytical;
//		}
//		public virtual Analytical Analytical(string sName, bool bCreate)
//		{
//			return FindObjectInFolder(sName,typeof(Analytical),bCreate) as Analytical;
//		}
//		public virtual FolderObject AnalyticalFolder
//		{
//			get 
//			{
//				return EstablishFolder(typeof(Analytical));
//			}
//		}
//		public ObjectCollection Analyticals()
//		{
//			return AnalyticalFolder.Slots;
//		}
		public Container ContainerU(string sName)
		{
			return CreateFiledObjectU(sName,typeof(Container)) as Container;
		}
		public virtual Container Container(string sName, bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(Container),bCreate) as Container;
		}
		public FolderObject ContainerFolder
		{
			get
			{
				return EstablishFolder(typeof(Container));
			}
		}
		public ObjectCollection Containers()
		{
			return ContainerFolder.Slots;
		}
		public virtual Container Container(string sName, string sType)
		{
			return Container(sName,ApprenticeType(sType));
		}

		public virtual Container Container(string sName, Type oType)
		{
			Container oContainer = ContainerU(sName);
			oContainer.ConstructionType = oType;
			return oContainer;
		}

		public virtual Deployment DeploymentU(string sName)
		{
			return CreateFiledObjectU(sName,typeof(Deployment)) as Deployment;
		}
		public virtual Deployment Deployment(string sName, bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(Deployment),bCreate) as Deployment;
		}
		public FolderObject DeploymentFolder
		{
			get
			{
				return EstablishFolder(typeof(Deployment));
			}
		}
		public ObjectCollection Deployments()
		{
			return DeploymentFolder.Slots;
		}

		public virtual Property PropertyU(string sName)
		{
			return CreateFiledObjectU(sName,typeof(Property)) as Property;
		}
		public virtual Property PropertyU(string sName, string sUnits)
		{
			return PropertyU(sName,UnitsU(sUnits));
		}
		public virtual Property PropertyU(string sName, Units oUnits)
		{
			Property oProperty = PropertyU(sName);
			oProperty.Units = oUnits;
			return oProperty;
		}
		public Property PropertyU(string sName, Property oBase)
		{
			Property oProperty = PropertyU(sName);
			oProperty.InheritFromProperty(oBase);
			return oProperty;
		}	
		public virtual Property Property(string sName, bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(Property),bCreate) as Property;;
		}
		public FolderObject PropertyFolder
		{
			get
			{
				return EstablishFolder(typeof(Property));
			}
		}
		public ObjectCollection Properties()
		{
			return PropertyFolder.Slots;
		}
		public Property Property(string sName, string sType)
		{
			return Property(sName,ApprenticeType(sType));
		}	

		public virtual Property Property(string sName, Type oType)
		{
			Property oProperty = PropertyU(sName);
			oProperty.ConstructionType = oType;
			return oProperty;
		}
		public virtual Property Property(string sName, Type oType, UnitCategory oCategory)
		{
			Property oProperty = PropertyU(sName);
			oProperty.ConstructionType = oType;
			oProperty.Units = oCategory.BaseUnits; 
			return oProperty;
		}

		public virtual Relationship RelationshipU(string sName)
		{
			string[] sNames = sName.Split(';');

			if ( sNames.Length == 1 )
				return CreateFiledObjectU(sName,typeof(Relationship)) as Relationship;


			Relationship oRelation = CreateFiledObjectU(sNames[0],typeof(Relationship)) as Relationship;
			Relationship oInverse = CreateFiledObjectU(sNames[1],typeof(Relationship)) as Relationship;
				
			oRelation.Inverse = oInverse;
			oInverse.Inverse = oRelation;
			return oRelation;
		}		
		public virtual Relationship Relationship(string sName, bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(Relationship),bCreate) as Relationship;;
		}
		public FolderObject RelationshipFolder
		{
			get
			{
				return EstablishFolder(typeof(Relationship));
			}
		}

		public virtual Relationship Relationship(string sName, string sType)
		{
			return Relationship(sName,ApprenticeType(sType));
		}
		public virtual Relationship Relationship(string sName, Type oType)
		{
			Relationship oRelationship = RelationshipU(sName);
			oRelationship.ConstructionType = oType;
			return oRelationship;
		}
		public virtual Relationship InverseRelationshipsU(string sRelationships)
		{
			string[] sNames = sRelationships.Split(';');
			if ( sNames.Length == 1 )
				return RelationshipU(sNames[0]);

			if ( sNames.Length == 2 )
				return InverseRelationshipsU(sNames[0],sNames[1]);

			return null;
		}
		public virtual Relationship InverseRelationshipsU(string sRelation, string sInverse)
		{
			Relationship oRelation = RelationshipU(sRelation);
			if ( sInverse == null || sInverse.Length == 0 )
				return oRelation;

			Relationship oInverse = RelationshipU(sInverse);
			oRelation.Inverse = oInverse;
			oInverse.Inverse = oRelation;

			return oRelation;
		}
		public virtual Relationship InverseRelationships(string sRelation, string sInverse)
		{
			Relationship oRelation = Relationship(sRelation,true);
			if ( sInverse == null || sInverse.Length == 0 )
				return oRelation;

			Relationship oInverse = Relationship(sInverse,true);
			oRelation.Inverse = oInverse;
			oInverse.Inverse = oRelation;

			return oRelation;
		}
		public virtual Relationship InverseRelationships(string sRelation, string sInverse, Type oType)
		{
			Relationship oRelation = Relationship(sRelation,oType);
			if ( sInverse == null || sInverse.Length == 0 )
				return oRelation;

			Relationship oInverse = Relationship(sInverse,oType);
			oRelation.Inverse = oInverse;
			oInverse.Inverse = oRelation;

			return oRelation;
		}
/*********************/
		public Units UnitsU(string sName)
		{
			return FindObjectInFolder(sName,typeof(Units),true) as Units;
		}
		public Units UnitsU(string sName, string sCaption, UnitCategory oUnitCategory)
		{
			Units oUnits = UnitsU(sName);
			oUnits.Caption = sCaption;
			oUnits.Category = oUnitCategory.Name;
			oUnits.UnitCategory = oUnitCategory;
			return oUnits;
		}
		public Units UnitsU(string sName,bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(Units),bCreate) as Units;
		}

		public Units Units(string sName, UnitCategory oUnitCategory)
		{
			Units oUnits = UnitsU(sName) as Units;
			oUnits.Category = oUnitCategory.Name;
			oUnits.UnitCategory = oUnitCategory;
			return oUnits;
		}
		public Units Units(string sName, UnitCategory oUnitCategory, string sMapping)
		{
			Units oUnits = Units(sName,oUnitCategory) as Units;
			oUnits.MappingFunction = sMapping;
			return oUnits;
		}
		public FolderObject UnitsFolder
		{
			get
			{
				return EstablishFolder(typeof(Units));
			}
		}
		public ObjectCollection Units()
		{
			return UnitsFolder.Slots;
		}

		/*********************/
		public UnitCategory UnitCategoryU(string sName)
		{
			return CreateFiledObjectU(sName,typeof(UnitCategory)) as UnitCategory;
		}
		public UnitCategory UnitCategoryU(string sName,bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(UnitCategory),bCreate) as UnitCategory;
		}
		public UnitCategory UnitCategory(string sName, string sBaseUnits)
		{
			UnitCategory oUnitCategory = UnitCategoryU(sName) as UnitCategory;
			oUnitCategory.BaseUnits = Units(sBaseUnits,oUnitCategory);
			return oUnitCategory;
		}
		public FolderObject UnitCategoryFolder
		{
			get
			{
				return EstablishFolder(typeof(UnitCategory));
			}
		}
		public ObjectCollection UnitCategories()
		{
			return UnitCategoryFolder.Slots;
		}
		public ComponentPackage ComponentPackageU(string sName)
		{
			return CreateFiledObjectU(sName,typeof(ComponentPackage)) as ComponentPackage;
		}

		public ComponentPackage ComponentPackage(string sName, bool bCreate)
		{
			return FindObjectInFolder(sName,typeof(ComponentPackage),bCreate) as ComponentPackage;
		}
		public FolderObject ComponentPackageFolder
		{
			get
			{
				return EstablishFolder(typeof(ComponentPackage));
			}
		}
		public ObjectCollection ComponentPackages()
		{
			return ComponentPackageFolder.Slots;
		}
	}
}
