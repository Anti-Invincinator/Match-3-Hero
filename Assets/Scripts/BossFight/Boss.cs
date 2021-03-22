using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GamePlayManager manager;

    [Header("Stats")]
    public int health;
    public float attackSpeed;
    public int damage;
    public int damageRate = 3;
    public float attackSpeedRate = 0.05f;

    private float lastAttackTime;
    private float lastBuffTime;
    public float buffRate;

    [SerializeField]
    List<Hero> heros;

    SpriteRenderer bossSprite;

    [SerializeField]
    List<Sprite> bossTypes;


    private void Start()
    {
        bossSprite = GetComponent<SpriteRenderer>();

        bossSprite.sprite = bossTypes[Random.Range(0, bossTypes.Count) + 1];
    }

    private void Update()
    {
        //Attacking
        if (Time.time - lastAttackTime >= attackSpeed)  AttackHero();

        //Destroying if Dead
        if (health <= 0) manager.EndGame();

        //Buffing in Intervals
        if (Time.time - lastBuffTime >= buffRate) BuffBoss();
    }

    void AttackHero()
    {
        foreach (Hero hero in heros)
        {
            hero.TakeDamage(damage);
            Debug.Log("Hero Type : " + heros.IndexOf(hero) + "health: " + hero.health);     
        }

        lastAttackTime = Time.time;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
       Debug.Log("Boss Took Damage, Boss Health : " + health);

        StartCoroutine(FlashRed(bossSprite));
    }

    //Buff the boss atk damage and speed
    public void BuffBoss()
    {
        attackSpeed -= attackSpeedRate;
        damage += damageRate;

        lastBuffTime = Time.time;
    }

    //Make Enemy/Player Flash Red when they take damage
    public IEnumerator FlashRed(SpriteRenderer sprite)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sprite.color = Color.white;
    }
}
