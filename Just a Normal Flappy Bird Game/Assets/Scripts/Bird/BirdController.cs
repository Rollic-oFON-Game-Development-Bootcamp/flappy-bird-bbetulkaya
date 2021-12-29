using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{
    // Unity Components reference
    [SerializeField] private Rigidbody2D rb;

    // Jump Settings
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float tiltSmooth = 20f;

    // Rotation Settings
    [SerializeField] private float maxRotationValue;
    [SerializeField] private float minRotValue;

    // Rotation Variables
    private Quaternion forwardRotation;
    private Quaternion downRotation;

    // Bool Variables
    private bool isAlive;

    void Start()
    {
        rb.isKinematic = false;
        isAlive = true;

        forwardRotation = Quaternion.Euler(0, 0, maxRotationValue);
        downRotation = Quaternion.Euler(0, 0, minRotValue);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isAlive)
        {
            HandleJump();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    private void HandleJump()
    {
        transform.rotation = forwardRotation;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
    }
    private void Death()
    {
        isAlive = false;
        tiltSmooth = 3f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Pipe"))
        {
            Death();
            GameManager.Instance.GameOver();
        }
    }
}
