using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DokiDokiRagnarok.UI
{
    public class AnimateText : MonoBehaviour
    {
        [SerializeField] private float _letterInterval = 0.01f;
        [SerializeField] private float _newLineInterval = 0.4f;
        public Text TextComponent;
        public Button TextButton;
        public float lineSpacing = 1f;
        public bool InstantText = false;

        void Start()
        {
            TextComponent.lineSpacing = lineSpacing;
        }

        public void ShowText(string message)
        {
            TextComponent.text = "";
            if (InstantText || Application.platform == RuntimePlatform.Android)
            {
                TextComponent.text = message;
                return;
            }
            TextButton.interactable = false;
            StartCoroutine(TypeText(message));
        }

        IEnumerator TypeText(string message)
        {
            foreach (char letter in message)
            {
                TextComponent.text += letter;
                yield return 0;
                if (letter == '\n')
                {
                    yield return new WaitForSeconds(_newLineInterval);
                }
                else
                {
                    yield return new WaitForSeconds(_letterInterval);
                }
            }
            TextButton.interactable = true;
        }

        public void SetTextButtonInteractable(bool newValue)
        {
            TextButton.interactable = newValue;
        }
    }
}