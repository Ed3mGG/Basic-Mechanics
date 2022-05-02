using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    public AudioMixerGroup soundEffectsMixer;

    public static AudioManager instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'AudioManager dans la scène");
            return;
        }

        instance = this;
    }
    
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

   
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            playNextSong();
        }
    }

    public void playNextSong()
    {  
        musicIndex = (musicIndex + 1) % playlist.Length; //Une fois que la playlist est finie, remet le compteur à zéro
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGameObject = new GameObject("TempAudio");
        tempGameObject.transform.position = pos;
        AudioSource audioSource = tempGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectsMixer;
        audioSource.Play();
        Destroy(tempGameObject, clip.length);
        return audioSource;
    }
}
