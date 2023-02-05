using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesSingleton : MonoBehaviour
{
    public static ControlesSingleton Instance;
    #region Singleton

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
    public Transform agarreIzq;
    public Transform agarreDer;
}
