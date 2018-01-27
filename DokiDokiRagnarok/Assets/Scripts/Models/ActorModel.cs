using UnityEngine;

namespace DokiDokiRagnarok.Models
{
    public class ActorModel : ScriptableObject
    {
        public string Name;
        public AudioClip SoundEffect;
        public GameObject ActorGameObject;
        public ActorType ActorType;
    }
}