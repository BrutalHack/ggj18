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

        void Start()
        {
            string message = @"My name is Olaf!
I am a true Viking and, thus, pretty much a certified badass.
Yet I've never actually raided a village before!";
            DisplayText(message);
        }

        void DisplayText(string message)
        {
            TextComponent = GetComponent<Text>();
            TextComponent.text = "";
            StartCoroutine(TypeText(message));
        }

        IEnumerator TypeText(string message)
        {
            foreach (char letter in message)
            {
                TextComponent.text += letter;
                yield return 0;
                Debug.Log(letter == '\n');
                if (letter == '\n')
                {
                    yield return new WaitForSeconds(_newLineInterval);
                }
                else
                {
                    yield return new WaitForSeconds(_letterInterval);
                }
            }
        }
    }
}