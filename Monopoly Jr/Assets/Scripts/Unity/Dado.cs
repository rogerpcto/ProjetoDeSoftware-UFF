using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class Dado : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Sprite[] _sprites;
        public IEnumerator RolarDado(int resultado)
        {
            _image.enabled = true;

            System.Random random = new();
            var sprites = _sprites.OrderBy(x => random.Next());

            foreach (Sprite sprite in sprites)
            {
                _image.sprite = sprite;
                yield return new WaitForSeconds(0.25f);
            }
            _image.sprite = _sprites[resultado - 1];
            yield return new WaitForSeconds(1);
            _image.enabled = false;
        }
    }
}