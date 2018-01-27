using DokiDokiRagnarok.Controllers;
using DokiDokiRagnarok.Models;
using DokiDokiRagnarok.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DokiDokiRagnarok
{
    public class RaidController : MonoBehaviour
    {
        public ActorController ActorController;
        public AnimateText AnimateText;
        private RaidModel _raid;
        private RaidPhaseModel _raidPhase;
        private DialogModel _dialog;
        public RaidModel DebugRaidModel; 
        
        void Start()
        {
            _raid = World.ChosenRaid;

            if (DebugRaidModel)
            {
                _raid = DebugRaidModel;
            }
            _raidPhase = _raid.RaidPhases[0];
            _dialog = _raidPhase.Intro;

            ActorController.SetActor(_dialog.Actors[0]);
            AnimateText.ShowText(_dialog.DialogTexts[0]);
            _dialog.Events[0].Invoke();
        }

        void Update()
        {
        
        }
    }
}