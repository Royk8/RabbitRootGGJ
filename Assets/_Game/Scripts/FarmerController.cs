using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FarmerController : MonoBehaviour
{
    [SerializeField] private HoleController _holeController;
    private List<int> FreeHoles;
    [SerializeField] private float initWait, loopWait;
    [SerializeField] private GameObject stab;
        
    IEnumerator Start()
    {
        yield return new WaitForSeconds(initWait);
        List<int> numbers = Enumerable.Range(0, _holeController.holes.Count).ToList();
        FreeHoles = numbers.Except(_holeController.FilledHolesList).ToList();
        StartCoroutine(StartChasing());
    }

    private IEnumerator StartChasing()
    {
        WaitForSeconds w = new WaitForSeconds(loopWait);
        while (true)
        {
            transform.position = _holeController.holes[FreeHoles[Random.Range(0, FreeHoles.Count)]].position;
            yield return w;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Apunalado");
            stab.SetActive(true);
            StartCoroutine(Deativate());
        }
        
    }

    private IEnumerator Deativate()
    {
        yield return new WaitForSeconds(3);
        stab.SetActive(false);
    }
}
