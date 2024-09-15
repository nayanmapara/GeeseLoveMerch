using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchCannonLogic : MonoBehaviour
{
    public Transform cam;
    public Transform merchSpawnPoint;

    public GameObject merch1;

    public float speed = 10f;

    void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        float camXRotation = cam.eulerAngles.x;
        currentRotation.x = Mathf.Max(camXRotation, 0);
        currentRotation.x -= 20;

        transform.localEulerAngles = currentRotation;

        if (Input.GetKeyDown(KeyCode.E)) {
            GameObject realizedMerch1 = Instantiate(merch1, merchSpawnPoint.position, transform.rotation);
            Quaternion rotationOffset = Quaternion.Euler(0, -90, 0);
            Vector3 rotatedDirection = rotationOffset * transform.forward;
            realizedMerch1.GetComponent<Rigidbody>().velocity = rotatedDirection * speed;
        }
    }
}
