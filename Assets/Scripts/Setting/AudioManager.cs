using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ÿ�Ӷ���
/* 20230811
 * �̱��� ���� �߰�
 * Init() �߰�
 * 
 * public void PlayBackgroundSound(AudioSource audioSource, string sClipName)
 * AudioSource sClipName �޾ƿͼ� private void BackgroundSound �� �Ѱ���
 * 
 * private void BackgroundSound(AudioSource audioSource, AudioClip audioClip)
 * AudioSource�� AudioClip�� �־��ְ� loop���� ���
 * 
 * private void EffectSound(AudioSource audioSource, AudioClip audioClip)
 * AudioSource�� AudioClip�� �־��ְ� �ѹ� ���
 * 
 * public void SetMasterVolume(float fVolume)       ������ ���� ��
 * public void SetBackgroundVolume(float fVolume)   ������� ���� ��
 * public void SetEffectVolume(float fVolume)       ����Ʈ ���� ��
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
        //�ʱ�ȭ
        Init();
    }
    void Init()
    {
        // ����� Ŭ�� �ӽ� �迭 ���ҽ������� SoundClip ���� �� ��� audioclip ���
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("SoundClip");
        // �迭�� ��� audioClip�� _dictAudioClip�� �̸��� Ű������ �־���
        foreach (AudioClip audio in audioClips)
        {
            if (!_dictAudioClip.ContainsKey(audio.name))
            {
                _dictAudioClip.Add(audio.name, audio);
            }
        }
    }
    // �ܺο��� ȣ���� ������� �����
    public void PlayBackgroundSound(AudioSource audioSource, string sClipName)
    {
        if (_dictAudioClip.ContainsKey(sClipName))
        {
            // ������� ���
            BackgroundSound(audioSource, _dictAudioClip[sClipName]);
        }
        else
        {
            Debug.LogError("������� ��� ����");
        }
    }
    // �ܺο��� ȣ���� ����Ʈ �����
    public void PlayEffectSound(AudioSource audioSource, string sClipName)
    {
        if (_dictAudioClip.ContainsKey(sClipName))
        {
            // ����Ʈ ���
            EffectSound(audioSource, _dictAudioClip[sClipName]);
        }
        else
        {
            Debug.LogError("ȿ���� ��� ����");
        }
    }
    // ������� ���
    private void BackgroundSound(AudioSource audioSource, AudioClip audioClip)
    {
        // �޾ƿ� AudioSource�� AudioClip�� �ְ� ���� ���� �� ���
        audioSource.clip = audioClip;
        audioSource.volume = _fMasterVolume * _fBackgroundVolume;
        audioSource.loop = true;
        audioSource.Play();
    }
    // ����Ʈ ���
    private void EffectSound(AudioSource audioSource, AudioClip audioClip)
    {
        // �޾ƿ� AudioSource�� AudioClip�� �ְ� ���� ���� �� ���
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
    // ������ ���� ����
    public void SetMasterVolume(float fVolume)
    {
        _fMasterVolume = fVolume;
        UpdateAllAudioSource();
    }
    // ��� ���� ����
    public void SetBackgroundVolume(float fVolume)
    {
        _fBackgroundVolume = fVolume;
        UpdateAllAudioSource();
    }
    // ����Ʈ ���� ����
    public void SetEffectVolume(float fVolume)
    {
        _fEffectVolume = fVolume;
        UpdateAllAudioSource();
    } 
}
