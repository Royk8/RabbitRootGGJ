using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZanahoriaController : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    private float[] lenghts;

    private void Start()
    {
        lenghts = new float[points.Count];

        for (int i = lenghts.Length-1; i>0; i--)
        {
            lenghts[i] = Vector3.Distance(points[i].position, points[i - 1].position);
        }

        lenghts[0] = 0;
    }

    private Vector3[] SolvePositions(Vector3 finalPosition)
    {
        Vector3[] vectors = new Vector3[points.Count];
        vectors[-1] = finalPosition;
        for (int i = points.Count - 2; i >= 0; i--)
        {
            Vector3 nextPos = vectors[i + 1];
            Vector3 posActual = points[i].position;
            Vector3 direccion = (posActual - nextPos).normalized;
            vectors[i] = nextPos + (direccion * lenghts[i]);
        }

        return vectors;
    }

    private void SetTransforms(Vector3[] positions)
    {
        for (int i = 0; i < points.Count; i++)
        {
            points[i].position = positions[i];
        }
    }

    private void Update()
    {
        SetTransforms(SolvePositions(points[-1].position));
    }
}
