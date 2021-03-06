﻿using System.Collections.Generic;
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

        private ActorType currentActor = ActorType.Player;

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
            VillageEmotions.SetActive(false);
        }

        public void SetEmotion(Emotion emotion)
        {
            VillageEmotions.SetActive(true);
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
            if (active && currentActor != ActorType.Loki)
            {
                MusicController.PlayLoki();
                DisableRightActors();
                LokiActor.SetActive(true);
                currentActor = ActorType.Loki;
                
            }
            else if (!active && _villageWasHere)
            {
                SetVillageActor(VillagePrefab);
            }
            else if (!active)
            {
                DisableRightActors();
            }
        }

        public void SetOdin(bool active)
        {
            if (active && currentActor != ActorType.Odin)
            {
                MusicController.PlayOdin();
                DisableRightActors();
                OdinActor.SetActive(true);
                currentActor = ActorType.Odin;
            }
            else if (!active && _villageWasHere)
            {
                SetVillageActor(VillagePrefab);
            }
            else if (!active)
            {
                DisableRightActors();
            }
        }

        public void SetVillageActor(GameObject actorPrefab)
        {
            if (currentActor == ActorType.Village)
            {
                
            }
            else
            {
                StopWorldMusicIfActive();
                MusicController.PlayMainTheme();
                _villageWasHere = true;
                DisableRightActors();
                if (actorPrefab != null)
                {
                    Instantiate(actorPrefab, VillageActor.transform);
                    VillageEmotions.SetActive(true);
                }
            }
            currentActor = ActorType.Village;
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