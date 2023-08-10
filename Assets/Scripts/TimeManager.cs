using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ÿ�Ӷ���
/*
20230809
�ۼ� �Լ�
CurrentTime
StartTime
EndTime
ElapedTime



�߰��ؾ��� ���
�̷��� �ϸ� �ߺ� �ð� üũ�� ���� �߻�
�Լ��� �����Ҵ�? �ؾ��ҵ�
*/
#endregion
public class TimeManager : MonoBehaviour
{
    private float _fCurrentTime;
    private float _fStartTime;
    private float _fEndTime;
    private float _fElapsedTime;

    // ���� �ð� ��ȯ
    public float CurrentTime
    {
        get
        {
            return Time.time;
        }
    }
    // ���� �ð� ���� ��ȯ
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
    // ���� �ð� ���� ��ȯ
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
    // ��� �ð� ���� ��ȯ
    public float ElapsedTime
    {
        get
        {
            return _fElapsedTime;
        }
        set
        {
            // ���� �ð��� �����Ǿ��ų�, �ð� ������ ��������
            // Time.time ���� ���� �ð�( �⺻ 0 )�� ���̸� ����
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
    // ����, ����, ��� �ð� 0���� ����
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
