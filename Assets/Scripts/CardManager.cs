using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{   
    public List<GameObject> normalCard;
    public List<GameObject> specialCard;
    public GameObject g1, g2;
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
        }
    }

    public GameObject GetNormalCard(out GameObject card1,out GameObject card2)
    {
        int i = Random.Range(0, 5);
        if(i<2)
        {
            i = 0;
            card1 = normalCard[1];
            card2 = normalCard[2];
            Debug.Log("0");
        }
        else if(i<4)
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
    public GameObject GetSpecialCard()
    {
        return specialCard[Random.Range(0, 3)];
    }

}
