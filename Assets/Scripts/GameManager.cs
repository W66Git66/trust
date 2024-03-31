using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{ 
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    public SceneStats _curStats;

    private float bossAttackTime;
    private float PlayerWaitTime;

    private bool isBossRound1 = false;//boss�Ƿ�����ж�
    private bool isBossRound2 = false;
    private bool isPlayer1 = true;
    private bool isPlayer2 = true;//����Ƿ�����ж�

    private Card c1, c2;//�����洢��boss�����������ͨ��
    private Card bossCard;//bossѡ��Ŀ���
    private Card specialCard;//���⿨
    private Card playerCard1;//���һѡ��Ŀ���
    private Card playerCard2;//��Ҷ�ѡ��Ŀ���

    private void Update()
    {
        
    }

    private void Round()
    {
        switch(_curStats)
        {
            case SceneStats.BossRound1:
                if (isBossRound1)
                {
                    bossAttackTime-=Time.deltaTime;
                    bossCard = CardManager.Instance.GetNormalCard(out c1, out c2);
                    if(bossAttackTime < 0)
                    {
                        _curStats = SceneStats.PlayerRound;
                        bossAttackTime = 5f;
                        Debug.Log("boss�غϽ���");
                    }
                }
                break;
            case SceneStats.BossRound2:

                break;
            case SceneStats.PlayerRound:
                if(isPlayer1)
                {
                    if(Input.GetKeyDown(KeyCode.A))
                    {
                        Debug.Log("1ѡ���һ����");
                        isPlayer1=false;
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        Debug.Log("1ѡ��ڶ�����");
                        isPlayer1 = false;
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        Debug.Log("1ѡ���������");
                        isPlayer1 = false;
                    }
                }
                if (isPlayer2)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        Debug.Log("2ѡ���һ����");
                        isPlayer1 = false;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        Debug.Log("2ѡ��ڶ�����");
                        isPlayer1 = false;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Debug.Log("2ѡ���������");
                        isPlayer1 = false;
                    }
                }
                if(isPlayer1==false&&isPlayer2==false)
                {
                    if(UIManager.Instance.bossStats.)
                    _curStats = SceneStats.BossRound1;
                }
                break;
        }
    }
}

public enum SceneStats    
{
    BossRound1,
    BossRound2,
    PlayerRound,
}

