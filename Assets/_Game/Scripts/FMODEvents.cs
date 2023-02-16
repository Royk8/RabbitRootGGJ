using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    #region Singleton
        public static FMODEvents Instance;
    
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                DestroyImmediate(gameObject);
                return;
            }
            Instance = this;
        }
    #endregion
    
    [field: Header("Music")]
    [field: SerializeField] public EventReference RelaxedTheme { get; private set; }
    
    [field: Header("Carrot SFX")]
    [field: SerializeField] public EventReference CarrotTouched { get; private set; }
    [field: SerializeField] public EventReference CarrotPulled { get; private set; }
    [field: SerializeField] public EventReference CarrotGotten { get; private set; }
    
    [field: Header("Rabbit SFX")]
    [field: SerializeField] public EventReference RabbitSteps { get; private set; }
    
    [field: Header("Farmer SFX")]
    [field: SerializeField] public EventReference FarmerStab { get; private set; }
    [field: SerializeField] public EventReference FarmerPoison { get; private set; }
}
