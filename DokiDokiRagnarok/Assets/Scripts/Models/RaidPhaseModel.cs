using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using DokiDokiRagnarok.Models;
using UnityEngine;

public class RaidPhaseModel : ScriptableObject
{
    [Header("Optional")] public List<DialogSegmentModel> Intro;

    [Header("Mandatory")] public string[] ActionNames = new string[4];
    public DialogSegmentModel[] ActionDialogSegmentsModel = new DialogSegmentModel[4];
}