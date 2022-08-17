using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

    [Header("Get Hit")]
    [SerializeField] private AudioClip hitClip;
    [SerializeField] [Range(0f, 1f)] float hitVolume = 1f;

    void Awake()
    {
        ManageSingelton();
    }

    private void ManageSingelton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        playClip(shootingClip, shootingVolume);
    }

    public void PlayHitClip()
    {
        playClip(hitClip, hitVolume);
    }

    public void playClip(AudioClip Clip, float Volume)
    {
        if (Clip != null)
        {
            AudioSource.PlayClipAtPoint(Clip,
                Camera.main.transform.position, Volume);
        }
    }


}
