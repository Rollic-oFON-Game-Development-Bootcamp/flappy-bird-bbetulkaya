using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] public bool isCanMove;
    [SerializeField] private float pipeSpeed = 5f;
    [SerializeField] private float limitOffSet;
    private float xMovementLimit;

    private void Start()
    {
        xMovementLimit = Camera.main.ScreenToWorldPoint(Vector3.zero).x - limitOffSet;
    }

    void Update()
    {
        if (isCanMove)
        {
            PipeMovement();
            MovementLimit();
        }
    }

    private void PipeMovement()
    {
        var direction = Vector3.left * pipeSpeed * Time.deltaTime;
        transform.position += direction;
    }

    private void MovementLimit()
    {
        if (transform.position.x < xMovementLimit)
        {
            gameObject.SetActive(false);
        }
    }
}
