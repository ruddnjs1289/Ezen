using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : Skill
{
    [SerializeField]
    SkillParameter.SkillType SkillType = SkillParameter.SkillType.ACTIVE;
    SkillParameter.SkilParams skilParams = new SkillParameter.SkilParams();
    public override void SkillTriger()
    {
        if (skilParams.canUse == true && skilParams.isAtctivate == false)
        {//��ų�� ��밡���ҋ�,��ų�� ������� �ƴҶ�
            skilParams.isAtctivate = true;
            skilParams.fTimer = 0;
            SkillCoolDown();
            skilParams.canUse = false;
            PlayAnimation();
            PlaySound();
        }
        else
            return;
    }
    public virtual void PlayAnimation()
    {

    }
    public virtual void PlaySound()
    {

    }

}
