using System;
using System.Collections.Generic;
using Balancy.Data;

namespace Balancy
{
#pragma warning disable 649

	public partial class DataEditor
	{

		private static void LoadSmartObject(string userId, string name, string key, Action<ParentBaseData> callback)
		{
			switch (name)
			{
				case "SmartObjects.UnnyProfile":
				{
					SmartStorage.LoadSmartObject<Data.SmartObjects.UnnyProfile>(userId, key, responseData =>
					{
						callback?.Invoke(responseData.Data);
					});
					break;
				}
				default:
					UnnyLogger.Critical("No SmartObject found by name " + name);
					break;
			}
		}

		static partial void MoveAllData(string userId)
		{
			MigrateSmartObject(userId, "UnnyProfile");
		}

		static partial void TransferAllSmartObjectsFromLocalToCloud(string userId)
		{
			TransferSmartObjectFromLocalToCloud<Data.SmartObjects.UnnyProfile>(userId);
		}

		static partial void ResetAllSmartObjects(string userId)
		{
			ResetSmartObject<Data.SmartObjects.UnnyProfile>(userId);
		}

		static partial void PreloadAllSmartObjects(string userId)
		{
		}

		public static List<Models.Armor> Armors { get; private set; }

		static partial void PrepareGeneratedData() {
			Armors = DataManager.ParseList<Models.Armor>();
			SmartStorage.SetLoadSmartObjectMethod(LoadSmartObject);
		}
	}
#pragma warning restore 649
}