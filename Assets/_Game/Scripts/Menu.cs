using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour
{   
   
  public void Cambio () 
    {
        
        SceneManager.LoadScene("Menu");

    }public void CambioCreditos () 
    {
        
        SceneManager.LoadScene("CreditosR");

    }public void CambioSplashScreem () 
    {
        
        SceneManager.LoadScene("SplashScreem");
        

    }public void CambioSalir () 
    {
        
        Application.Quit();
        

    }
    



    
    
}
