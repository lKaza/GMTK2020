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
        if (pct >= 0.9f - Mathf.Epsilon)
        {
            foreground.GetComponent<Image>().color = new Color32(16, 255, 0, 255); //verde
            
        }
        if (pct <= 0.75f - Mathf.Epsilon)
        {
            foreground.GetComponent<Image>().color = new Color32(255, 255, 0, 255); //rojo //verde
        }
        if (pct <= 0.25f - Mathf.Epsilon)
        {
            foreground.GetComponent<Image>().color = new Color32(255, 0, 0, 255); //rojo //verde
        }
        

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
