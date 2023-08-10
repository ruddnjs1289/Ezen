using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill : Skill
{
    public override void SetParams()
    {//드랍율 추가
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
    public override void ActSkill(float characterstat, float value, float magnification, float attackcount, float tartgetcount, float fduration)
    {
        base.ActSkill(characterstat, value, magnification, attackcount, tartgetcount, fduration);
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
