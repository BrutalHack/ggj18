﻿using DokiDokiRagnarok.Models;
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
        public ActionController ActionController;

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

                if (_dialog == _raid.DefeatDialog)
                {
                    SceneManager.LoadScene(3);
                    return;
                }

                if (_dialog == _raid.VictoryDialog)
                {
                    World.RaidedVillages.Add(_raid);
                    SceneManager.LoadScene(3);
                    return;
                }

                ShowActionsDialog();
                NextPhase();
                return;
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

        private void ShowActionsDialog()
        {
            
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
                AnimateText.SetTextButtonInteractable(false);
                DialogOptions.ShowDialogOptions(_raidPhase.DialogOptions);

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