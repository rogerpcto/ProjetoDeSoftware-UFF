using System.Collections;
using UnityEngine;

namespace Unity
{
    public class Janela : MonoBehaviour
    {
        protected IEnumerator Abrir()
        {
            Vector2 scaleInicial = Vector3.zero;
            Vector2 scaleFinal = Vector2.one;
            transform.localScale = scaleInicial;

            float duration = .15f;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                transform.localScale = Vector3.Lerp(scaleInicial, scaleFinal, normalizedTime);
                yield return null;
            }
        }

        protected IEnumerator Fechar()
        {
            Vector2 scaleInicial = Vector3.one;
            Vector2 scaleFinal = Vector2.zero;
            transform.localScale = scaleInicial;

            float duration = .15f;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                transform.localScale = Vector3.Lerp(scaleInicial, scaleFinal, normalizedTime);
                yield return null;
            }
            gameObject.SetActive(false);
        }
    }
}