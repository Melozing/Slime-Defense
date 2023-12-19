using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [Range(0f, 1f)]
    public float musicVolume;
    [Range(0f, 1f)]
    public float soundVolume;

    public AudioSource musicAus;
    public AudioSource soundAus;

    public AudioClip[] backgroundMusics;
    public AudioClip playerShootSound;
    public AudioClip hitSound;
    public AudioClip playerGetHPSound;
    public AudioClip playerDieSound;
    public AudioClip clickButtonSound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (musicAus && backgroundMusics != null && backgroundMusics.Length > 0)
        {
            int randIdx = Random.Range(0, backgroundMusics.Length);

            if (backgroundMusics[randIdx])
            {
                musicAus.clip = backgroundMusics[randIdx];
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }

    public void PlaySound(AudioClip sound)
    {
        if (soundAus && sound)
        {
            soundAus.volume = soundVolume;
            soundAus.PlayOneShot(sound);
        }
    }

    public void PlayerShootSound()
    {
        PlaySound(playerShootSound);
    }

    public void HitSound()
    {
        PlaySound(hitSound);
    }

    public void ClickButtonSound()
    {
        PlaySound(clickButtonSound);
    }

    public void PlayerGetHPSound()
    {
        PlaySound(playerGetHPSound);
    }
    public void PlayerDieSound()
    {
        PlaySound(playerDieSound);
    }


    public void StopMusic()
    {
        if (musicAus)
        {
            musicAus.Stop();
        }
    }
}
