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
#endregion
public class SoundUIManager : MonoBehaviour
{
    public Slider sliderMasterVolume;
    public Slider sliderBackgroundVolume;
    public Slider sliderEffectVolume;
    private void Start()
    {
        sliderMasterVolume.onValueChanged.AddListener(UpdateMasterVolume);
        sliderBackgroundVolume.onValueChanged.AddListener(UpdateBackgroundVolume);
        sliderEffectVolume.onValueChanged.AddListener(UpdateEffectVolume);
    }
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
