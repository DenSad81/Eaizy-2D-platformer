using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusChecedCollision : MonoBehaviour
{
    [SerializeField] private GameObject _hero;

    private PlayerAtaked _playerAtaked;
    private WaitForSeconds _waitFor1Second = new WaitForSeconds(1);

    public bool BonusMustDie { get; private set; }
    public bool IsCollisionActiv { get; private set; }

    private void Start()
    {
        _playerAtaked = _hero.GetComponent<PlayerAtaked>();
    }

    private void Update()
    {
        BonusMustDie = IsCollisionActiv & _playerAtaked.IsAttackActiv;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMoved>(out PlayerMoved playerMoved))
            StartCoroutine(CorutineCollisionIsActiv());
    }

    private IEnumerator CorutineCollisionIsActiv()
    {
        IsCollisionActiv = true;
        yield return _waitFor1Second;
        IsCollisionActiv = false;
    }
}
