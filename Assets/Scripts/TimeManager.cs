using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 타임라인
/*
20230809
작성 함수
CurrentTime
StartTime
EndTime
ElapedTime



추가해야할 기능
이렇게 하면 중복 시간 체크시 문제 발생
함수로 동적할당? 해야할듯
*/
#endregion
public class TimeManager : MonoBehaviour
{
    private float _fCurrentTime;
    private float _fStartTime;
    private float _fEndTime;
    private float _fElapsedTime;

    // 현재 시간 반환
    public float CurrentTime
    {
        get
        {
            return Time.time;
        }
    }
    // 시작 시간 설정 반환
    public float StartTime
    {
        get
        {
            return _fStartTime;
        }
        set
        {
            _fStartTime = value;
        }
    }
    // 엔드 시간 설정 반환
    public float EndTime
    {
        get
        {
            return _fEndTime;
        }
        set
        {
            _fEndTime = value;
        }
    }
    // 경과 시간 설정 반환
    public float ElapsedTime
    {
        get
        {
            return _fElapsedTime;
        }
        set
        {
            // 시작 시간만 설정되었거나, 시간 설정을 안했을때
            // Time.time 에서 시작 시간( 기본 0 )의 차이를 구함
            if(EndTime <= StartTime)
            {
                _fElapsedTime = CurrentTime - StartTime;
            }
            else
            {
                _fElapsedTime = EndTime - StartTime;
            }
        }
    }
    // 시작, 엔드, 경과 시간 0으로 설정
    public void InitTime()
    {
        _fCurrentTime = 0;
        _fStartTime = 0;
        _fEndTime = 0;
        _fElapsedTime = 0;
    }
    private void Start()
    {
        InitTime();
    }
}
