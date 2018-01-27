using DokiDokiRagnarok.Models;
using DokiDokiRagnarok.UI;
using UnityEngine;

namespace DokiDokiRagnarok.Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public class RaidController : MonoBehaviour
    {
        public ActorController ActorController;
        public AnimateText AnimateText;
        private RaidModel _raid;
        private RaidPhaseModel _raidPhase;
        private DialogModel _dialog;
        public RaidModel DebugRaidModel;
        private AudioSource _audioSource;

        public DialogOptions DialogOptions;

        private int _dialogStep = -1;
        private int _phaseStep = -1;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
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
                    return;
                }
                else if (_dialog == _raid.DefeatDialog)
                {
                    //TODO End it
                    Debug.Log("Defeat");
                } else if (_dialog == _raid.VictoryDialog)
                {
                    //TODO
                    Debug.Log("Victory");
                }
                else
                {
                    NextPhase();
                    return;
                }
            }

            ActorController.SetActor(_dialog.Actors[_dialogStep]);
            AnimateText.ShowText(_dialog.DialogTexts[_dialogStep]);

            if (_dialogStep < _dialog.DialogAudio.Count)
            {
                _audioSource.Stop();
                _audioSource.PlayOneShot(_dialog.DialogAudio[_dialogStep]);
            }
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
                //ChooseDialog(3);
                AnimateText.SetTextButtonInteractable(false);
                DialogOptions.ShowDialogOptions();

            }
        }

        public void ChooseDialog(int option)
        {
            _dialog = _raidPhase.Dialogs[option];
            AnimateText.SetTextButtonInteractable(true);
            NextStep();

            DialogOptions.HideDialogOptions();
        }

        public void Victory()
        {
            _dialogStep = -1;
            _dialog = _raid.VictoryDialog;
            NextStep();
        }

        public void Defeat()
        {
            
        }

        public void FirstDialog()
        {
            ChooseDialog(0);
        }

        public void SecondDialog()
        {
            ChooseDialog(1);
        }

        public void ThirdDialog()
        {
            ChooseDialog(2);
        }

        public void FourthDialog()
        {
            ChooseDialog(3);
        }
    }
}