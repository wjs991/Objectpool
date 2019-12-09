using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class bullet : MonoBehaviour
{
    public string poolItemName = string.Empty; //검색할 때 사용할 이름
    public GameObject prefab = null;           //오브젝트 풀에 저장할 프리팹
    public int pool_count = 0;                 //초기화 객체 수
    public GameObject impactParticle;
    public GameObject projectileParticle;
    public GameObject muzzleParticle;

    [SerializeField]
    public List<GameObject> bullet_poolList = new List<GameObject>();
    public List<GameObject> impact_poolList = new List<GameObject>();
    public List<GameObject> project_poolList = new List<GameObject>();
    public List<GameObject> muzle_poolList = new List<GameObject>();
    //프리펩을 카운트 만큼 리스트에 저장함
    public void Initialize(Transform parent = null)
    {
        for (int x = 0; x < pool_count; x++)
        {
            bullet_poolList.Add(CreateItem(prefab, parent));
            impact_poolList.Add(CreateItem(impactParticle, parent));
            project_poolList.Add(CreateItem(projectileParticle, parent));
            muzle_poolList.Add(CreateItem(muzzleParticle, parent));
        }
    }
    private GameObject CreateItem(GameObject obj, Transform parent = null)
    {
        GameObject item = Object.Instantiate(obj) as GameObject;
        item.name = poolItemName;
        item.transform.SetParent(parent);
        item.SetActive(false);
        return item;
    }

    public void bullet_PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        bullet_poolList.Add(item);
    }
    //객체가 필요할때 오브젝트 풀에 요청하는 용도로 사용
    public GameObject bullet_PopFromPool(Transform parent = null)
    {
        if (bullet_poolList.Count == 0)
            bullet_poolList.Add(CreateItem(prefab, parent));

        GameObject item = bullet_poolList[0];
        bullet_poolList.RemoveAt(0);
        return item;
    }
    public GameObject impact_PopFromPool(Transform parent = null)
    {
        if (impact_poolList.Count == 0)
            impact_poolList.Add(CreateItem(prefab, parent));

        GameObject item = impact_poolList[0];
        impact_poolList.RemoveAt(0);
        return item;
    }
    public void impact_PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        impact_poolList.Add(item);
    }
    public GameObject project_PopFromPool(Transform parent = null)
    {
        if (project_poolList.Count == 0)
        {
            project_poolList.Add(CreateItem(prefab, parent));
            Debug.Log("sdfasg");
        }
        GameObject item = project_poolList[0];
        project_poolList.RemoveAt(0);
        Debug.Log("list0 : " + project_poolList[0]);
        return item;
    }
    public void project_PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        project_poolList.Add(item);

    }
    public GameObject muzzle_PopFromPool(Transform parent = null)
    {
        if (muzle_poolList.Count == 0)
            muzle_poolList.Add(CreateItem(prefab, parent));

        GameObject item = muzle_poolList[0];
        muzle_poolList.RemoveAt(0);
        return item;
    }
    public void muzle_PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        muzle_poolList.Add(item);
    }

}
