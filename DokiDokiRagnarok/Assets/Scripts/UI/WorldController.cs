using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DokiDokiRagnarok.Models;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{

    public RaidModel Brittany;
    public RaidModel Iceland;
    public RaidModel Normandy;

    public void SelectBrittany()
    {
        SelectRaid(Brittany);
    }

    public void SelectIceland()
    {
        SelectRaid(Iceland);
    }

    public void SelectNormandy()
    {
        SelectRaid(Normandy);
    }

    private void SelectRaid(RaidModel raidModel)
    {
        World.ChosenRaid = raidModel;
        SceneManager.LoadScene("Game");
    }
}
