using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 타임라인
/* 20230811
 * 싱글톤 패턴 추가
 * Init() 추가
 * 
 * public void PlayBackgroundSound(AudioSource audioSource, string sClipName)
 * AudioSource sClipName 받아와서 private void BackgroundSound 에 넘겨줌
 * 
 * private void BackgroundSound(AudioSource audioSource, AudioClip audioClip)
 * AudioSource에 AudioClip을 넣어주고 loop시켜 재생
 * 
 * private void EffectSound(AudioSource audioSource, AudioClip audioClip)
 * AudioSource에 AudioClip을 넣어주고 한번 재생
 * 
 * public void SetMasterVolume(float fVolume)       마스터 볼륨 셋
 * public void SetBackgroundVolume(float fVolume)   배경음악 볼륨 셋
 * public void SetEffectVolume(float fVolume)       이펙트 볼륨 셋
 */
#endregion
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private float _fMasterVolume = 1.0f;
    private float _fBackgroundVolume = 1.0f;
    private float _fEffectVolume = 1.0f;

    private Dictionary<string, AudioClip> _dictAudioClip = new Dictionary<string, AudioClip>();

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
        //초기화
        Init();
    }
    void Init()
    {
        // 오디오 클립 임시 배열 리소스폴더의 SoundClip 폴더 내 모든 audioclip 등록
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("SoundClip");
        // 배열에 담긴 audioClip을 _dictAudioClip에 이름을 키값으로 넣어줌
        foreach (AudioClip audio in audioClips)
        {
            if (!_dictAudioClip.ContainsKey(audio.name))
            {
                _dictAudioClip.Add(audio.name, audio);
            }
        }
    }
    // 외부에서 호출할 배경음악 재생기
    public void PlayBackgroundSound(AudioSource audioSource, string sClipName)
    {
        if (_dictAudioClip.ContainsKey(sClipName))
        {
            // 배경음악 재생
            BackgroundSound(audioSource, _dictAudioClip[sClipName]);
        }
        else
        {
            Debug.LogError("배경음악 재생 실패");
        }
    }
    // 외부에서 호출할 이펙트 재생기
    public void PlayEffectSound(AudioSource audioSource, string sClipName)
    {
        if (_dictAudioClip.ContainsKey(sClipName))
        {
            // 이펙트 재생
            EffectSound(audioSource, _dictAudioClip[sClipName]);
        }
        else
        {
            Debug.LogError("효과음 재생 실패");
        }
    }
    // 배경음악 재생
    private void BackgroundSound(AudioSource audioSource, AudioClip audioClip)
    {
        // 받아온 AudioSource에 AudioClip을 넣고 볼륨 셋팅 후 재생
        audioSource.clip = audioClip;
        audioSource.volume = _fMasterVolume * _fBackgroundVolume;
        audioSource.loop = true;
        audioSource.Play();
    }
    // 이펙트 재생
    private void EffectSound(AudioSource audioSource, AudioClip audioClip)
    {
        // 받아온 AudioSource에 AudioClip을 넣고 볼륨 셋팅 후 재생
        audioSource.clip = audioClip;
        audioSource.volume = _fMasterVolume * _fEffectVolume;
        audioSource.loop = false;
        audioSource.PlayOneShot(audioClip);
    }
    void UpdateAllAudioSource()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in audioSources)
        {
            if (audio.loop)
            {
                audio.volume = _fMasterVolume * _fBackgroundVolume;
            }
            else
            {
                audio.volume = _fMasterVolume * _fEffectVolume;
            }
        }
    }
    // 마스터 볼륨 설정
    public void SetMasterVolume(float fVolume)
    {
        _fMasterVolume = fVolume;
        UpdateAllAudioSource();
    }
    // 배경 볼륨 설정
    public void SetBackgroundVolume(float fVolume)
    {
        _fBackgroundVolume = fVolume;
        UpdateAllAudioSource();
    }
    // 이펙트 볼륨 설정
    public void SetEffectVolume(float fVolume)
    {
        _fEffectVolume = fVolume;
        UpdateAllAudioSource();
    } 
}
