using DokiDokiRagnarok.Models;
using UnityEditor;

namespace DokiDokiRagnarok.Editor.DataModels
{
	public class DialogSegmentModelAsset
	{
		[MenuItem("Assets/Create/DataModels/DialogSegmentModel")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<DialogSegmentModel>();
		}
	}
}