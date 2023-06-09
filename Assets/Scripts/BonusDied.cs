using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BonusChecedCollision))]
[RequireComponent(typeof(ParticleSystem))]

public class BonusDied : MonoBehaviour
{
    private BonusChecedCollision _bonusChecedCollision;
    private ParticleSystem _particleSystem;
    private WaitForSeconds _waitFor2Seconds = new WaitForSeconds(2);

    private void Start()
    {
        _bonusChecedCollision = GetComponent<BonusChecedCollision>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
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
        yield return _waitFor2Seconds;
        Destroy(gameObject);
    }
}
