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

    public GameObject BrittanyButton;
    public GameObject NormandyButton;
    public GameObject IcelandButton;

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

    void Start()
    {
        if (World.RaidedVillages.Contains(Brittany))
        {
            BrittanyButton.SetActive(false);
        }
        if (World.RaidedVillages.Contains(Normandy))
        {
            NormandyButton.SetActive(false);
        }
        if (World.RaidedVillages.Contains(Iceland))
        {
            IcelandButton.SetActive(false);
        }
    }

    private void SelectRaid(RaidModel raidModel)
    {
        World.ChosenRaid = raidModel;
        SceneManager.LoadScene("Game");
    }
}
