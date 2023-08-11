using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;

#region Ÿ�Ӷ���
/*20230809
 * Dictionary<string, string> DataRead(string sPath)
 * json ������ �о���� ����
 * public void DataWrite(string sPath, Dictionary<string, string> dicData)
 * Dictionary ������ json �����ͷ� ����
 */
/*20230810
 * DataRead DataWrite�� try catch �߰�
 */
/* 
 * 
 * 
 * 

�߰��ؾ��� ���
���� ���۽� ���� ������ Ȯ�� -> ����� ��ȴ���, ������Ʈ �Ǿ�����
************ �߿�
���� ������ ������ ����������?   ĳ���� ���ð� ��ų ���ð� ���
CurrentState ���� ���� �������� ������ �־���ҵ�
************
���� ���۽� ������ ����� ������ �ʱ�ȭ �߰�
�ε� �� �߰�
�ε� ��� �߰�
*/
#endregion
public class GameManager : MonoBehaviour
{
    private string _sGameId;

    public static GameManager instance;
    
    void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        #endregion
        // 
    }

    // Initialize
    private void InitalizeGameData(string sId)
    {
        // ������ ���̽����� �ܾ�ͼ� �ʱ�ȭ
        // ���� �� �𸣰���
    }
    // LoadScene
    //public void LoadScene(string sSceneName)
    //{
    //    SceneManager.LoadScene(sSceneName);
    //    // �� �ε��� �� ó�����־���Ұ͵�
    //    // ������� ���
    //    // �������� ���丮 ����
    //    // �����ִ� â�������� ����
    //    // ������ ����
    //    // ���
    //}

    // DataRead
    // ������ �ּ� �޾ƿͼ� �� �ּ��� json ������ Dictionary ���·� ������ ��ȯ
    public Dictionary<string, string> DataRead(string sPath)
    {
        try
        {
            // �ӽ� ���� ����, ����� ���� �о����
            string sData = File.ReadAllText(sPath);
            // �ӽ� Dictionary ���� Newtonsoft.json �� Ŭ������ ����� json�� Dictionary�� �ٲ�
            Dictionary<string, string> dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
            //Dictionary ��ȯ
            return dictResult;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sPath}]���� ������ �б⿡ �����Ͽ����ϴ�.{ex}");
            return null;
        }

    }
    // DataWrite
    // ������ �ּҿ� Dictionary ���·� �����͸� �޾ƿ� json ���Ϸ� ����
    public void DataWrite(string sPath, Dictionary<string, string> dictData)
    {
        try
        {
            // Newtonsoft.json �� Ŭ������ ����� Dictionay�� json���� �ٲ�
            string sJson = JsonConvert.SerializeObject(dictData);
            // ��ο� json ���� ����
            File.WriteAllText(sPath, sJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sPath}]�� ������ ���⿡ �����Ͽ����ϴ�.{ex}");
        }
    } 
}

#region �׽�Ʈ
/*
        string path = Application.persistentDataPath + "/";
        string filename = "testFile.json";
        Dictionary<string, string> test = new Dictionary<string, string>();
        test.Add("level", "1");
        test.Add("name", "test");
        test.Add("attack", "12");
        test.Add("hp", "10");

        DataWrite(path + filename, test);

        Dictionary<string, string> RoadData = DataRead(path + filename);

        foreach (string value in RoadData.Keys)
        {
            Debug.Log("Key : " + value + " value : " + RoadData[value]);
        }

        Debug.Log(DataRead(path + filename)); 
*/
#endregion