using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(8, -6, 0);
    [SerializeField] float period;
    [SerializeField, Range(0,1)] float movementFactor; //0 is not moved, 1 is fully moved
    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        period = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon){ return; }

        float cycles = Time.time / period; // grows from 0 at constant rate
        const float TAU = (float)Math.PI * 2;
        float sinValue = Mathf.Sin(cycles * TAU); //varies from -1 to 1
        movementFactor = (sinValue / 2f) + 0.5f; //varies from 0 to 1
        Vector3 offsetVector = movementVector * movementFactor;
        transform.position = startingPos + offsetVector;
    }
}
