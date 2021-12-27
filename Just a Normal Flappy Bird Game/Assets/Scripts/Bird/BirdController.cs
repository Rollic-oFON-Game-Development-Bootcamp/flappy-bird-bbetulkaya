using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float tiltSmooth = 20f;
    [SerializeField] private Vector3 startPos;


    [SerializeField] private Quaternion forwardRotation;
    [SerializeField] private Quaternion downRotation;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        forwardRotation = Quaternion.Euler(0, 0, 40);
        downRotation = Quaternion.Euler(0, 0, -90);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
}
