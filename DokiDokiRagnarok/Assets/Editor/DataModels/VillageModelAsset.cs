using UnityEditor;

public class VillageModelAsset
{
	[MenuItem("Assets/Create/VillageModel")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<VillageModel>();
	}
}