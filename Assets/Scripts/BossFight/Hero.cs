using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    GamePlayManager manager;

    [Header("Hero Stats")]
    public int health;
    public int damage;
    public float attackSpeed;
    private float lastCallTime;
    private bool isAlive = true;

    [SerializeField]
    private int damageRate;
    [SerializeField]
    private float attackSpeedRate;
    [SerializeField]
    private bool isHealer = false;
    public List<Hero> otherHeros;

    [Header("Boss")]
    public Boss Boss;

    //Animation
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        manager = FindObjectOfType<GamePlayManager>();
    }

    private void Update()
    {
        if (health > 0)  //Checking if hero is alive
        {
            if (Time.time - lastCallTime >= attackSpeed)
            {
                //If healer then heal other heros, or else attack
                if (isHealer)
                {
                    Heal(); Debug.Log("HEAL");
                }

                else Attack(Boss);
            }
        }
        else if(isAlive)   //To Stop Continuous Update
        {
            isAlive = false;
            CheckOtherHeroes();
            Destroy(animator);
            Destroy(gameObject);
        }
    }

    void Attack(Boss boss)
    {
        //Animation
        animator.Play("Attack", 0, 0);

        //Apply Damage on boss
        boss.TakeDamage(damage);

        //reset attack timer
        lastCallTime = Time.time;
    }

    public void Heal()
    {
        foreach (Hero hero in otherHeros)
            hero.health += damage;

        //reset attack timer
        lastCallTime = Time.time;
    }

    public void CheckOtherHeroes()
    {
        bool areAllHerosAlive = true;
        foreach (Hero hero in otherHeros)
       {
         areAllHerosAlive = hero.isAlive;    
       }
        manager.CheckEndGame(areAllHerosAlive);
    }

    //Take Damage
    public void TakeDamage(int damage)
    {
        health -= damage;

       // TakeDamageAnimation();
    }

    private void TakeDamageAnimation()
    {
        animator.Play("Hurt", 0, 0);
    }


    //Buff Hero Functions
    public void IncreaseAttackDamage(int amount)
    {
        amount -= 2;                         //2 is subtracted here to make the multiplier 1, 2, 3 for subsequent 3, 4 or 5 matches
        damage += (int)damageRate * amount;
    }

    public void IncreaseAttackSpeed(int amount)
    {
        amount -= 2;
        attackSpeed -= attackSpeed * attackSpeedRate;
    }
}
