using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

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

    [SerializeField]private float bossAttackTime=5f;
    private float PlayerWaitTime;

    private bool isBossRound1 = true;//boss�Ƿ�����ж�
    private bool isBossRound2 = false;
    private bool isPlayer1 = true;
    private bool isPlayer2 = true;//����Ƿ�����ж�

    private GameObject c1, c2;//�����洢��boss�����������ͨ��
    private GameObject bossCard;//bossѡ��Ŀ���
    private GameObject specialCard;//���⿨
    private GameObject playerCard1;//���һѡ��Ŀ���
    private GameObject playerCard2;//��Ҷ�ѡ��Ŀ���

    public NpcStats bossStats;
    public NpcStats Player1Stats;
    public NpcStats Player2Stats;

    private void Update()
    {
        Round();

    }

    private void Round()
    {
        switch(_curStats)
        {
            case SceneStats.BossRound1:
                if (isBossRound1)
                {
                    bossAttackTime -= Time.deltaTime;

                    if (bossAttackTime < 0)
                    {
                        bossAttackTime = 3f;//���﹥�����
                        isBossRound1 = false;
                        bossCard = CardManager.Instance.GetNormalCard(out c1, out c2);
                        specialCard = CardManager.Instance.GetSpecialCard();

                        moveCard();
                        _curStats = SceneStats.PlayerRound;
                    }
                }
                break;
            case SceneStats.BossRound2:
                if (isBossRound2)
                {
                    bossAttackTime -= Time.deltaTime;

                    if (bossAttackTime < 0)
                    {
                        bossAttackTime = 3f;//���﹥�����
                        isBossRound2 = false;
                        bossCard = CardManager.Instance.GetNormalCard(out c1, out c2);
                        specialCard = CardManager.Instance.GetSpecialCard();

                        moveCard();
                        _curStats = SceneStats.PlayerRound;
                    }
                }
                break;
            case SceneStats.PlayerRound:
                if(isPlayer1)
                {
                    if(Input.GetKeyDown(KeyCode.A))
                    {
                        isPlayer1 = false;
                        playerCard1 = c1;
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        isPlayer1 = false;
                        playerCard1 = c2;
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        isPlayer1 = false;
                        playerCard1 = specialCard;
                    }
                }
                if (isPlayer2)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        isPlayer2 = false;
                        playerCard2 = c1;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        isPlayer2 = false;
                        playerCard2 = c2;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {   
                        isPlayer2 = false;
                        playerCard2 = specialCard; 
                    }
                }
                if (isPlayer1 == false && isPlayer2 == false)
                {
                    isPlayer1 = true;
                    isPlayer2 = true;
                    isBossRound1 = true;
                    isBossRound2=true;
                    StartCoroutine(BossHp());
                }
                break;
        }
    }
    IEnumerator BossHp()
    {
        
        if (bossStats._curHp > bossStats._MaxHp / 2)
        {
            yield return new WaitForSeconds(1f);
             _curStats = SceneStats.BossRound1;
        }
        else
        {   
            yield return new WaitForSeconds(1f);
            _curStats = SceneStats.BossRound2;
            Debug.Log("111");
        }
        judgeBossAttack();
        ReturnCard();
    }
    
    private void ReturnCard()
    {
        LeanTween.rotate(c1, new Vector3(-45, 0, -45f), 1.5f).setEaseInOutBack();
        LeanTween.moveLocal(c1, new Vector3(0, 0, 0), 1.5f).setEaseInOutBack();
        LeanTween.rotate(c2, new Vector3(-45, 0, -45f), 1.5f).setEaseInOutBack();
        LeanTween.moveLocal(c2, new Vector3(0, 0, 0), 1.5f).setEaseInOutBack();
        LeanTween.rotate(specialCard, new Vector3(-45, 0, -45f), 1.5f).setEaseInOutBack();
        LeanTween.moveLocal(specialCard, new Vector3(0, 0, 0), 1.5f).setEaseInOutBack();
    }
    private void moveCard()
    {
        LeanTween.rotate(c1, new Vector3(0, 0, -3f), 1.5f).setEaseInOutBack();
        LeanTween.moveLocal(c1, new Vector3(850, 0, 0), 1.5f).setEaseInOutBack();
        LeanTween.rotate(c2, new Vector3(0, 0, -3f), 1.5f).setEaseInOutBack();
        LeanTween.moveLocal(c2, new Vector3(1250, 0, 0), 1.5f).setEaseInOutBack();
        LeanTween.rotate(specialCard, new Vector3(0, 0, -3f), 1.5f).setEaseInOutBack();
        LeanTween.moveLocal(specialCard, new Vector3(1650, 0, 0), 1.5f).setEaseInOutBack();
    }

    //�жϲ�ִ�й����߼�
    private void judgeBossAttack()
    {
        if (_curStats == SceneStats.BossRound1)
        {
            if (ifAttack() == -1)
            {
                BossAttack();
            }
            if (ifAttack() == 1)
            {
                judgePlayerAttack(playerCard1, Player1Stats, Player2Stats);
                //if(playerCard1.GetComponent<Card>().cardStats!=CardStats.bu&&
                //    playerCard1.GetComponent<Card>().cardStats != CardStats.jia&&
                //    playerCard1.GetComponent<Card>().cardStats != CardStats.zhen)
                //GetHurt(bossStats, 5f);
                //if (bossStats._curWealth >= 5)
                //{
                //    GetWealth(Player2Stats, bossStats, 5);
                //}
                //if (Player1Stats._curWealth >=10 && Player2Stats._curWealth >= 10)
                //{
                //    GetWealth(Player1Stats, Player2Stats, 10);
                //}
                //Player2Ǯ������
            }
            else if (ifAttack() == 2)
            {
                GetHurt(bossStats, 5f);
                if (bossStats._curWealth >= 5)
                {
                    GetWealth(Player1Stats, bossStats, 5);
                }
                if (Player1Stats._curWealth >= 10 && Player2Stats._curWealth >= 10)
                {
                    GetWealth(Player2Stats, Player1Stats, 10);
                }
                //Player1Ǯ������
            }
        }
        else if (_curStats == SceneStats.BossRound2 && ifAttack() != 0)
        {
            BossAttack();
            if (ifAttack() == 1)
            {

                GetHurt(bossStats, 5f);
                if (bossStats._curWealth >= 5)
                {
                    GetWealth(Player2Stats, bossStats, 5);
                }
                if (Player1Stats._curWealth >= 10 && Player2Stats._curWealth >= 10)
                {
                    GetWealth(Player1Stats, Player2Stats, 10);
                }
                //Player2Ǯ������
            }
            else if (ifAttack() == 2)
            {
                GetHurt(bossStats, 5f);
                if (bossStats._curWealth >= 5)
                {
                    GetWealth(Player1Stats, bossStats, 5);
                }
                if (Player1Stats._curWealth >= 10 && Player2Stats._curWealth >= 10)
                {
                    GetWealth(Player2Stats, Player1Stats, 10);
                }
                //Player1Ǯ������
            }
        }
        if (ifAttack() == 0)
        {
            GetHurt(bossStats, 10f);
            if (bossStats._curWealth >= 5)
            {
                GetWealth(Player1Stats, bossStats, 5);
                GetWealth(Player2Stats, bossStats, 5);
            }
        }

    }
    private void BossAttack()
    {
        if (bossCard.GetComponent<Card>().cardStats == CardStats.rock)
        {
            GetHurt(Player1Stats, 5f);
            GetHurt(Player2Stats, 5f);
        }
        else if (bossCard.GetComponent<Card>().cardStats == CardStats.scissors)
        {
            int i = Random.Range(0, 2);
            if (i == 0)
            {
                GetHurt(Player1Stats, 10f);
            }
            else
            {
                GetHurt(Player2Stats, 10f);
            }
        }
        else if (bossCard.GetComponent<Card>().cardStats == CardStats.paper)
        {
            GetHurt(bossStats, -10f);
        }
    }
    private int ifAttack()
    {
        if (CardManager.Instance.CompareCardStats(bossCard.GetComponent<Card>(), playerCard1.GetComponent<Card>())
            && CardManager.Instance.CompareCardStats(bossCard.GetComponent<Card>(), playerCard2.GetComponent<Card>()))
        {
            return 0;//�������ɹ�           
        }
        else if (CardManager.Instance.CompareCardStats(bossCard.GetComponent<Card>(), playerCard1.GetComponent<Card>())
            || CardManager.Instance.CompareCardStats(bossCard.GetComponent<Card>(), playerCard2.GetComponent<Card>()))
        {
            
            if (CardManager.Instance.CompareCardStats(playerCard1.GetComponent<Card>(), playerCard2.GetComponent<Card>()))
            {  
                return 1;//���1�������2
            }
            else
            {
                return 2;//���2�������1
            }
        }
        else
        {
            
            return -1;//������ʧ��
        }
    }

    public void GetHurt(NpcStats npcStats, float damage)
    {
        npcStats._curHp -= damage;
        StartCoroutine(ChangeSprite(npcStats));
    }
    IEnumerator ChangeSprite(NpcStats n)
    {
        n.spriteRenderer.sprite = n.getHurt;
        yield return new WaitForSeconds(1f);
        n.spriteRenderer.sprite = n.normal;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="npcStats1">������</param>
    /// <param name="npcStats2">�ܻ���</param>
    /// <param name="damage"></param>
    public void GetWealth(NpcStats npcStats1, NpcStats npcStats2, int damage)
    {
        npcStats1._curWealth += damage;
        npcStats2._curWealth -= damage;

    }

    private void judgePlayerAttack(GameObject pc,NpcStats p1,NpcStats p2)
    {
        if (pc.GetComponent<Card>().cardStats != CardStats.bu &&
                    pc.GetComponent<Card>().cardStats != CardStats.jia &&
                    pc.GetComponent<Card>().cardStats != CardStats.zhen)
            GetHurt(bossStats, 5f);
        if (bossStats._curWealth >= 5)
        {
            GetWealth(p2, bossStats, 5);
        }
        if (p1._curWealth >= 10 && p2._curWealth >= 10)
        {
            GetWealth(p1, p2, 10);
        }
    }
}



public enum SceneStats    
{
    BossRound1,
    BossRound2,
    PlayerRound,
}

