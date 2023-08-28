using FoundryRulesAndUnits.Models;
using FoundryRulesAndUnits.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{


	[System.Serializable]
	public class UDTO_Platform : UDTO_3D
	{
		public UDTO_Position position;
		public BoundingBox boundingBox;
		public HighResOffset offset;

		public List<UDTO_Platform> platforms = new();
		public List<UDTO_Body> bodies = new();
		public List<UDTO_Label> labels = new();

		public UDTO_Platform() : base()
		{
			uniqueGuid = Guid.NewGuid().ToString();
			type = UDTO_Base.asTopic<UDTO_Platform>();
			position = new UDTO_Position();
			offset = new HighResOffset();
			boundingBox = new BoundingBox();
		}


		public UDTO_Platform EstablishBox(string name, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			this.name = name;
			boundingBox = new BoundingBox(width,height,depth,units);
			position = new UDTO_Position();
			offset = new HighResOffset();
			return this;
		}



		private List<T> FindLookup<T>() where T : UDTO_3D
		{
			if (typeof(T) == typeof(UDTO_Body)) return bodies as List<T>;
			if (typeof(T) == typeof(UDTO_Label)) return labels as List<T>;
			if (typeof(T) == typeof(UDTO_Platform)) return platforms as List<T>;

			return null;
		}


		private T CreateItem<T>(string name) where T : UDTO_3D
		{
			var found = Activator.CreateInstance<T>() as T;
			found.name = name;
			found.panID = panID;
			found.platformName = platformName;
			found.uniqueGuid = Guid.NewGuid().ToString();
			return found;
		}

		public T FindOrCreate<T>(string name, bool create = false) where T : UDTO_3D
		{
			var list = FindLookup<T>();
			var found = list?.FirstOrDefault(item => item.name.Matches(name));
			if (found == null && create)
			{
				found = CreateItem<T>(name);
				list?.Add(found);
			}
			return found!;
		}



		public void Merge(UDTO_Platform platform)
		{
			if (platform.position != null)
			{
				this.position = platform.position;
			}
			if (platform.boundingBox != null)
			{
				this.boundingBox = platform.boundingBox;
			}
			if (platform.offset != null)
			{
				this.offset = platform.offset;
			}

			// platform.bodies.ForEach(body =>
			// {
			// 	AddRefreshOrDelete<UDTO_Body>(body);
			// });
			// platform.bodies = null;

			// platform.labels.ForEach(label =>
			// {
			// 	AddRefreshOrDelete<UDTO_Label>(label);
			// });
			// platform.labels = null;

			// platform.datums.ForEach(datum =>
			// {
			// 	AddRefreshOrDelete<UDTO_Datum>(datum);
			// });
			// platform.datums = null;

			// platform.relationships.ForEach(relationship =>
			// {
			// 	AddRefreshOrDelete<UDTO_Relationship>(relationship);
			// });
			// platform.relationships = null;
		}


		public UDTO_Platform SetPositionTo(UDTO_Position loc)
		{
			position = loc;
			return this;
		}



		public UDTO_Platform Flush()
		{
			platforms.Clear();
			bodies.Clear();
			labels.Clear();
			return this;
		}

		public UDTO_Platform AsShallowCopy()
		{
			var result = (UDTO_Platform)this.MemberwiseClone();
			result.Flush();
			return result;
		}	

	}

}