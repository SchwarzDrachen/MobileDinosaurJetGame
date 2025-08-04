using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pauseMoveTimer;
    private bool moveLeft = true;
    private Vector2 targetLeft;
    private Vector2 targetRight;
    void Update()
    {
        if (moveLeft)
        {
            StartCoroutine(MovingLeft());
        }
        else
        {
            StartCoroutine(MovingRight());
        }
    }

    IEnumerator MovingLeft()
    {
        targetLeft = new Vector2(transform.position.x - 1, transform.position.y);
        if (transform.position.x > -2.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetLeft, moveSpeed * Time.deltaTime);
        }
        yield return new WaitForSeconds(pauseMoveTimer);
        moveLeft = false;
    }

    IEnumerator MovingRight()
    {
        targetRight = new Vector2(transform.position.x + 1, transform.position.y);
        if (transform.position.x < 2.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetRight, moveSpeed * Time.deltaTime);
        }
        yield return new WaitForSeconds(pauseMoveTimer);
        moveLeft = true;
    }
}