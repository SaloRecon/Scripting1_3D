using System;
using UnityEngine;

public class AirZone : MonoBehaviour
{
    [SerializeField] private float force;
    
    [SerializeField] private AudioClip windSound;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRB = other.GetComponent<Rigidbody>();
            
            otherRB.AddForce(Vector3.left * force, ForceMode.Force);
            otherRB.useGravity = false;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRB = other.GetComponent<Rigidbody>();
            otherRB.useGravity = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundFXClip(windSound, transform, 1f);
        }
    }
}
