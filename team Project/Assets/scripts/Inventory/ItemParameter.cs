using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemParameter
{//   - �ĺ���(ID),��·�(��ų ���),������ �⺻ ��ġ(ĳ���� �Ķ���� ���)
   
    public class OnlyCharaterEquipParams
    {//���� ��� �÷��ټ� �ִ� ĳ������ �Ķ���Ͱ�
        public float fId { get; set; }//��� ������ȣ
        public float fSkillValue { get; set; }//��� �÷��ִ� �нú� ��ų��
        public float fDropRate { get; set; }//��� �����
        //ĳ���� �Ķ���ʹ� �ִٰ�
    }
    public class GemstoneParams
    {//�������� �ش� ��ų�� ���� ���
        public float fId { get; set; }//���� ������ȣ
        public float fUpMagnification { get; set; }//������ �÷��ִ� ��ų ���������
        public float fDropRate { get; set; }//���� �����
    }

}
