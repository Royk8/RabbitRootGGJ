using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZanahoriaController : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    private float[] lenghts;
    private Vector3 oldPosition;
    private float movido;
    private Animator _animator;
    public AudioSource conejo;





    private void Start()
    {
       
        _animator = GetComponent<Animator>();
        oldPosition = points[points.Count - 1].position;
        lenghts = new float[points.Count];

        for (int i = lenghts.Length-1; i>0; i--)
        {
            lenghts[i] = Vector3.Distance(points[i].position, points[i - 1].position);
        }

        foreach (var len in lenghts)
        {
            Debug.Log(len);
        }
        lenghts[0] = 0;
    }

    private Vector3[] SolvePositions(Vector3 finalPosition)
    {
        Vector3[] vectors = new Vector3[points.Count];
        vectors[points.Count-1] = finalPosition;
        for (int i = points.Count - 2; i >= 0; i--)
        {
            Vector3 nextPos = vectors[i + 1];
            Vector3 posActual = points[i].position;
            Vector3 direccion = (posActual - nextPos).normalized;
            vectors[i] = nextPos + (direccion * lenghts[i+1]);
        }

        oldPosition = finalPosition;
        return vectors;
    }

    private Vector3[] SolveForward()
    {
        Vector3[] vectors = new Vector3[points.Count];
        return null;
    }

    private void SetTransforms(Vector3[] positions)
    {
        for (int i = 0; i < points.Count -1; i++)
        {
            points[i].position = positions[i];
        }
    }

    private bool CheckForUpdate()
    {
        return oldPosition != points[points.Count - 1].position;
    }

    private void Update()
    {
        if (CheckForUpdate())
        {
            SetTransforms(SolvePositions(points[points.Count-1].position));
            conejo.Play();
        }
            
    }

    public void SetMovement(Vector3 movement)
    {
        Vector3 vectorMovimiento = oldPosition - movement;
        SetTransforms(SolvePositions(vectorMovimiento));
        movido += movement.y;
        if(movido > 1.1)
        {
            
            _animator.Play("GiraZanahoria");
            Destroy(gameObject, 1);
            
        }
    }

    void OnDestroy()
    {
        ControlPuntos.unico.SumarPuntos();
    }

}
