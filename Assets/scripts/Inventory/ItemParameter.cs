using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ItemParameter
{//   - �ĺ���(ID),��·�(��ų ���),������ �⺻ ��ġ(ĳ���� �Ķ���� ���)
    public enum ItemType { EQUIPMENT,GEMSTONE}
   [Serializable]
    public class OnlyCharaterEquipParams
    {//���� ��� �÷��ټ� �ִ� ĳ������ �Ķ���Ͱ�
        public float fId;//��� ������ȣ
        public float fSkillValue;//��� �÷��ִ� �нú� ��ų��
        public float fDropRate;//��� �����
        //��½����� ĳ���� ���ݵ�
    }
    [Serializable]
    public class GemstoneParams
    {//�������� �ش� ��ų�� ���� ���
        public float fId;//���� ������ȣ
        public float fUpMagnification;//������ �÷��ִ� ��ų ���������
        public float fDropRate;//���� �����
    }

}
