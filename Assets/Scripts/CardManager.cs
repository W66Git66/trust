using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{   
    public List<Card> normalCard;
    public List<Card> specialCard;
    public Card g1, g2;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetNormalCard(out g1, out g2);
            LeanTween.rotate(g1.GetComponent<GameObject>(), new Vector3(0, 0, -5f), 1.5f).setEaseInOutBack();
            LeanTween.moveLocal(g1.GetComponent<GameObject>(), new Vector3(0, 0, 0), 1.5f).setEaseInOutBack();
        }
    }

    public Card GetNormalCard(out Card card1,out Card card2)
    {
        int i = Random.Range(0, 5);
        if(i<2)
        {
            i = 0;
            card1 = normalCard[1];
            card2 = normalCard[2];
            Debug.Log("0");
        }
        else if(i>=2&&i<4)
        {
            i = 1;
            card1 = normalCard[0];
            card2 = normalCard[2];
            Debug.Log("1");
        }
        else 
        {
            i = 2;
            card1 = normalCard[0];
            card2 = normalCard[1];
            Debug.Log("2");
        }
        return specialCard[i];
    }
    public Card GetSpecialCard()
    {
        return specialCard[Random.Range(0, 3)];
    }

    /// <summary>
    /// 判断玩家是否赢过怪物
    /// </summary>
    /// <param name="c1">怪物出的牌</param>
    /// <param name="c2">玩家出的牌</param>
    /// <returns></returns>
    public bool CompareCardStats(Card c1,Card c2)
    {
        if(c1.cardStats==CardStats.rock&&c2.cardStats==CardStats.paper
            ||c1.cardStats==CardStats.paper&&c2.cardStats==CardStats.scissors
            ||c1.cardStats==CardStats.scissors&&c2.cardStats==CardStats.rock)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

}

