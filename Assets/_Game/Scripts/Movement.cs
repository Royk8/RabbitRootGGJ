using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private InputActionReference vertical;
    [SerializeField] private float speed;
    
    private CharacterController charControl;
    void Start()
    {
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        Vector2 vert = vertical.action.ReadValue<Vector2>();
        Debug.Log(vert);

        Vector3 movement = speed * vert.y * transform.forward;

        charControl.Move(movement);
    }
}
