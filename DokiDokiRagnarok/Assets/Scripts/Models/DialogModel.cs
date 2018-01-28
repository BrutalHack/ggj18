using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DokiDokiRagnarok.Models
{
    public class DialogModel : ScriptableObject
    {
        public List<ActorModel> Actors;
        [TextArea] public List<string> DialogTexts;
        public List<AudioClip> DialogAudio;
        public List<Event> Events;
    }
}