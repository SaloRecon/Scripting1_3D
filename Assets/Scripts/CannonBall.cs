using UnityEngine;

public class CannonBall : MonoBehaviour
{
    
    private Rigidbody rb;
    [SerializeField] private float impulseForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.AddForce(Vector3.forward * impulseForce, ForceMode.Impulse);
    }

    
    
}
