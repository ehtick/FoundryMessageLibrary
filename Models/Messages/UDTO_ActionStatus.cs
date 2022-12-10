namespace IoBTMessage.Models
{

	public class SPEC_ActionStatus : SPEC_Base
	{
		public string status { get; set;  }
		public string message { get; set;  }
	}

	public class UDTO_ActionStatus : UDTO_Base
	{
		public string status;
		public string message;


		public UDTO_ActionStatus() : base()
		{
		}

		public override string compress(char d = ',')
		{
			return $"{base.compress(d)}{d}{this.status}{d}{this.message}";
		}

		public override int decompress(string[] data)
		{
			var counter = base.decompress(data);
			this.sourceGuid = data[counter++];
			this.message = data[counter++];
			return counter;
		}


		public static UDTO_ActionStatus info(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "INFO",
				message = message
			};
		}

		public static UDTO_ActionStatus success(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "SUCCESS",
				message = message
			};
		}
		public static UDTO_ActionStatus warning(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "WARNING",
				message = message
			};
		}

		public static UDTO_ActionStatus error(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "ERROR",
				message = message
			};
		}
		public static UDTO_ActionStatus taskComplete(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "INFO",
				message = message
			};
		}
	}
}