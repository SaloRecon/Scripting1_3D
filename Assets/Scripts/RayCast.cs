using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float strength;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           OverlapFunction();
        }
    }

    void RayHitFunction() // calcula un golpe mediante un rayo con el impactinfo para devolver informacion
    {
        RaycastHit impactInfo;
        
        if (Physics.Raycast(this.transform.position, Vector3.forward, out impactInfo))
        {
            Debug.DrawRay(this.transform.position, Vector3.forward * distance, Color.red,2f);
            
            Rigidbody rbHit = impactInfo.rigidbody;
            Debug.Log(rbHit);
            
            rbHit.GetComponent<Enemy>().Damage(10);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawSphere(this.transform.position, radius);
        
    }
    
    private void OverlapFunction() //Simula una bomba
    {
        Collider[] collidersWithinRadius = Physics.OverlapSphere(this.transform.position, radius);
        
        foreach (Collider col in collidersWithinRadius)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(strength, transform.position, radius);
            }
        }
    }
}