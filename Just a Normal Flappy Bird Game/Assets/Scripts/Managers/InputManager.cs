using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float _lastFrameFingerPositionY;
    private float _moveFactorY;
    public float MoveFactorY => _moveFactorY;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorY = Input.mousePosition.y - _lastFrameFingerPositionY;
            _lastFrameFingerPositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorY = 0f;
        }
    }
}
