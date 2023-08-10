using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 타임라인
/*
20230809


추가해야할 기능
오디오 소스 가져오기
오디오 클립 가져오기
볼륨조절
등등
*/
#endregion
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource[] audioSource;
    AudioClip[] audioClipBackground;
    AudioClip[] audioClipEffect;

    Dictionary<string, AudioClip> dicAudioClip = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // 오디오 소스
    // 오디오 클립

    // 플레이
    // 클리어
}
