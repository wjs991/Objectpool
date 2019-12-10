using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class bullet
{
    public string poolItemName = string.Empty; //검색할 때 사용할 이름
    public int pool_count = 0;                 //초기화 객체 수
    public GameObject impactParticle;
    public GameObject projectileParticle;
    public GameObject muzzleParticle;

    [SerializeField]
    public List<GameObject> impact_poolList = new List<GameObject>();
    public List<GameObject> projectile_poolList = new List<GameObject>();
    public List<GameObject> muzzle_poolList = new List<GameObject>();
    //프리펩을 카운트 만큼 리스트에 저장함
    public void Initialize(Transform parent = null)
    {
        for (int x = 0; x < pool_count; x++)
        {
            impact_poolList.Add(CreateItem(impactParticle, parent));
            projectile_poolList.Add(CreateItem(projectileParticle, parent));
            muzzle_poolList.Add(CreateItem(muzzleParticle, parent));
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

    //객체가 필요할때 오브젝트 풀에 요청하는 용도로 사용
 
    public GameObject impact_PopFromPool(Transform parent = null)
    {
        if (impact_poolList.Count == 0)
            impact_poolList.Add(CreateItem(impactParticle, parent));

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
    public GameObject projectile_PopFromPool(Transform parent = null)
    {
        if (projectile_poolList.Count == 0)
        {
            projectile_poolList.Add(CreateItem(projectileParticle, parent));
        }
        GameObject item = projectile_poolList[0];
        projectile_poolList.RemoveAt(0);
        return item;
    }
    public void projectile_PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        projectile_poolList.Add(item);

    }
    public GameObject muzzle_PopFromPool(Transform parent = null)
    {
        if (muzzle_poolList.Count == 0)
            muzzle_poolList.Add(CreateItem(muzzleParticle, parent));

        GameObject item = muzzle_poolList[0];
        muzzle_poolList.RemoveAt(0);
        return item;
    }
    public void muzle_PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        muzzle_poolList.Add(item);
    }

}
