using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_1Skill : DamageSkill
{//�Ķ���ʹ� ��ũ���ͺ� ������Ʈ���� ��������???�ذ�
    public Skilldatas scriptabledata;//��ũ���ͺ������Ʈ �ν�����â

    Dictionary<string, string> dictSkillStat = new Dictionary<string, string>();//��ųʸ� ���
    void Start()
    {
        SetParams();
    }
    public override void SetParams()
    {

        if(scriptabledata.Skills[0].fId == 1)
        {
            scriptabledata.Skills[0].strName = "�̸�";//��ũ���ͺ� ������Ʈ�� ���� ������
            scriptabledata.Skills[0].fSkillLevel = 100;
            string name = scriptabledata.Skills[0].strName;//��ũ���ͺ� ������Ʈ���� �����ö�

        }

    }
    public override void SkillUnLock(float CharacterLevel)
    {
        base.SkillUnLock(CharacterLevel);
    }
    public override void SkillLevelUp(float damage, float magnification, float attackcount, float targetcount)
    {
        base.SkillLevelUp(damage, magnification, attackcount, targetcount);
    }
    public override void SkillTriger()
    {//����Ʈ ������
        base.SkillTriger();
    }
   
    public override void SkillCoolDown()
    {
        base.SkillCoolDown();
    }
   
}
