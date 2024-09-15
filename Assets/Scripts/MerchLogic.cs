using UnityEngine;

public class MerchLogic : MonoBehaviour
{
    public float gravityScale = 0.5f; 

    private Rigidbody rb;

    public float lifespan = 5f;
    float elapsedTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 gravity = Physics.gravity * gravityScale;
        rb.velocity += gravity * Time.fixedDeltaTime;

        elapsedTime += Time.fixedDeltaTime;
        if (elapsedTime >= lifespan) {
            Destroy(gameObject);
        }
    }
}
