using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerJumped : MonoBehaviour
{
    [SerializeField] private float _deltaYForJump = 0.05f;
    [SerializeField] private int _tallForJump = 100;

    private Rigidbody2D _rigitbody2DKnight;
    private bool _corutineJumpUpIsWork;
    private bool _jumpNotFinish;

    private void Start()
    {
        _rigitbody2DKnight = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Math.Abs(_rigitbody2DKnight.velocity.y) > 0.01f)
            _jumpNotFinish = true;
        else
            _jumpNotFinish = false;

        if (Input.GetKeyDown(KeyCode.E) & !_corutineJumpUpIsWork & !_jumpNotFinish)
            StartCoroutine(JumpUp());
    }

    private IEnumerator JumpUp()
    {
        _corutineJumpUpIsWork = true;

        for (int i = 0; i < _tallForJump; i++)
        {
            Vector2 position = transform.position;
            position.y += _deltaYForJump;
            transform.position = position;
            yield return null;
        }
        _corutineJumpUpIsWork = false;
    }
}