using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foreground;
    [SerializeField] float updateSpeedSeconds = 0.5f;

    private void Awake()
    {
       FindObjectOfType<Health>().OnHealthPcChanged += HandleHealthChange;
    }

    private void HandleHealthChange(float pct)
    {
        StartCoroutine(ChangetoPct(pct));
    }

    IEnumerator ChangetoPct(float pct)
    {
        float preChangePct = foreground.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foreground.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
        foreground.fillAmount = pct;
    }
}
