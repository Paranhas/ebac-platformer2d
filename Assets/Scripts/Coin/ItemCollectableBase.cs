using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource audioSource;

    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    private void Awake()
    {
        if(particleSystem == null)particleSystem.transform.SetParent(null);
    }

    protected virtual void Collect()
    {
        Debug.Log("Collect");
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) { particleSystem.Play(); }
        if(audioSource != null) { audioSource.Play(); }
    }
}
