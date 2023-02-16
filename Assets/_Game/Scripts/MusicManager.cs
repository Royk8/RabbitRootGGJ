using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Singleton
        public static MusicManager Instance;
    
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                DestroyImmediate(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    #endregion
}
