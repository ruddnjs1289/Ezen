using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill : Skill
{
    public override void SetParams()
    {
        base.SetParams();
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
    {
        base.SkillTriger();
    }
    public override void ActSkill(float characterstat, float value, float magnification, float fbuffduration)
    {
        base.ActSkill(characterstat, value, magnification, fbuffduration);
    }
    public override void SkillCoolDown()
    {
        base.SkillCoolDown();
    }
    public override void PlayAnimation()
    {
        base.PlayAnimation();
    }
    public override void PlaySound()
    {
        base.PlaySound();
    }
}
