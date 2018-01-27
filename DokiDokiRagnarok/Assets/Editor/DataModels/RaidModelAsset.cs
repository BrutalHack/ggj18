using DokiDokiRagnarok.Models;
using UnityEditor;

namespace DokiDokiRagnarok.Editor.DataModels
{
	public class RaidModelAsset
	{
		[MenuItem("Assets/Create/DataModels/RaidModel")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<RaidModel>();
		}
	}
}