using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecedCollision : MonoBehaviour
{
    [SerializeField] private string _tagEnemy;
    [SerializeField] private Vector2 _startPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyMover>(out EnemyMover enemyMover))
            transform.position = _startPosition;
    }
}
