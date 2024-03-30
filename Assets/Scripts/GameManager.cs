using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    public SceneStats _curStats;

    private float bossAttackTime;
    private float PlayerWaitTime;

    private bool isPlayer1 = false;
    private bool isPlayer2 = false;

    private Card bossCard;
    private Card playerCard1;
    private Card playerCard2;
    private void Update()
    {
        
    }

    private void Round()
    {
        switch(_curStats)
        {
            case SceneStats.BossRound1:
                bossCard = CardManager.Instance.GetNormalCard(out playerCard1,out playerCard2);
                break;
            case SceneStats.BossRound2:

                break;
            case SceneStats.PlayerRound:

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

