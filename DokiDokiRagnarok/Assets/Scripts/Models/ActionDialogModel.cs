using System.Collections.Generic;
using DokiDokiRagnarok.Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace DokiDokiRagnarok.Models
{
    public class ActionDialogModel : ScriptableObject
    {
        public List<ActionConditions> Conditions;
        public List<int> Score;
        public List<DialogModel> Dialogs;
    }
}