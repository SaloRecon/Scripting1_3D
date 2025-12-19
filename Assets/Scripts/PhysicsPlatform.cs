using System.Collections;
using UnityEngine;

public class PhysicsPlatform : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float timer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = movementDirection * speed;
        
        StartCoroutine(BackAndForth());
    }

    IEnumerator BackAndForth()
    {
        yield return new WaitForSeconds(timer);
        speed = -speed;
        rb.linearVelocity = movementDirection * speed;
        yield return new WaitForSeconds(timer);
        speed = -speed;
        rb.linearVelocity = movementDirection * speed;
        StartCoroutine(BackAndForth());
    }
    
}
