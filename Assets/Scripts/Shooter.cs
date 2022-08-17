using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectTilePrefab;
    [SerializeField] private float projectTileSpeed = 10f;
    [SerializeField] private float projectLifeTime = 5f;
    [SerializeField] private float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] private float firingRateVarience = 0f;
    [SerializeField] private float minFiringRate = 0.1f;
    [SerializeField] private bool isAI;

    [HideInInspector] public bool isFiring;

    private Coroutine firingCoroutine;
    private AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (isAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(isFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinously());
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectTilePrefab, 
                transform.position,Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectTileSpeed;
            }

            Destroy(instance, projectLifeTime);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(GetRandomFiringTime());
        }

    }

    public float GetRandomFiringTime()
    {
        float timeToNextFire = Random.Range(baseFiringRate - firingRateVarience,
            baseFiringRate + firingRateVarience);
        return Mathf.Clamp(timeToNextFire, minFiringRate, float.MaxValue);
    }
}
