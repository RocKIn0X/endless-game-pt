using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneObstacleRandom : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, RandomZpos());
    }

    float RandomZpos()
    {
        float z = Random.Range(-2, 2);

        return z;
    }
}