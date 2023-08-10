using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
    
    public override void SetParams()
    {
        
    }
    public override void SkillTriger()
    {
        base.SkillTriger();
    }
    public override void SkillUnLock(float CharacterLevel)
    {
        base.SkillUnLock(CharacterLevel);
    }
    public override void ActSkill(float characterstat, float value, float magnification, float fbuffduration)
    {
        base.ActSkill(characterstat, value, magnification, fbuffduration);
    }
}
