using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdAI : MonoBehaviour
{
    // Unity Components reference
    [SerializeField] private Rigidbody2D rb;

    // Jump Settings
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxYPos;


    // Rotation Settings
    [SerializeField] private float maxRotationValue;
    [SerializeField] private float tiltSmooth;


    // Rotation Variables
    private Quaternion forwardRotation;
    private Quaternion downRotation;


    void Start()
    {
        rb.isKinematic = false;

        forwardRotation = Quaternion.Euler(0, 0, maxRotationValue);
        downRotation = Quaternion.Euler(0, 0, -maxRotationValue);
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        float y = Mathf.Sin(Time.time * jumpForce) * maxYPos;
        HandleRotation(y);

        var currentPos = transform.position;
        currentPos.y = y;
        transform.position = currentPos;
    }

    private void HandleRotation(float yPos)
    {
        if (yPos == 0)
        {
            var zeroRotation = Quaternion.Euler(Vector3.zero);
            transform.rotation = Quaternion.Lerp(transform.rotation, zeroRotation, tiltSmooth * Time.deltaTime);
        }
        else if (yPos < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, forwardRotation, tiltSmooth * Time.deltaTime);

        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
    }

    // Score control with collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            GameManager.Instance.UpdateScore(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            GameManager.Instance.UpdateScore(-1);
        }
    }
}
