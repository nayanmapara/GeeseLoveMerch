using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruiterDetection : MonoBehaviour
{
    HandleScore counter;

    void Start() {
        GameObject[] eventSystem = GameObject.FindGameObjectsWithTag("Event");
        counter = eventSystem[0].GetComponent<HandleScore>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Recruiter"))
        {
            counter.increaseScore();
            Destroy(collision.gameObject);
        }
    }
}
