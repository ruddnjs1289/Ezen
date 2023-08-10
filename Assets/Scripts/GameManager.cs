using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;

#region 타임라인
/*
20230809
Dictionary<string, string> DataRead(string sPath)
json 데이터 읽어오기 구현
public void DataWrite(string sPath, Dictionary<string, string> dicData)
Dictionary 데이터 json 데이터로 저장

20230810
DataRead Write에 try catch 추가

추가해야할 기능
게임 시작시 게임 데이터 확인 -> 제대로 깔렸는지, 업데이트 되었는지
게임 시작시 계정에 저장된 데이터 초기화 추가
로드 씬 추가
로딩 기능 추가
*/
#endregion
public class GameManager : MonoBehaviour
{
    private string _sGameId;

    public static GameManager instance;
    
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
            return;
        }
        DontDestroyOnLoad(gameObject);
        #endregion
        // 
    }

    // Initialize
    private void InitalizeGameData(string sId)
    {
        // 데이터 베이스에서 긁어와서 초기화//
    }
    // LoadScene
    //public void LoadScene(string sSceneName)
    //{
    //    SceneManager.LoadScene(sSceneName);
    //    // 씬 로드할 때 처리해주어야할것들
    //    // 배경음악 재생
    //    // 스테이지 팩토리 정리
    //    // 열려있는 창이있으면 정리
    //    // 데이터 저장
    //    // 등등
    //}

    // DataRead
    // 데이터 주소 받아와서 그 주소의 json 파일을 Dictionary 형태로 데이터 반환
    public Dictionary<string, string> DataRead(string sPath)
    {
        try
        {
            // 임시 변수 선언, 경로의 파일 읽어오기
            string sData = File.ReadAllText(sPath);
            // 임시 Dictionary 선언 Newtonsoft.json 의 클래스를 사용해 json을 Dictionary로 바꿈
            Dictionary<string, string> dicResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
            //Dictionary 반환
            return dicResult;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sPath}]에서 데이터 읽기에 실패하였습니다.{ex}");
            return null;
        }

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
