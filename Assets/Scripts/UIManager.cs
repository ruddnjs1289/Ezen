using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#region Ÿ�Ӷ���
/*

�߰��ؾ��� ���
������ ui �����ؾ���.
*/
#endregion
public class UIManager : MonoBehaviour
{


    // json ���� �����ŷ� ui �Ҵ��ϱ�

    protected virtual void OnSelectStageButtonDown()
    {
        SceneManager.LoadScene("SelectStageScene");
    }
}
