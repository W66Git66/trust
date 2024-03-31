using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{   
    public List<GameObject> normalCard;
    public List<GameObject> specialCard;
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

    }

    public GameObject GetNormalCard(out GameObject card1,out GameObject card2)
    {
        int i = Random.Range(0, 5);
        if(i<2)
        {
            i = 0;
            card1 = normalCard[1];
            card2 = normalCard[2];
        }
        else if(i>=2&&i<4)
        {
            i = 1;
            card1 = normalCard[0];
            card2 = normalCard[2];
        }
        else 
        {
            i = 2;
            card1 = normalCard[0];
            card2 = normalCard[1];
        }
        return normalCard[i];
    }
    public GameObject GetSpecialCard()
    {
        return specialCard[Random.Range(0, 3)];
    }

    /// <summary>
    /// 判断玩家是否赢过怪物
    /// </summary>
    /// <param name="c1">怪物出的牌</param>
    /// <param name="c2">玩家出的牌</param>
    /// <returns>返回为真，玩家胜利</returns>
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

