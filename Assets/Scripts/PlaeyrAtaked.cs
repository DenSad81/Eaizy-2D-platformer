using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlaeyrAtaked : MonoBehaviour
{
    private Animator _animator2DKnight;
    private bool _isAttak;
    private string _isAttac = "isAttac";

    public bool IsAttakActiv { get; private set; }

    private void Start()
    {
        _animator2DKnight = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        _isAttak = false;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isAttak = true;
            StartCoroutine(CorutineAttakIsActiv());
        }

        _animator2DKnight.SetBool(_isAttac, _isAttak);
    }

    private IEnumerator CorutineAttakIsActiv()
    {
        IsAttakActiv = true;
        yield return new WaitForSeconds(1);
        IsAttakActiv = false;
    }
}
