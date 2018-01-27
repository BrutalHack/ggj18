using DokiDokiRagnarok.Models;
using UnityEditor;

namespace DokiDokiRagnarok.Editor.DataModels
{
	public class ActorModelAsset
	{
		[MenuItem("Assets/Create/DataModels/ActorModel")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<ActorModel>();
		}
	}
}