using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NpcStats : MonoBehaviour
{
    public float _curHp;
    public float _MaxHp;
    public int _curWealth;

    public Sprite normal;
    public Sprite getHurt;
    public SpriteRenderer spriteRenderer;
    public Image _hpImg;
    public Image _hpEffectImg;

    public Text text;

    public float buffTime = 0.5f;

    private Coroutine updateCoroutinel;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _curHp = _MaxHp;
        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
        if (text != null)
        {            
            text.text = _curWealth.ToString();
        }
    }
    public void SetHealth()
    {

        UpdateHealthBar();

    }

    private void UpdateHealthBar()
    {
        _hpImg.fillAmount = _curHp / _MaxHp;

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
