using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillParameter;


public class Skill
{//1.��ų �ر� 2.��ų �ߵ� 3.��ȭ 4.ȿ���Ÿ� 5.���ӽð�
    //��ų ����/�Ÿ�/�ð�
    

    SkillParameter.SkilParams skilParams = new SkillParameter.SkilParams();
    
    public virtual void SkillUnLock(float CharacterLevel)//��ų �ر�
    {
        if (CharacterLevel > skilParams.fUnlockLevel)        
        skilParams.isUnlockSkill = true;
        //Ȱ��ȭ ��Ű��
    }
    public virtual void SkillCoolDown()
    {//��Ÿ�ӵ��� ���Ұ� ��Ÿ�� ����� ��밡��
        skilParams.fTimer += Time.deltaTime;
        if (skilParams.fTimer >= skilParams.fCoolTime)
            skilParams.canUse = true;
    }
    public virtual void SkillTriger()//��ų �ߵ�(�ܹ���)
    {//�ִϸ��̼�, ȿ����, ����ü�߻�, ������ ������ֱ�, 
               
        if ( skilParams.canUse==true && skilParams.isAtctivate==false)
        {//��ų�� ��밡���ҋ�,��ų�� ������� �ƴҶ�
            skilParams.isAtctivate = true;
            skilParams.fTimer = 0;
            SkillCoolDown();
            skilParams.canUse = false;
            ActSkill();
        }
        else
            return;
                       
    }

    public virtual void SkillLevelUp(float damage, float magnification,
        float attackcount,float targetcount)//��ų ������(��ȭ)
    {
        skilParams.fSkillLevel++;
        skilParams.fValue += damage;//�⺻����� ����
        skilParams.fMagnification += magnification;//��ų���� ����
        skilParams.fAttackCount += attackcount;//Ÿ��Ƚ�� ����
        skilParams.fTargetCount += targetcount;//Ÿ�ټ� ����        
    }
    public virtual void ActSkill()//��ų�۵�(�������)
    {//��ų�⺻ ��, ����, Ÿ��Ƚ��, Ÿ�ټ�, ���ӽð�
        skilParams.isAtctivate = false;
    }
    /*public virtual void ActSkill(float characterstat ,float value, float magnification,
        float fbuffduration)//��ų�۵�(������)
    {//ĳ���� ����, �⺻ ��ų��, ����, ���� ���ӽð�
        skilParams.fTimer = 0;        
        float buffstat = characterstat + value + characterstat * magnification;
        if (skilParams.isAtctivate == true)
        {

        }
        
        if (skilParams.fTimer >= fbuffduration)
        {
            buffstat = characterstat;
            skilParams.isAtctivate = false;
        }
        

    }
      */
  
   
}
/*public virtual void ActSkill(float characterstat, float value, float magnification,
       float attackcount, float tartgetcount, float fduration)//��ų�۵�(�������)
{//��ų�⺻ ��, ����, Ÿ��Ƚ��, Ÿ�ټ�, ���ӽð�
    float skilldamage = value + characterstat * magnification;
}*/