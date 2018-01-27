using System.Collections.Generic;
using UnityEngine;

namespace DokiDokiRagnarok.Models
{
    public class RaidModel : ScriptableObject
    {
        public string Name;
        public List<RaidPhaseModel> RaidPhases;
        
        public DialogModel VictoryDialog;
        public DialogModel DefeatDialog;
    }
}