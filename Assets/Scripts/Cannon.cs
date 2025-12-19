using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    GameObject InstatiatedBall;
   
    private void Start()
    {
        StartCoroutine(ballSpawnerRoutine());
    }
    
    IEnumerator ballSpawnerRoutine()
    {
        
        yield return new WaitForSeconds(2f);
        InstatiatedBall = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(InstatiatedBall); 
        StartCoroutine(ballSpawnerRoutine());
        
    }
}
