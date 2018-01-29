using System.Collections.Generic;
using DokiDokiRagnarok.Models;
using DokiDokiRagnarok.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public int VictoryScore;
        public DialogOptions DialogOptions;

        private List<ActionDialogModel> _actionDialogModels = new List<ActionDialogModel>();

        private int _dialogStep = -1;
        private int _phaseStep = -1;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _raid = World.ChosenRaid;
            Viking.Reset();
            Village.Reset();

            if (_raid == null && DebugRaidModel)
            {
                _raid = DebugRaidModel;
            }

            _actionDialogModels.Add(_raid.RaidActionDialogModel);
            _actionDialogModels.Add(_raid.MeadActionDialogModel);
            _actionDialogModels.Add(_raid.OdinActionDialogModel);
            _actionDialogModels.Add(_raid.EnglandActionDialogModel);
            NextPhase();
        }

        public void NextStep()
        {
            _dialogStep++;

            if (HandleDialogEnd()) return;

            ActorController.SetActor(_dialog.Actors[_dialogStep]);
            AnimateText.ShowText(_dialog.DialogTexts[_dialogStep]);

            if (_dialogStep < _dialog.DialogAudio.Count)
            {
                _audioSource.Stop();
                _audioSource.PlayOneShot(_dialog.DialogAudio[_dialogStep]);
            }

            if (_dialogStep < _dialog.Events.Count)
            {
                EventUtil.ExecuteEvent(_dialog.Events[_dialogStep]);
            }
        }

        private bool HandleDialogEnd()
        {
            if (_dialog == null)
            {
                NextPhase();
            }

            if (_dialogStep == _dialog.DialogTexts.Count)
            {
                if (_dialog == _raidPhase.Intro)
                {
                    StartDialog();
                    return true;
                }

                if (_dialog == _raid.DefeatDialog)
                {
                    SceneManager.LoadScene(1);
                    return true;
                }

                if (_dialog == _raid.VictoryDialog)
                {
                    World.RaidedVillages.Add(_raid);
                    SceneManager.LoadScene(1);
                    return true;
                }

                if (IsAnyActionDialog(_dialog))
                {
                    NextPhase();
                    return true;
                }

                StartDialog();
                return true;
            }

            return false;
        }

        private bool IsAnyActionDialog(DialogModel dialog)
        {
            foreach (ActionDialogModel actionDialogModel in _actionDialogModels)
            {
                if (actionDialogModel.Dialogs.Contains(dialog))
                {
                    return true;
                }
            }

            return false;
        }

        private void NextPhase()
        {
            _phaseStep++;
            if (_phaseStep >= _raid.RaidPhases.Count)
            {
                HandleRaidEnd();
                return;
            }

            _dialogStep = -1;
            _raidPhase = _raid.RaidPhases[_phaseStep];
            _dialog = _raidPhase.Intro;
            NextStep();
        }

        private void HandleRaidEnd()
        {
            if (Viking.Score >= VictoryScore)
            {
                Victory();
            }
            else
            {
                Defeat();
            }
        }

        public void StartDialog()
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(1);
                return;
            }
            _dialogStep = -1;
            AnimateText.SetTextButtonInteractable(false);
            if (_dialog == _raidPhase.Intro)
            {
                DialogOptions.ShowDialogOptions(_raidPhase.DialogOptions);
            }
            else
            {
                DialogOptions.ShowDialogOptions(Action.Actions);
            }
        }

        public void ChooseDialog(int option)
        {
            if (_dialog == _raidPhase.Intro)
            {
                _dialog = _raidPhase.Dialogs[option];
            }
            else
            {
                _dialog = ActionUtil.PerformAction(_actionDialogModels, option);
            }

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
            _dialogStep = -1;
            _dialog = _raid.DefeatDialog;
            NextStep();
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