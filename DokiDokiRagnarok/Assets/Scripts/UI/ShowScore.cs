using UnityEngine;
using UnityEngine.UI;

namespace DokiDokiRagnarok.UI
{
    public class ShowScore : MonoBehaviour
    {
        private Text _textComponent;

        void Start()
        {
            _textComponent = GetComponent<Text>();
        }

        void Update()
        {
            _textComponent.text = Viking.Score.ToString();
        }
    }
}