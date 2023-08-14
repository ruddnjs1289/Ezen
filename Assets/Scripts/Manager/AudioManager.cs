using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
/* 20230814
 * ���ϰ�� ����
 * void SetVolumes()
 * ���� �ʱⰪ �ҷ����� ����
 * public float fMasterVolume { get { return _fMasterVolume; } }
 * public float fBackgroundVolume { get { return _fBackgroundVolume; } }
 * public float fEffectVolume { get { return _fEffectVolume; } }
 * private ������ public get ����
 * void UpdateAllAudioSource()
 * ����� �ҽ� ���� ã�Ƽ� ���� �����ϱ�
 */
#endregion
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private static string _strAudioManagerPath;
    [SerializeField]
    private float _fMasterVolume = 1.0f;
    [SerializeField]
    private float _fBackgroundVolume = 1.0f;
    [SerializeField]
    private float _fEffectVolume = 1.0f;

    public float fMasterVolume { get { return _fMasterVolume; } }
    public float fBackgroundVolume { get { return _fBackgroundVolume; } }
    public float fEffectVolume { get { return _fEffectVolume; } }
    private Dictionary<string, AudioClip> _dictAudioClip = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        // ��� �ҷ�����
        _strAudioManagerPath = Application.persistentDataPath + FilePath.STR_VOLUME_VALUE;

        if (instance == null)
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
    }
    void Start()
    {
        Init();
    }
    void Init()
    {
        // �����ϱ�. -> ������ �̹��ִٸ� ������ ������ �б� �ƴϸ� �ʱⰪ ����//
        //if(GameManager.instance.FileCheck())
        SetVolumes();
        // else
        // �ʱⰪ ����
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
    void SetVolumes()
    {
        // ���ӸŴ����� ������ �о����
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strAudioManagerPath);
        // ������ ����� ������ ����
        _fMasterVolume = float.Parse(dictVolumeValues["MasterVolume"]);
        _fBackgroundVolume = float.Parse(dictVolumeValues["BackgroundVolume"]);
        _fEffectVolume = float.Parse(dictVolumeValues["EffectVolume"]);
    }
    // �ܺο��� ȣ���� ������� �����
    public void PlayBackgroundSound(AudioSource audioSource, string strClipName)
    {
        if (_dictAudioClip.ContainsKey(strClipName))
        {
            // ������� ���
            BackgroundSound(audioSource, _dictAudioClip[strClipName]);
        }
        else
        {
            Debug.LogError("������� ��� ����");
        }
    }
    // �ܺο��� ȣ���� ����Ʈ �����
    public void PlayEffectSound(AudioSource audioSource, string strClipName)
    {
        if (_dictAudioClip.ContainsKey(strClipName))
        {
            // ����Ʈ ���
            EffectSound(audioSource, _dictAudioClip[strClipName]);
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
    // ����� �ҽ��� ������ ������Ʈ
    void UpdateAllAudioSource()
    {
        // ����� �ҽ� ���� ã�Ƽ�
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in audioSources)
        {
            // �������, ȿ������ ������ �����Ͽ�
            if (audio.loop)
            {
                // ������� ���� ����
                audio.volume = _fMasterVolume * _fBackgroundVolume;
            }
            else
            {
                // ����Ʈ ���� ����
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
