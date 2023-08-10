using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class _TestScript : FactoryManager
{
    FactoryManager monsterFactory;
    FactoryManager trapFactory;

    void Start()
    {
        CreateFactory("", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }

}
//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;

//    private bool isAudioMuted = false;

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else if (instance != this)
//        {
//            Destroy(gameObject);
//        }

//        DontDestroyOnLoad(gameObject);
//    }

//    public bool IsAudioMuted
//    {
//        get { return isAudioMuted; }
//        set
//        {
//            isAudioMuted = value;
//            AudioManager.instance.SetMuteAll(value);
//        }
//    }

//    // 다른 게임 매니저 관련 기능 추가 가능
//}

//public class AudioManager : MonoBehaviour
//{
//    public static AudioManager instance;

//    public AudioSource[] audioSources; // Array of AudioSources
//    public AudioClip[] backgroundMusicClips; // Array of background music clips
//    public AudioClip[] effectSoundClips; // Array of effect sound clips

//    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

//    private float masterVolume = 1.0f;
//    private float backgroundMusicVolume = 1.0f;
//    private float effectSoundVolume = 1.0f;

//    private void Awake()
//    {
//        // ... (Singleton setup)

//        // Populate the audioClipDict with audio clip names as keys
//        // ...

//        // Load saved volume settings if available
//        LoadVolumeSettings();
//    }

//    // ... (Other methods)

//    public void SetMasterVolume(float volume)
//    {
//        masterVolume = Mathf.Clamp01(volume);
//        UpdateVolume();
//    }

//    public void SetBackgroundMusicVolume(float volume)
//    {
//        backgroundMusicVolume = Mathf.Clamp01(volume);
//        UpdateVolume();
//    }

//    public void SetEffectSoundVolume(float volume)
//    {
//        effectSoundVolume = Mathf.Clamp01(volume);
//        UpdateVolume();
//    }

//    private void UpdateVolume()
//    {
//        foreach (AudioSource source in audioSources)
//        {
//            source.volume = masterVolume * (source.CompareTag("BackgroundMusic") ? backgroundMusicVolume : effectSoundVolume);
//        }

//        // Save volume settings
//        SaveVolumeSettings();
//    }

//    private void SaveVolumeSettings()
//    {
//        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
//        PlayerPrefs.SetFloat("BackgroundMusicVolume", backgroundMusicVolume);
//        PlayerPrefs.SetFloat("EffectSoundVolume", effectSoundVolume);
//        PlayerPrefs.Save();
//    }

//    private void LoadVolumeSettings()
//    {
//        masterVolume = PlayerPrefs.GetFloat("MasterVolume", masterVolume);
//        backgroundMusicVolume = PlayerPrefs.GetFloat("BackgroundMusicVolume", backgroundMusicVolume);
//        effectSoundVolume = PlayerPrefs.GetFloat("EffectSoundVolume", effectSoundVolume);
//        UpdateVolume();
//    }
//}

//public class AudioManager : MonoBehaviour
//{
//    public static AudioManager instance;

//    public AudioSource[] audioSources; // Array of AudioSources
//    public AudioClip[] backgroundMusicClips; // Array of background music clips
//    public AudioClip[] effectSoundClips; // Array of effect sound clips

//    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else if (instance != this)
//        {
//            Destroy(gameObject);
//            return;
//        }

//        DontDestroyOnLoad(gameObject);

//        // Populate the audioClipDict with audio clip names as keys
//        foreach (AudioClip clip in backgroundMusicClips)
//        {
//            audioClipDict.Add(clip.name, clip);
//        }
//        foreach (AudioClip clip in effectSoundClips)
//        {
//            audioClipDict.Add(clip.name, clip);
//        }
//    }

//    // ... (Other methods)

//    public void PlayBackgroundMusic(string clipName)
//    {
//        if (audioClipDict.TryGetValue(clipName, out AudioClip clip))
//        {
//            audioSources[0].clip = clip;
//            audioSources[0].Play();
//        }
//        else
//        {
//            Debug.LogWarning($"Audio clip {clipName} not found.");
//        }
//    }

//    public void PlayEffectSound(string clipName)
//    {
//        if (audioClipDict.TryGetValue(clipName, out AudioClip clip))
//        {
//            audioSources[1].PlayOneShot(clip);
//        }
//        else
//        {
//            Debug.LogWarning($"Audio clip {clipName} not found.");
//        }
//    }
//}