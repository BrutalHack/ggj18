using System.Collections.Generic;
using DokiDokiRagnarok.Models;
using UnityEngine;

public class RaidModel : ScriptableObject
{
    public string Name;
    public List<RaidPhaseModel> RaidPhases;
}