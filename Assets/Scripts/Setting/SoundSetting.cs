using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Ÿ�Ӷ���
/* 20230811
 * Slider���� AddListener �߰�
 * public void UpdateMasterVolume(float fValue)
 * ������ ���� ������Ʈ
 * public void UpdateBackgroundVolume(float fValue)
 * ��� ���� ������Ʈ
 * public void UpdateEffectVolume(float fValue)
 * ȿ���� ���� ������Ʈ
 * 
 */
/* 20230814
 * void Init()
 * �ʱ� ���� �� ����� �����Ϳ� ��ġ��Ű��
 */
#endregion
public class SoundSetting : MonoBehaviour
{
    public Slider sliderMasterVolume;
    public Slider sliderBackgroundVolume;
    public Slider sliderEffectVolume;

    private void Start()
    {
        Init();
        sliderMasterVolume.onValueChanged.AddListener(UpdateMasterVolume);
        sliderBackgroundVolume.onValueChanged.AddListener(UpdateBackgroundVolume);
        sliderEffectVolume.onValueChanged.AddListener(UpdateEffectVolume);
    }
    void Init()
    {
        // �����̴� ���� ����� �Ŵ����� ���� �ҷ��� ��ġ��Ŵ
        sliderMasterVolume.value = AudioManager.instance.fMasterVolume;
        sliderBackgroundVolume.value = AudioManager.instance.fBackgroundVolume;
        sliderEffectVolume.value = AudioManager.instance.fEffectVolume;

    }
    // ���� ������Ʈ
    public void UpdateMasterVolume(float fValue)
    {
        AudioManager.instance.SetMasterVolume(fValue);
    }
    public void UpdateBackgroundVolume(float fValue)
    {
        AudioManager.instance.SetBackgroundVolume(fValue);
    }
    public void UpdateEffectVolume(float fValue)
    {
        AudioManager.instance.SetEffectVolume(fValue);
    }
}
