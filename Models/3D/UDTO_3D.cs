namespace IoBTMessage.Models
{
	[System.Serializable]
	public class UDTO_3D : UDTO_Base
	{
		public string platformName;
		public string uniqueGuid;
		public string type;
		public string name;
		public string material;
		public string referenceDesignation;
		public ControlParameters metadata;
		public bool visible = true;

#if !UNITY
		public virtual UDTO_3D CopyFrom(UDTO_3D obj)
		{
			platformName = obj.platformName;
			uniqueGuid = obj.uniqueGuid;
			type = obj.type;
			name = obj.name;
			return this;
		}

		public string partName()
		{
			if ( string.IsNullOrEmpty(referenceDesignation))
				return name;

			return $"{name}_{referenceDesignation}";
		}
		public bool isDelete()
		{
			return this.type == "Command:DELETE";
		}

		public bool isVisible()
		{
			return this.visible;
		}

		public UDTO_3D setVisible(bool visible)
		{
			this.visible = visible;
			return this;
		}

		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{platformName}{d}{uniqueGuid}{d}{type}{d}{name}{d}";
		}

		public override int decompress(string[] inputData)
		{
			var counter = base.decompress(inputData);

			platformName = inputData[counter++];
			uniqueGuid = inputData[counter++];
			type = inputData[counter++];
			name = inputData[counter++];
			return counter;
		}
#endif
	}
}
