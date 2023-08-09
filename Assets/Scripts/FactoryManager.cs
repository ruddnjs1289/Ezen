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

�߰��ؾ��� ���
�ܺ� enqueue
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
    // �̴ϼȶ����� �ʿ�

    // �޸�Ǯ ����
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
    // �޸�Ǯ �Ҹ�
    // �Ҵ�� ����Ʈ �Ҹ����ִ� �Լ�
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
