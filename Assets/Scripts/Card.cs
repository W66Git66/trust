using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
   [SerializeField] public CardStats cardStats;
}
public enum CardStats
{
    rock,
    scissors,
    paper,
    jia,
    bu,
    zhen,
}
