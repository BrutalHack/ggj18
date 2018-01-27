using UnityEngine;

namespace DokiDokiRagnarok.Models
{
    public class DialogSegmentModel : ScriptableObject
    {
        public ActorModel actor;
        [TextArea] public string DialogText;
        public DialogSegmentModel Next;
    }
}