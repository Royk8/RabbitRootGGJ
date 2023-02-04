using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float speed;
    
    private CharacterController charControl;
    void Start()
    {
        charControl = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        Vector2 vert = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 movement = speed * (vert.y * transform.forward + vert.x * transform.right);

        charControl.SimpleMove(movement);

        float rot = _playerInput.actions["Look"].ReadValue<Vector2>().x;

        transform.Rotate(new Vector3(0,rot,0));
    }
}
