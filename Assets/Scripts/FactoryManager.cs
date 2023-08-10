using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ÿ�Ӷ���
/*
20230809
�ۼ� �Լ�
public void PoolConstruct(string path, int nSize)
public void PoolDeAllocate()
public GameObject GetObject(int nSize)
ť ������ �߰� ���� �ʿ�
get������Ʈ �߰� ���� �ʿ�
get�� ������Ʈ setActive false�� enqueue���ִ� ���� �ʿ�

20230810
����Ʈ ��� Queue ���
PoolConstruct -> public void CreateFactory(string sPath, int nSize)
�̸� �ٲ�, �޸�Ǯ ����, ���ӿ�����Ʈ Ÿ������ ����
PoolDeAllocate -> public void DeCreatePool()
ť Ŭ����
private GameObject CreateObject(GameObject gPrefab)
���������� ���� ������Ʈ ���� ��ȯ
public GameObject GetObject()
Pool���� DeQueue, ���ٸ� ���� ����
public void SetObject(GameObject gObj)
��� ����� ������Ʈ EnQueue
public void Init()
������ �ʱ�ȭ, ť �ʱ�ȭ

�߰��ؾ��� ���
�������� ���������� �����ؾߵǳ�?
CreateFactory ���� ���������� �����ؾ��ϳ�?
*/
#endregion

public class FactoryManager : MonoBehaviour
{
    private GameObject _gPrefab;
    Queue<GameObject> quePool = new Queue<GameObject>();

    void Start()
    {
        Init();
    }
    void Update()
    {

    }
    // �̴ϼȶ����� �ʿ�
    public void Init()
    {
        _gPrefab = null;
        quePool.Clear();
    }
    // �޸�Ǯ ����
    public void CreateFactory(string sPath, int nSize)
    {
        _gPrefab = Resources.Load<GameObject>(sPath);
        for (int i = 0; i < nSize; i++)
        {
            CreateObject(_gPrefab);
        }
    }
    private GameObject CreateObject(GameObject gPrefab)
    {
        GameObject gNewObj = Instantiate(gPrefab, transform);
        quePool.Enqueue(gNewObj);
        gNewObj.SetActive(false);
        return gNewObj;
    }


    // �޸�Ǯ �Ҹ�
    // �Ҵ�� ����Ʈ �Ҹ����ִ� �Լ�
    public void DeCreatePool()
    {
        quePool.Clear();
    }

    // ������Ʈ Queue���� ��������
    public GameObject GetObject()
    {
        if(quePool.Count > 0)
        {
            GameObject gObjInPool = quePool.Dequeue();
            gObjInPool.SetActive(true);
            return gObjInPool;
        }
        else
        {
            GameObject gNewObj = CreateObject(_gPrefab);
            Debug.Assert(gNewObj == null, "���丮 ���� �����");
            gNewObj.SetActive(true);
            return gNewObj;
        }
    }

    // ������Ʈ Queue ������ �־��ֱ�
    public void SetObject(GameObject gObj)
    {
        gObj.SetActive(false);
        quePool.Enqueue(gObj);
    }
}
