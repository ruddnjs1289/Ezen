using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

#region Ÿ�Ӷ���
/*
20230809
�ۼ� �Լ�
Dictionary<string, string> DataRead(string sPath)
public void DataWrite(string sPath, Dictionary<string, string> dicData)

�߰��ؾ��� ���
���� ���۽� ������ ����� ������ �ʱ�ȭ �߰�
�ε� �� �߰�
�ε� ��� �߰�
*/
#endregion
public class GameManager : MonoBehaviour
{
    private string _sGameId;

    public static GameManager instance;

    public AccontManager accontManager;
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
        }
        DontDestroyOnLoad(gameObject);
        #endregion
        
    }
    void Start()
    {
        InitalizeGameData("");
    }
    void Update()
    {
        
    }

    // LoadScene
    // Initialize
    private void InitalizeGameData(string sId)
    {

    }
    // DataRead
    // ������ �ּ� �޾ƿͼ� �� �ּ��� json ������ Dictionary ���·� ������ ��ȯ
    public Dictionary<string, string> DataRead(string sPath)
    {
        // �ӽ� Dictionary ����
        Dictionary<string, string> dicResult = new Dictionary<string, string>();
        // �ӽ� ���� ����, ����� ���� �о����
        string sData = File.ReadAllText(sPath);
        // Newtonsoft.json �� Ŭ������ ����� json�� Dictionary�� �ٲ�
        dicResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
        //Dictionary ��ȯ
        return dicResult;
    }
    // DataWrite
    // ������ �ּҿ� Dictionary ���·� �����͸� �޾ƿ� json ���Ϸ� ����
    public void DataWrite(string sPath, Dictionary<string, string> dicData)
    {
        // Newtonsoft.json �� Ŭ������ ����� Dictionay�� json���� �ٲ�
        string sJson = JsonConvert.SerializeObject(dicData);
        // ��ο� json ���� ����
        if(sJson == null)
        {
            Debug.Log("Failed to SerializeObject dictionary to json");
            return;
        }
        File.WriteAllText(sPath, sJson);
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