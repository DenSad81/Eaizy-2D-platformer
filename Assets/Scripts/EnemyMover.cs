using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float[] _points;
    [SerializeField] private float _velocity;

    private float _targetPoint;
    private int _numberOfActualPoint = 0;

    private void Start()
    {
        _targetPoint = _points[0];
    }

    private void Update()
    {
        if (_targetPoint == _points[_numberOfActualPoint])
        {
            _numberOfActualPoint++;

            if (_numberOfActualPoint == _points.Length)
                _numberOfActualPoint = 0;
        }

        _targetPoint = Mathf.MoveTowards(_targetPoint, _points[_numberOfActualPoint], _velocity * Time.deltaTime);

        var actualPosition = transform.position;
        actualPosition.x = _targetPoint;
        transform.position = actualPosition;
    }
}
