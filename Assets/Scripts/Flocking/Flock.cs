using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager;

    private float speed;
    private float rotationSpeed;
    private float neighbourDistance;
    private bool turning = false;
    private Vector3 fleeDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
        rotationSpeed = Random.Range(myManager.minRotationSpeed, myManager.maxRotationSpeed);
        neighbourDistance = Random.Range(myManager.minNeighbourDistance, myManager.maxNeighbourDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, myManager.goalPos) >= myManager.swimLimits || transform.position.y >= myManager.waterHeight)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        if(turning)
        {
            Vector3 direction = (myManager.goalPos - transform.position) - fleeDirection * 2;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
            rotationSpeed = Random.Range(myManager.minRotationSpeed, myManager.maxRotationSpeed);
            neighbourDistance = Random.Range(myManager.minNeighbourDistance, myManager.maxNeighbourDistance);
        }
        else
        {
            if (Random.Range(0, 1) <= 1)
            {
                ApplyRules();
            }
        }

        this.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = myManager.allFish;

        Vector3 vCenter = Vector3.zero; // center of the group
        Vector3 vavoid = Vector3.zero; // avoidance vector

        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        Vector3 goalPos = myManager.goalPos;
        
        foreach(GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);

                if (nDistance <= neighbourDistance)
                {
                    vCenter += go.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vCenter = vCenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = Vector3.Normalize(((vCenter + vavoid) - transform.position) - (fleeDirection * 2));
            
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.transform.CompareTag("Fish"))
        {
            // take the distance of the fish and the incoming unknown object
            // apply a vector away from the unknown object that will be applied to the fish
            // the closer the unknown object is to the fish the more force is applied
            Vector3 heading = other.gameObject.transform.position - gameObject.transform.position; // creates a vector pointing to the object
            float distance = heading.magnitude; // gets the distance of the vector

            fleeDirection = heading / distance; // normalized heading
        }
    }
}