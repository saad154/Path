using System.Collections;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1.5f;

    public void FadeInAndPause()
    {
        StartCoroutine(FadeAndPause(1f));
    }

    IEnumerator FadeAndPause(float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.unscaledDeltaTime; // IMPORTANT: use unscaledDeltaTime
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;

        // Now pause the game
        Time.timeScale = 0f;
    }
}
