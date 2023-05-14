using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusChecedCollision : MonoBehaviour
{
    [SerializeField] private string _nameHero;
    private PlaeyrAtaked _plaeyerAtaked;

    public bool BonusMustDie { get; private set; }

    public bool IsCollisionActiv { get; private set; }

    private void Start()
    {
        var _objectWithName = GameObject.Find(_nameHero);
        _plaeyerAtaked = _objectWithName.GetComponent<PlaeyrAtaked>();
    }

    private void Update()
    {
        BonusMustDie = IsCollisionActiv & _plaeyerAtaked.IsAttakActiv;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == _nameHero)
            StartCoroutine(CorutineCollisionIsActiv());
    }

    private IEnumerator CorutineCollisionIsActiv()
    {
        IsCollisionActiv = true;
        yield return new WaitForSeconds(1);
        IsCollisionActiv = false;
    }
}