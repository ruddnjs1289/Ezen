using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillParameter 
{//�ĺ���, ��ų�̸�, �⺻��ġ, ��Ÿ��, ���ӽð�, ����, ��Ÿ�� ������, ���� ���ӽð�, ����
 //Ÿ�ټ�, ����Ƚ��
    public enum SkillType{PASSIVE,ACTIVE,ULTIMATE }
    public class SkilParams
    {
        public float fId;//�ĺ���
        public string sName;//�̸�        
        public float fUnlockLevel;//��ų�رݷ���
        public float fTimer;//��ųŸ�̸�
        public float fCoolTime;//��ų ��Ÿ��
        public float fDuration;//��ų ���ӽð�        
        public float fSkillCoolReduce;//��ų ��Ÿ�Ӱ���
        public float fBuffDuration;//������ų ���ӽð�
        public float fRange;//��ų����
        public float fSkillLevel = 1f;//��ų����
        public float fValue;//��ų �⺻������
        public float fMagnification;//��ų����
        public float fTargetCount;//��ų Ÿ�ټ�
        public float fAttackCount;//��ųŸ��Ƚ��        
        public bool isUnlockSkill=false;//��ų �ر�
        public bool canUse;//��ų�� ��밡������
        public bool isAtctivate=false;//��ų �ߵ�����                                      
    }
    
    
}
