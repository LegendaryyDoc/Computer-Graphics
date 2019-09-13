﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numberOfFish = 10;
    public float swimLimits = 10; // acts as a box that the fish cannot swim out of
    public Vector3 goalPos = Vector3.zero;

    [HideInInspector]public GameObject[] allFish; // holds all the fish that are in the school

    [Header("Fish Setting")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()                                                                                                        
    {
        allFish = new GameObject[numberOfFish];

        for(int i = 0; i < numberOfFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits, swimLimits), Random.Range(-swimLimits, swimLimits), Random.Range(-swimLimits, swimLimits));

            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i].transform.parent = this.gameObject.transform;
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }
}