using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BonusChecedCollision))]
[RequireComponent(typeof(ParticleSystem))]

public class BonusDied : MonoBehaviour
{
    private BonusChecedCollision _bonusChecedCollision;
    private ParticleSystem _particleSystem;

    void Start()
    {
        _bonusChecedCollision= GetComponent<BonusChecedCollision>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

  
    void Update()
    {
        if (_bonusChecedCollision.BonusMustDie)
        {
            if (gameObject != null)
            {
                _particleSystem.Play();
                StartCoroutine(CorutineDestroyObject());
            }
        }
    }

    private IEnumerator CorutineDestroyObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
