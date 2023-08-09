using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillParameter;


public class Skill
{//1.스킬 해금 2.스킬 발동 3.강화 4.효과거리 5.지속시간
    //스킬 레벨/거리/시간
    

    SkillParameter.SkilParams skilParams = new SkillParameter.SkilParams();
    
    public virtual void SkillUnLock(float CharacterLevel)//스킬 해금
    {
        if (CharacterLevel > skilParams.fUnlockLevel)        
        skilParams.isUnlockSkill = true;
        //활성화 시키기
    }
    public virtual void SkillCoolDown()
    {//쿨타임동안 사용불가 쿨타임 종료시 사용가능
        skilParams.fTimer += Time.deltaTime;
        if (skilParams.fTimer >= skilParams.fCoolTime)
            skilParams.canUse = true;
    }
    public virtual void SkillTriger()//스킬 발동(단발형)
    {//애니메이션, 효과음, 투사체발사, 범위내 대미지주기, 
               
        if ( skilParams.canUse==true && skilParams.isAtctivate==false)
        {//스킬이 사용가능할떄,스킬이 사용중이 아닐때
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
        float attackcount,float targetcount)//스킬 레벨업(강화)
    {
        skilParams.fSkillLevel++;
        skilParams.fValue += damage;//기본대미지 증가
        skilParams.fMagnification += magnification;//스킬배율 증가
        skilParams.fAttackCount += attackcount;//타격횟수 증가
        skilParams.fTargetCount += targetcount;//타겟수 증가        
    }
    public virtual void ActSkill()//스킬작동(대미지형)
    {//스킬기본 값, 배율, 타격횟수, 타겟수, 지속시간
        skilParams.isAtctivate = false;
    }
    /*public virtual void ActSkill(float characterstat ,float value, float magnification,
        float fbuffduration)//스킬작동(버프형)
    {//캐릭터 스텟, 기본 스킬값, 배율, 버프 지속시간
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
       float attackcount, float tartgetcount, float fduration)//스킬작동(대미지형)
{//스킬기본 값, 배율, 타격횟수, 타겟수, 지속시간
    float skilldamage = value + characterstat * magnification;
}*/