using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    ScoreText ScoreText;
    [Header("Enemy Stats")]
    [SerializeField] float health = 100f;
    [SerializeField] int PointsForEnemy = 100;
    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShoots = 0.2f;
    [SerializeField] float maxTimeBetweenShoots = 3f;
    [SerializeField] float LaserSpeed = 10f;
    [SerializeField] GameObject LaserPrefab;
    [Header("Effects")]    
    [SerializeField] GameObject ExplosionVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip EnemyShooting;
    [SerializeField] AudioClip EnemyKilled;
    [SerializeField] [Range(0, 1)] float EnemyShootingVolume = 0.3f;
    [SerializeField] [Range(0,1)] float EnemyDeathVolume = 0.3f;
    // Use this for initialization
    void Start () {
        ScoreText = FindObjectOfType<ScoreText>();
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShoots,maxTimeBetweenShoots);
    }
	
	// Update is called once per frame
	void Update () {
        FireTimer();
	}

    private void FireTimer()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var LaserClone = Instantiate(LaserPrefab, transform.position, Quaternion.identity)
                         as GameObject;
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
        LaserClone.GetComponent<Rigidbody2D>().velocity += new Vector2(0, -LaserSpeed);
        AudioSource.PlayClipAtPoint(EnemyShooting,Camera.main.transform.position,EnemyShootingVolume);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (!otherObject) { return; }
        HitDetection(otherObject);
    }

    private void HitDetection(Collider2D otherObject)
    {
        DamageDealer damageDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            health -= damageDealer.GetDamage();
            if (otherObject.name != "Player")
                Destroy(otherObject.gameObject);
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        ScoreText.UpdateScore(PointsForEnemy);
        AudioSource.PlayClipAtPoint(EnemyKilled, Camera.main.transform.position,EnemyDeathVolume);
        var Explosion = Instantiate(ExplosionVFX, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(Explosion, durationOfExplosion);
    }
}
