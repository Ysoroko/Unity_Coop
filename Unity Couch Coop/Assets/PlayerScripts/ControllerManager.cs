using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class ControllerManager : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private float playerSpeed = 2.0f;

    private Vector2 movementInput = Vector2.zero;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("MOVING REAL FAST");
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("OI MATE I'M ATTACKING YA FER REAL!");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("You can't see me!");
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("You won't get me!");
    }

    void Update()
    {
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            transform.Translate(move);
        }

    }
}
