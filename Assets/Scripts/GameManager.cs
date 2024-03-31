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

    private bool isBossRound1 = false;//boss是否可以行动
    private bool isBossRound2 = false;
    private bool isPlayer1 = true;
    private bool isPlayer2 = true;//玩家是否可以行动

    private Card c1, c2;//用来存储除boss卡外的两张普通卡
    private Card bossCard;//boss选择的卡牌
    private Card specialCard;//特殊卡
    private Card playerCard1;//玩家一选择的卡牌
    private Card playerCard2;//玩家二选择的卡牌

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
                        Debug.Log("boss回合结束");
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
                        Debug.Log("1选择第一张牌");
                        isPlayer1=false;
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        Debug.Log("1选择第二张牌");
                        isPlayer1 = false;
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        Debug.Log("1选择第三张牌");
                        isPlayer1 = false;
                    }
                }
                if (isPlayer2)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        Debug.Log("2选择第一张牌");
                        isPlayer1 = false;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        Debug.Log("2选择第二张牌");
                        isPlayer1 = false;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Debug.Log("2选择第三张牌");
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

