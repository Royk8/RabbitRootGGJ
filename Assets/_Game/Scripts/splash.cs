using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour
{
    public InputActionProperty propiedad;
    // Start is called before the first frame update
    void Start()
    {
        propiedad.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (propiedad.action.ReadValue<float>() > 0.5f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
