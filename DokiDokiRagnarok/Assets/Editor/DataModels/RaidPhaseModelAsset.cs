using UnityEditor;

namespace DokiDokiRagnarok.Editor.DataModels
{
	public class RaidPhaseModelAsset
	{
		[MenuItem("Assets/Create/DataModels/RaidPhaseModel")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<RaidPhaseModel>();
		}
	}
}