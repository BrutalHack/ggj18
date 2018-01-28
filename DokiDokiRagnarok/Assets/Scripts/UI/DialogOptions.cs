using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOptions : MonoBehaviour
{

    void Start()
    {
        HideDialogOptions();
    }

    public void ShowDialogOptions()
    {
        gameObject.SetActive(true);
    }

    public void HideDialogOptions()
    {
        gameObject.SetActive(false);
    }
}
