using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InvisibleOnClick : MonoBehaviour
{
    [SerializeField]
    InputAction Clicker = new InputAction(type: InputActionType.Button);

    void OnEnable()
    {
        Clicker.Enable();
    }
    
    void OnDisable()
    {
        Clicker.Disable();
    }

    private void Start()
    {
        Clicker.performed += OnMyAction;
    }

    private void OnMyAction(InputAction.CallbackContext context)
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }

}
