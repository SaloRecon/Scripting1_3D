using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
   
    [SerializeField] private AudioSource soundFXObject;
   
    private void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
       
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, spawnTransform.rotation);
       
        audioSource.clip = audioClip;
       
        audioSource.volume = volume;
       
        audioSource.Play();
       
        float clipLength = audioSource.clip.length;
       
        Destroy(audioSource.gameObject, clipLength);
    
    }

    
        
}
