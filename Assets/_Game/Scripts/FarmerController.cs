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
    [SerializeField] private GameObject stab, poison;
    private bool attacking;
        
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
            if(!attacking)
                transform.position = _holeController.holes[FreeHoles[Random.Range(0, FreeHoles.Count)]].position;
            yield return w;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Apunalado");
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                StartCoroutine(StabRabbit());
            }
            else
            {
                StartCoroutine(PoisonRabbit());
            }
            
        }
        
    }

    private IEnumerator StabRabbit()
    {
        if (attacking) yield return null;
        attacking = true;
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.FarmerStab, transform.position);
        //yield return new WaitForSeconds(1);
        stab.SetActive(true);
        yield return new WaitForSeconds(3);
        stab.SetActive(false);
        attacking = false;
    }

    private IEnumerator PoisonRabbit()
    {
        if (attacking) yield return null;
        attacking = true;
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.FarmerPoison, transform.position);
        //yield return new WaitForSeconds(1);
        poison.SetActive(true);
        yield return new WaitForSeconds(20);
        poison.SetActive(false);
        attacking = false;
    }
}
