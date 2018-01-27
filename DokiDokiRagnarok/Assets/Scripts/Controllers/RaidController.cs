using DokiDokiRagnarok.Models;
using DokiDokiRagnarok.UI;
using UnityEngine;

namespace DokiDokiRagnarok.Controllers
{
    public class RaidController : MonoBehaviour
    {
        public ActorController ActorController;
        public AnimateText AnimateText;
        private RaidModel _raid;
        private RaidPhaseModel _raidPhase;
        private DialogModel _dialog;
        public RaidModel DebugRaidModel;

        private int _dialogStep = -1;
        private int _phaseStep = -1;

        void Start()
        {
            _raid = World.ChosenRaid;

            if (DebugRaidModel)
            {
                _raid = DebugRaidModel;
            }

            NextPhase();
        }

        public void NextStep()
        {
            _dialogStep++;
            if (_dialogStep == _dialog.DialogTexts.Count)
            {
                if (_dialog == _raidPhase.Intro)
                {
                    StartDialog();
                }
                else
                {
                    NextPhase();
                    return;
                }
            }

            ActorController.SetActor(_dialog.Actors[_dialogStep]);
            AnimateText.ShowText(_dialog.DialogTexts[_dialogStep]);
            if (_dialogStep < _dialog.Events.Count)
            {
                _dialog.Events[_dialogStep].Invoke();
            }
        }

        private void NextPhase()
        {
            _phaseStep++;
            _dialogStep = -1;
            _raidPhase = _raid.RaidPhases[_phaseStep];
            _dialog = _raidPhase.Intro;
            NextStep();
        }

        public void StartDialog()
        {
            _dialogStep = -1;
            if (_dialog == _raidPhase.Intro)
            {
                //TODO Dialog Prompt
                ChooseDialog(3);
            }
        }

        public void ChooseDialog(int option)
        {
            _dialog = _raidPhase.Dialogs[option];
            NextStep();
        }
    }
}