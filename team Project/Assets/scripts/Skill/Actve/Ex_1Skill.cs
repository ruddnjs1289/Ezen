using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_1Skill : DamageSkill
{//파라미터는 스크립터블 오브젝트에서 가져오기???해결
    public Skilldatas scriptabledata;//스크립터블오브젝트 인스펙터창

    Dictionary<string, string> dictSkillStat = new Dictionary<string, string>();//딕셔너리 사용
    void Start()
    {
        SetParams();
    }
    public override void SetParams()
    {

        if(scriptabledata.Skills[0].fId == 1)
        {
            scriptabledata.Skills[0].strName = "이름";//스크립터블 오브젝트에 정보 넣을때
            scriptabledata.Skills[0].fSkillLevel = 100;
            string name = scriptabledata.Skills[0].strName;//스크립터블 오브젝트에서 꺼내올때

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
    {//이펙트 나가게
        base.SkillTriger();
    }
   
    public override void SkillCoolDown()
    {
        base.SkillCoolDown();
    }
   
}
