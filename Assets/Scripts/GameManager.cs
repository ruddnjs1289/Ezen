using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

#region 타임라인
/*
20230809
작성 함수
Dictionary<string, string> DataRead(string sPath)
public void DataWrite(string sPath, Dictionary<string, string> dicData)

추가해야할 기능
게임 시작시 계정에 저장된 데이터 초기화 추가
로드 씬 추가
로딩 기능 추가
*/
#endregion
public class GameManager : MonoBehaviour
{
    private string _sGameId;

    public static GameManager instance;

    public AccontManager accontManager;
    void Awake()
    {
        #region 싱글톤
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
    // 데이터 주소 받아와서 그 주소의 json 파일을 Dictionary 형태로 데이터 반환
    public Dictionary<string, string> DataRead(string sPath)
    {
        // 임시 Dictionary 선언
        Dictionary<string, string> dicResult = new Dictionary<string, string>();
        // 임시 변수 선언, 경로의 파일 읽어오기
        string sData = File.ReadAllText(sPath);
        // Newtonsoft.json 의 클래스를 사용해 json을 Dictionary로 바꿈
        dicResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
        //Dictionary 반환
        return dicResult;
    }
    // DataWrite
    // 데이터 주소와 Dictionary 형태로 데이터를 받아와 json 파일로 저장
    public void DataWrite(string sPath, Dictionary<string, string> dicData)
    {
        // Newtonsoft.json 의 클래스를 사용해 Dictionay를 json으로 바꿈
        string sJson = JsonConvert.SerializeObject(dicData);
        // 경로에 json 파일 저장
        if(sJson == null)
        {
            Debug.Log("Failed to SerializeObject dictionary to json");
            return;
        }
        File.WriteAllText(sPath, sJson);
    } 
}

#region 테스트
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