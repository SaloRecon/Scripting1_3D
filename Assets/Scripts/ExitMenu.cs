using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExitMenu"))
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
