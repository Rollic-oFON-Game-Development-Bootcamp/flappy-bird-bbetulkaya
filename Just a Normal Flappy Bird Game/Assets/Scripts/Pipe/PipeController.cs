using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount;

    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * inputManager.MoveFactorY;

        var currentPos = this.transform.position;
        currentPos += Vector3.up * swerveAmount;
        currentPos.y = Mathf.Clamp(currentPos.y, -maxSwerveAmount, maxSwerveAmount);
        transform.position = currentPos;
    }

}
