using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace DokiDokiRagnarok.UI
{
    public class DialogOptions : MonoBehaviour
    {
        public Text[] buttonTexts = new Text[4];
        void Start()
        {
            HideDialogOptions();
        }

        public void ShowDialogOptions(string[] newButtonLabels)
        {
            if (newButtonLabels.Length != 4)
            {
                Debug.LogError("newButtonLabels have wrong array size");
            }

            for (int i = 0; i < buttonTexts.Length; i++)
            {
                buttonTexts[i].text = newButtonLabels[i];
            }
            gameObject.SetActive(true);
            
        }

        public void HideDialogOptions()
        {
            gameObject.SetActive(false);
        }
    }
}