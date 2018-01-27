using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseViking : MonoBehaviour
{
    private List<Transform> images;
    private int activeimage;

    private void Start()
    {
        images = new List<Transform>();
        activeimage = 0;

        foreach (Transform child in gameObject.transform)
        {
            images.Add(child);
        }

        foreach (var image in images)
        {
            image.gameObject.SetActive(false);
        }

        images[activeimage].gameObject.SetActive(true);
    }


    public void SwitchVikting()
    {
        images[activeimage].gameObject.SetActive(false);

        activeimage++;

        if (activeimage >= images.Count)
        {
            activeimage = 0;
        }

        images[activeimage].gameObject.SetActive(true);
    }

    public void VikingChoosed()
    {
        World.Character = activeimage;
        SceneManager.LoadScene("Game");
    }


}
