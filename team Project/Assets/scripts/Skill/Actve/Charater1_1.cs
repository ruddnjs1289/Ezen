using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charater1_1 : ActiveSkill
{
    SkillParameter.SkilParams SkilParams = new SkillParameter.SkilParams();
    void Start()
    {
        SetParams();
    }
    public override void SetParams()
    {
        SkilParams.sName = "Charater1_1";

    }

    
}
