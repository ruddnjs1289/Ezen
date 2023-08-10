using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ÿ�Ӷ���
/*
20230809


�߰��ؾ��� ���
����� �ҽ� ��������
����� Ŭ�� ��������
��������
���
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
    // ����� �ҽ�
    // ����� Ŭ��

    // �÷���
    // Ŭ����
}
