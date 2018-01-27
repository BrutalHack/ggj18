using UnityEngine;

namespace DokiDokiRagnarok.Controllers
{
    public class ActorController : MonoBehaviour
    {
        public GameObject VikingActor;
        public GameObject VillageActor;
        public GameObject VillageEmotions;
        public GameObject LokiActor;
        public GameObject OdinActor;

        public GameObject VikingPrefab;
        public GameObject VillagePrefab;

        void Start()
        {
            SetEmotion(Emotion.Angry);
            SetVikingActor(VikingPrefab);
            SetVillageActor(VillagePrefab);
            SetOdin(true);
            SetLoki(true);
        }

        void Update()
        {
        }

        public void DisableAllActors()
        {
            destroyAllChildren(VillageActor.transform);
            destroyAllChildren(VikingActor.transform);
            LokiActor.SetActive(false);
            OdinActor.SetActive(false);
        }

        public void SetEmotion(Emotion emotion)
        {
            foreach (Transform child in VillageEmotions.transform)
            {
                if (child.name.Equals(emotion.ToString()))
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        public void SetVikingActor(GameObject actorPrefab)
        {
            DisableAllActors();
            Instantiate(actorPrefab, VikingActor.transform);
        }

        public void SetLoki(bool active)
        {
            DisableAllActors();
            LokiActor.SetActive(active);
        }

        public void SetOdin(bool active)
        {
            DisableAllActors();
            OdinActor.SetActive(active);
        }

        public void SetVillageActor(GameObject actorPrefab)
        {
            DisableAllActors();
            Instantiate(actorPrefab, VillageActor.transform);
        }

        private void destroyAllChildren(Transform node)
        {
            foreach (Transform child in node)
            {
                Destroy(child.gameObject);
            }
        }
    }
}