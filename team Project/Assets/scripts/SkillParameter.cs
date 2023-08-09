using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillParameter 
{//식별자, 스킬이름, 기본수치, 쿨타임, 지속시간, 배율, 쿨타임 감소율, 버프 지속시간, 범위
 //타겟수, 공격횟수
    public enum SkillType{PASSIVE,ACTIVE,ULTIMATE }
    public class SkilParams
    {
        public float fId;//식별자
        public string sName;//이름        
        public float fUnlockLevel;//스킬해금레벨
        public float fTimer;//스킬타이머
        public float fCoolTime;//스킬 쿨타임
        public float fDuration;//스킬 지속시간        
        public float fSkillCoolReduce;//스킬 쿨타임감소
        public float fBuffDuration;//버프스킬 지속시간
        public float fRange;//스킬범위
        public float fSkillLevel = 1f;//스킬레벨
        public float fValue;//스킬 기본데미지
        public float fMagnification;//스킬배율
        public float fTargetCount;//스킬 타겟수
        public float fAttackCount;//스킬타격횟수        
        public bool isUnlockSkill=false;//스킬 해금
        public bool canUse;//스킬이 사용가능한지
        public bool isAtctivate=false;//스킬 발동여부                                      
    }
    
    
}
