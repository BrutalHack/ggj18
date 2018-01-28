using DokiDokiRagnarok.Models;
using UnityEditor;

namespace DokiDokiRagnarok.Editor.DataModels
{
	public class ActionDialogModelAsset
	{
		[MenuItem("Assets/Create/DataModels/ActionDialogModel")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<ActionDialogModel>();
		}
	}
}