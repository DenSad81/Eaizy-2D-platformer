using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAtaked : MonoBehaviour
{
    private Animator _animator2DKnight;
    private bool _isAttack;
    private string _attack = "isAttack";
    private WaitForSeconds _waitFor1Second = new WaitForSeconds(1);

    public bool IsAttackActiv { get; private set; }

    private void Start()
    {
        _animator2DKnight = GetComponent<Animator>();
    }

    private void Update()
    {
        _isAttack = false;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isAttack = true;
            StartCoroutine(CorutineAttackIsActiv());
        }

        _animator2DKnight.SetBool(_attack, _isAttack);
    }

    private IEnumerator CorutineAttackIsActiv()
    {
        IsAttackActiv = true;
        yield return _waitFor1Second;
        IsAttackActiv = false;
    }
}
