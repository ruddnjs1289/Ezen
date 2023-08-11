using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 타임라인
/* 20230811
 * Slider마다 AddListener 추가
 * public void UpdateMasterVolume(float fValue)
 * 마스터 볼륨 업데이트
 * public void UpdateBackgroundVolume(float fValue)
 * 배경 볼륨 업데이트
 * public void UpdateEffectVolume(float fValue)
 * 효과음 볼륨 업데이트
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
