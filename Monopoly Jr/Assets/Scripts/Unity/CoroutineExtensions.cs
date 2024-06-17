using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity
{
    public static class CoroutineExtensions
    {
        public static Task AsTask(this IEnumerator coroutine, MonoBehaviour monoBehaviour)
        {
            var tcs = new TaskCompletionSource<bool>();
            monoBehaviour.StartCoroutine(RunCoroutine(coroutine, tcs));
            return tcs.Task;
        }

        private static IEnumerator RunCoroutine(IEnumerator coroutine, TaskCompletionSource<bool> tcs)
        {
            while (true)
            {
                try
                {
                    if (!coroutine.MoveNext())
                    {
                        break;
                    }
                }
                catch (System.Exception ex)
                {
                    tcs.SetException(ex);
                    yield break;
                }
                yield return coroutine.Current;
            }
            tcs.SetResult(true);
        }
    }
}