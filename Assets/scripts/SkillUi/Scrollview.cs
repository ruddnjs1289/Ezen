using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollview : MonoBehaviour
{
    public Transform content;
    public GameObject cellviewPrefab;
    private const int THRESHHOLD= 24;

    public void Init()
    {//������ �ִ� ������ ������ŭ ����
        int myItemCount = 10;
        
        for(int i=0;i<10 ;i++)
        {
            var go = Instantiate(this.cellviewPrefab, this.content);
            var cellview = go.GetComponent<UiCellView>();
            //������,������ �߰�
            //cellview.Init();
        }
        this.GetComponent<ScrollRect>().vertical = myItemCount > THRESHHOLD;
    }
}
