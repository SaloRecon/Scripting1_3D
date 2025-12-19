using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float movementForce;
    [SerializeField] private float maxSpeed;
    
    [SerializeField] float impulseForce;
    
    [SerializeField] private float interactionRadius;
    [SerializeField] private float groundCheckDistance;

    private Vector3 interactionPoint;

    private Vector3 inputDirection;
        
    private float hInput;
    private float vInput;
    
    [SerializeField] private AudioClip jumpSound;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Jump();
        Interactions();
    }
    
    private void FixedUpdate()
    {
        Inputs();
        Move();
        MaxSpeed();
    }

    private void Interactions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionPoint = transform.position + transform.forward * 0.2f;
             Collider[] results = Physics.OverlapSphere(interactionPoint, interactionRadius);

             if (results.Length > 0) // interfaces. Para buscar.
             {
                 foreach (Collider result in results)
                 {
                     if (result.gameObject.TryGetComponent(out Button buttonScript))
                     {
                         buttonScript.OpenDoor();
                     }
                 }
             }
        }
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse); // se pone esta física aqui porque es en un instante
            AudioManager.Instance.PlaySoundFXClip(jumpSound, transform, 1f);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance );
    }

    // FixedUpdate solo utiliza físicas acumulables/constantes

    private void Inputs()
    {
        vInput  = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        
    }

    private void Move()
    {
        Vector3 inputDirection =  new Vector3(hInput, 0, vInput);

        if (inputDirection.sqrMagnitude > 0.01f)
        {
            rb.AddForce(inputDirection * movementForce, ForceMode.Force);
        }
    }

    private void MaxSpeed()
    {
        Vector3 horizontalVelocity = new  Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
           rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
    
}
