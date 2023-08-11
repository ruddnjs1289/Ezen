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
