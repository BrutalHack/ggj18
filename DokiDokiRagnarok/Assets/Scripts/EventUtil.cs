using DokiDokiRagnarok.Controllers;
using UnityEngine;

namespace DokiDokiRagnarok
{
    public class EventUtil
    {
        public static void ExecuteEvent(Event value)
        {
            GameObject actorControllerGameObject = GameObject.FindGameObjectWithTag("ActorController");
            ActorController actorController = actorControllerGameObject.GetComponent<ActorController>();
            switch (value)
            {
                case Event.Angry:
                    Village.Emotion = Emotion.Angry;
                    actorController.SetEmotion(Emotion.Angry);
                    break;
                case Event.AttackedEnglandWhileAngry:
                    Village.AttackedEnglandWhileAngry = true;
                    break;
                case Event.AttackedEnglandWhileSweatDrop:
                    Village.AttackedEnglandWhileSweatDrop = true;
                    break;
                case Event.Happy:
                    Village.Emotion = Emotion.Happy;
                    actorController.SetEmotion(Emotion.Happy);
                    break;
                case Event.NoEmotion:
                    Village.Emotion = Emotion.None;
                    actorController.SetEmotion(Emotion.None);
                    break;
                case Event.Shy:
                    Village.Emotion = Emotion.Shy;
                    actorController.SetEmotion(Emotion.Shy);
                    break;
                case Event.SweatDrop:
                    Village.Emotion = Emotion.SweatDrop;
                    actorController.SetEmotion(Emotion.SweatDrop);
                    break;
            }
        }
    }
}