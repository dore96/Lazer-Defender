using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private int score = 50;

    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private bool playShake;
    [SerializeField] private bool isplayer;

    private CameraShake cameraShake;
    private AudioPlayer audioHitpPlayer;
    private ScoreKeeper scoreKeeper;
    private LevelManeger levelManeger;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioHitpPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManeger = FindObjectOfType<LevelManeger>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioHitpPlayer.PlayHitClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && playShake)
        {
            cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isplayer)
        {
            scoreKeeper.UpdateScore(score);
        }
        else
        {
            levelManeger.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
