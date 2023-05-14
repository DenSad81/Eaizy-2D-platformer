using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlaeyrMoved : MonoBehaviour
{
    [SerializeField] private float _runSpead = 10f;
    [SerializeField] private float _walkSpead = 5f;

    private Animator _animator2DKnight;
    private string _actSpeedX = "actSpeedX";

    private void Start()
    {
        _animator2DKnight = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        float actualSpeedX = 0;
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.PageUp))
        {
            actualSpeedX = _walkSpead;

            if (Input.GetKey(KeyCode.Space))
                actualSpeedX = _runSpead;
        }

        if (Input.GetKey(KeyCode.Home))
        {
            actualSpeedX = -_walkSpead;

            if (Input.GetKey(KeyCode.Space))
                actualSpeedX = -_runSpead;
        }

        position.x += actualSpeedX * Time.deltaTime;
        _animator2DKnight.SetFloat(_actSpeedX, actualSpeedX);

        transform.position = position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}