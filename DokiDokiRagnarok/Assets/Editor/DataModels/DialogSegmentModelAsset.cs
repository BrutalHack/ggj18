using DokiDokiRagnarok.Models;
using UnityEditor;

namespace DokiDokiRagnarok.Editor.DataModels
{
    public class DialogModelAsset
    {
        [MenuItem("Assets/Create/DataModels/DialogModel")]
        public static void CreateAsset()
        {
            ScriptableObjectUtility.CreateAsset<DialogModel>();
        }
    }
}