using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [Header("Heros")]
    [SerializeField]
    Hero Knight_1;
    [SerializeField]
    Hero Knight_2;
    [SerializeField]
    Hero Mage;
    [SerializeField]
    Hero Healer;

    [Header("Boss")]
    [SerializeField]
    Boss boss;


    public void CheckMoveType(int value, int amount)
    {
        if (value == 1) //Increase Attack Damage and Attack Speed of Knight 1
        {
            Knight_1.IncreaseAttackDamage(amount);
            Knight_1.IncreaseAttackSpeed(amount);
        }

        if (value == 2) //Increase Attack Damage and Attack Speed of Knight 2
            Debug.Log("Increase Attack Damage and Attack Speed of Knight 2");
        {
            Knight_2.IncreaseAttackDamage(amount);
            Knight_2.IncreaseAttackSpeed(amount);
        }

        if (value == 3) //Increase Attack Damage and Attack Speed of Boss
            Debug.Log("Increase Attack Damage and Attack Speed of Boss");
        {
           // boss.IncreaseAttackDamage(amount);
           // boss.IncreaseAttackSpeed(amount);
        }

        if (value == 4) //Increase Attack Damage and Attack Speed of Healer
            Debug.Log("Increase Heal Amount and Attack Speed of Healer");
        {
            Healer.IncreaseAttackDamage(amount);
            Healer.IncreaseAttackSpeed(amount);
        }

        if (value == 5) //Increase Attack Damage and Attack Speed of Mage
            Debug.Log("Increase Attack Damage and Attack Speed of Mage");
        {
            Mage.IncreaseAttackDamage(amount);
            Mage.IncreaseAttackSpeed(amount);
        }
    }
}
