using System.Collections.Generic;
using DokiDokiRagnarok.Models;
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

        public List<GameObject> VillagePrefabs;
        private GameObject VillagePrefab;

        public LoopMusic MusicController;

        private bool _villageWasHere;

        void Start()
        {
            DisableRightActors();

            if (World.ChosenRaid == null)
            {
                VillagePrefab = VillagePrefabs[0];
                return;
            }

            Debug.Log(World.ChosenRaid.Name);
            if (World.ChosenRaid.Name.Equals("Brittany"))
            {
                VillagePrefab = VillagePrefabs[0];
            }
            else if (World.ChosenRaid.Name.Equals("Iceland"))
            {
                VillagePrefab = VillagePrefabs[1];
            }
            else if (World.ChosenRaid.Name.Equals("Normandy"))
            {
                VillagePrefab = VillagePrefabs[2];
            }
        }

        public void SetActor(ActorModel actor)
        {
            if (actor.ActorType == ActorType.Loki)
            {
                SetLoki(true);
            }
            else if (actor.ActorType == ActorType.Odin)
            {
                SetOdin(true);
            }
            else if (actor.ActorType == ActorType.Player)
            {
                SetVikingActor(actor.ActorGameObject);
            }
            else if (actor.ActorType == ActorType.Village)
            {
                SetVillageActor(actor.ActorGameObject);
            }
        }

        public void DisableRightActors()
        {
            destroyAllChildren(VillageActor.transform);
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
            //DisableLokiAndOdinActors();
            //destroyAllChildren(VikingActor.transform);
            //if (actorPrefab != null)
            //{
            //    Instantiate(actorPrefab, VikingActor.transform);
            //}
        }

        private void DisableLokiAndOdinActors()
        {
            SetLoki(false);
            SetOdin(false);
        }

        public void SetLoki(bool active)
        {
            if (active)
            {
                MusicController.PlayLoki();
            }
            else if (_villageWasHere)
            {
                SetVillageActor(VillagePrefab);
            }

            DisableRightActors();
            LokiActor.SetActive(active);
        }

        public void SetOdin(bool active)
        {
            if (active)
            {
                MusicController.PlayOdin();
            }
            else if (_villageWasHere)
            {
                SetVillageActor(VillagePrefab);
            }

            DisableRightActors();
            OdinActor.SetActive(active);
        }

        public void SetVillageActor(GameObject actorPrefab)
        {
            StopWorldMusicIfActive();
            MusicController.PlayMainTheme();
            _villageWasHere = true;
            DisableRightActors();
            if (actorPrefab != null)
            {
                Instantiate(actorPrefab, VillageActor.transform);
            }
        }

        private static void StopWorldMusicIfActive()
        {
            GameObject worldMusic = GameObject.FindGameObjectWithTag("WorldMusic");
            if (worldMusic)
            {
                worldMusic.GetComponent<AudioSource>().Stop();
                GameObject.Destroy(worldMusic);    
            }
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