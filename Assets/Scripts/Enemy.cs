using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem ChipExplosion;
    public ParticleSystem Smoke;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void DestroyEnemy()
    {
        ChipExplosion.Play();
        Smoke.Play();
        Destroy(gameObject, 0.5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            DestroyEnemy();
        }
    }
}
