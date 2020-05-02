using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rune", menuName = "NewRuneVairable/Rune", order = 1)]
public class Rune : ScriptableObject
{
    public GameObject runeObject;

    [Header("RuneVariable")]
    public string runeName;
    public string runeDesc;
    [Header("RuneRewards")]
    public int skillPoint;
}
