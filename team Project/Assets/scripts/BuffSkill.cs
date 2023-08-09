using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill : Skill
{
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
    public override void ActSkill()
    {
        base.ActSkill();
    }
    public override void SkillCoolDown()
    {
        base.SkillCoolDown();
    }
}
