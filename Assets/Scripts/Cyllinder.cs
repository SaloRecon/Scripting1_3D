using UnityEngine;

public class Cyllinder : MonoBehaviour
{
    [SerializeField] private float rotationForce;

    [SerializeField] Vector3 direction;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.up * rotationForce, ForceMode.VelocityChange);
    }
    
    
    
}
