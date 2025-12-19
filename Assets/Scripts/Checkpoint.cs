using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private List<GameObject> checkPoints;

    [SerializeField] private Vector3 vectorPoint;

    [SerializeField] private float dead;
    
    [SerializeField] private AudioClip checkpointSound;

    private void Update()
    {
        if (player.transform.position.y < -dead)
        {
            player.transform.position = vectorPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            vectorPoint = player.transform.position;
            AudioManager.Instance.PlaySoundFXClip(checkpointSound, transform, 1f);
        }
        
    }
    
}
