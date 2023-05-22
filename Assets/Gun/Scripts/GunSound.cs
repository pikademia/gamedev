using UnityEngine;

public class GunSound : MonoBehaviour
{
    [SerializeField] AudioClip[] gunSounds;
    AudioSource audios;

    private void Awake()
    {
        audios = GetComponent<AudioSource>();
    }
    public void PlayGunSound(int soundIndex)
    {
        if(audios != null)
        {
            audios.clip = gunSounds[soundIndex];
            audios.Play();
        }
    }
}
