using UnityEngine;

namespace DokiDokiRagnarok.Models
{
    public class RaidPhaseModel : ScriptableObject
    {
        public DialogModel Intro;
        public string[] DialogOptions = new string[4];
        public DialogModel[] Dialogs = new DialogModel[4];
    
    }
}