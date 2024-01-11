using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdjustHeight : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    public float sensitivity;

    public InputActionReference moveUp;
    public InputActionReference moveDown;

    Vector3 position;

    private void Start()
    {
        position = transform.localPosition;
        Debug.Log(position);
    }

    private void Update()
    {

        if (moveUp.action.WasPressedThisFrame())
        {
            Debug.Log("up");
            Debug.Log(position);
            position.y += sensitivity;
        }

        if (moveDown.action.WasPressedThisFrame())
        {
            Debug.Log("down");
            Debug.Log(position);
            position.y -= sensitivity;
        }

        position.y = Mathf.Clamp(position.y, minHeight, maxHeight);

        transform.localPosition = position;
    }
}
