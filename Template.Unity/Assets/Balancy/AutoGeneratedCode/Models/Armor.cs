using Newtonsoft.Json;

namespace Balancy.Models
{
#pragma warning disable 649

	public class Armor : BaseModel
	{



		[JsonProperty("name")]
		public readonly string Name;

		[JsonProperty("slot")]
		public readonly Models.ArmorSlots Slot;

		[JsonProperty("weight")]
		public readonly int Weight;

		[JsonProperty("armorPoints")]
		public readonly int ArmorPoints;

		[JsonProperty("price")]
		public readonly int Price;

	}
#pragma warning restore 649
}