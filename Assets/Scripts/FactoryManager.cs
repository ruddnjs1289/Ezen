using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 타임라인
/*
20230809
작성 함수
public void PoolConstruct(string path, int nSize)
public void PoolDeAllocate()
public GameObject GetObject(int nSize)
큐 해제는 추가 구현 필요
get오브젝트 추가 구현 필요
get한 오브젝트 setActive false시 enqueue해주는 과정 필요

추가해야할 기능
외부 enqueue
Initialize

*/
#endregion

public class FactoryManager : MonoBehaviour
{
     Queue<GameObject> quePool = new Queue<GameObject>();


    void Start()
    {

    }
    void Update()
    {

    }
    // 이니셜라이즈 필요

    // 메모리풀 생성
    public void PoolAllocate(string path, int nSize)
    {
        GameObject gPrefab = Resources.Load<GameObject>(path);
        for (int i = 0; i < nSize; i++)
        {
            GameObject newPrefab = Instantiate(gPrefab, transform);
            quePool.Enqueue(newPrefab);
            newPrefab.SetActive(false);
        }
    }
    // 메모리풀 소멸
    // 할당된 리스트 소멸해주는 함수
    public void PoolDeAllocate()
    {
        quePool.Clear();
    }

    public GameObject GetObject(int nSize)
    {
        GameObject gValue = quePool.Dequeue();
        
        return gValue;
    }

}
