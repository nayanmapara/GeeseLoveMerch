using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruiterLifetime : MonoBehaviour
{
    public float lifespan = 6f;
    float elapsedTime = 0f;
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= lifespan) {
            Destroy(gameObject);
        }
    }
}
