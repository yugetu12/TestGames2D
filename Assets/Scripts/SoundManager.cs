using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource audio;

    void Awake()
    {
        //シングルトンの設定
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySE(AudioClip clip)
    {
        if (clip == null || audio == null) return;

        audio.PlayOneShot(clip);
    }
}
