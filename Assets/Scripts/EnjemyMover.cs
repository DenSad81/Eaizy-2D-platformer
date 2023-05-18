using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnjemyMover : MonoBehaviour
{
    [SerializeField] private float _pointA;
    [SerializeField] private float _pointB;
    [SerializeField] private float _setpointPosition;
    [SerializeField] private float _velocity;
    [SerializeField] private bool _goRight = true;
    [SerializeField] private bool _goLeft;
    [SerializeField] private float _incrementDecrementPosition;

    private void Start()
    {
        _setpointPosition = _pointA;
        _incrementDecrementPosition = _velocity * Time.deltaTime;
    }

    private void Update()
    {
        if (_setpointPosition > _pointB)
        {
            _goLeft = true;
            _goRight = false;
        }

        if (_setpointPosition < _pointA)
        {
            _goLeft = false;
            _goRight = true;
        }

        var actualPosition = transform.position;

        if (_goRight)
            _setpointPosition += _incrementDecrementPosition;

        if (_goLeft)
            _setpointPosition -= _incrementDecrementPosition;

        actualPosition.x = _setpointPosition;
        transform.position = actualPosition;
    }
}
