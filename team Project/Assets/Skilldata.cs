using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="SkillData",menuName ="SkilldataObject",order =1)]
public class Skilldata : ScriptableObject
{
    public float fId;//�ĺ���
    public string sName;//�̸�        
    public float fSkillLevel = 1f;//��ų����
    public string sDiscription;//��ų ����
    public float fSkillRequireExp;//��ų ������ �ʿ����ġ
    public float fSkillExp;//��ų����ġ
    public float fUnlockLevel;//��ų�ر� �ʿ�ĳ���ͷ���
    public float fUnlockHidenLevel;//��ų �߰�Ư������ ����
    public float fTimer;//��ųŸ�̸�
    public float fCoolTime;//��ų ��Ÿ��
    public float fDuration; //��ų ���ӽð�        
    public float fSkillCoolReduce;//��ų ��Ÿ�Ӱ���
    public float fBuffDuration;//������ų ���ӽð�
    public float fRange;//��ų����        
    public float fValue;//��ų �⺻������
    public float fMagnification;//��ų����
    public float fTargetCount;//��ų Ÿ�ټ�
    public float fAttackCount;//��ųŸ��Ƚ��        
    public float fBulletCount;//�߻�ü ����
    public bool isUnlockSkill = false;//��ų �ر�
    public bool canUse = false;//��ų�� ��밡������
    public bool isAtctivate = false;//��ų �ߵ�����    
}
