using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100;

    public int worth = 50;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }
    Vector3 Nextdir = new Vector3(0f, 0f, 0f);
  
    public void TakeDamage(float amount)
    {
        health -= amount;
       
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed= startSpeed*(1f - pct);
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += worth;
        Destroy(gameObject);
    }

    // Update is called once per frame
   
}
