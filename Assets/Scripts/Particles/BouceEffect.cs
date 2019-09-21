using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouceEffect : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();    
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
        particleSystem.GetParticles(particles);

        for(int i = 0; i < numCollisionEvents; i++)
        {
            
        }
    }
}
