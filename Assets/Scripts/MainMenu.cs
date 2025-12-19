using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSFX;
        
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        AudioManager.Instance.PlaySoundFXClip(buttonSFX, transform, 1f);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySoundFXClip(buttonSFX, transform, 1f);
        Application.Quit();
    }
}
