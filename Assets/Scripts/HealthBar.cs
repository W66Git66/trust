using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image _hpImg;
    public Image _hpEffectImg;

    public float _maxHealth;
    public float _currentHealth;
    public float buffTime = 0.5f;

    public float HpCoolDown = 1f;

    private Coroutine updateCoroutinel;


    private void Start()
    {
        _currentHealth = _maxHealth;
        UpdateHealthBar();
    }

    public void SetHealth(float health)
    {
        _currentHealth = Mathf.Clamp(health, 0f, _maxHealth);

        UpdateHealthBar();

    }

    private void UpdateHealthBar()
    {
        _hpImg.fillAmount = _currentHealth / _maxHealth;

        if (updateCoroutinel != null)
        {
            StopCoroutine(updateCoroutinel);
        }
        updateCoroutinel = StartCoroutine(UpdateHPEffect());
    }

    private IEnumerator UpdateHPEffect()
    {
        float effectLength = _hpEffectImg.fillAmount - _hpImg.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < buffTime && effectLength != 0)
        {
            elapsedTime += Time.deltaTime;
            _hpEffectImg.fillAmount = Mathf.Lerp(_hpImg.fillAmount + effectLength, _hpImg.fillAmount, elapsedTime / buffTime);
            yield return null;
        }

        _hpEffectImg.fillAmount = _hpImg.fillAmount;
    }
}
