using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IoBTMessage.Models;

namespace IoBTMessageLibrary.Models
{

	public class PlatformGenerator
	{
#if !UNITY
		public UDTO_Platform AllPrimitives(string PanID)
		{
			var platform = new UDTO_Platform()
			{
				platformName = "AllPrimitives",
				panID = PanID
			};

			var footer = platform.FindOrCreate<UDTO_Body>("Cube_01", true);
			footer.CreateBox("base", 20, 40, 90);

			var post = platform.FindOrCreate<UDTO_Body>("Post_01", true);
			post.CreateCylinder("post", 10, 90, 10);

			var label = platform.FindOrCreate<UDTO_Label>("Cube_01", true);
			label.CreateTextAt("Hello 3D, World");

			label = platform.FindOrCreate<UDTO_Label>("Cube_02", true);
			label.CreateTextAt("Top of the World", 5, post.boundingBox.height + 2, 10);

			//platform.RelateMembers<UDTO_Relationship>(post, "MountsTo", footer);
			platform.RelateMembers<UDTO_Relationship>(footer, "Supports", post);

			return platform;
		}
#endif
	}
}
