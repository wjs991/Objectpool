using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shot : MonoBehaviour
{
    public bullet Bullet;
    public Transform shot_point;

    public bool object_pool;
    void Start()
    {
        ObjectPool.Instance.bullet[0].Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectPool.Instance.obj_pool)
        {
            object_pool = true;
        }
        else
        {
            object_pool = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log("hit point : " + hit.point);
                if(hit.collider != null)
                {
                    this.transform.LookAt(hit.point);
                    if (object_pool)
                    {
                        StartCoroutine("Obj_shot");
                    }
                    else
                    {
                        StartCoroutine("shot");
                    }
                    
                }
            }

        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider != null)
                {
                    this.transform.LookAt(hit.point);
                    //
                }
            }
        }
    }

    IEnumerator shot()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);

            GameObject b = Instantiate(Resources.Load("projectile") as GameObject);
            b.transform.position = shot_point.position;
            b.transform.forward = this.transform.forward;
            b.GetComponent<Rigidbody>().AddForce(this.transform.forward * 300f);
            GameObject m = Instantiate(Resources.Load("muzzle") as GameObject);
            m.transform.position = shot_point.position;
            m.transform.forward = this.transform.forward;
            StartCoroutine("destory_muzzle", m);
            StartCoroutine("destory_projectile", b);
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.09f, 0.03f));
        }
        
    }

    IEnumerator Obj_shot()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);

            GameObject b = ObjectPool.Instance.bullet[0].projectile_PopFromPool();
            b.GetComponent<Rigidbody>().velocity = Vector3.zero;
            b.GetComponent<CapsuleCollider>().enabled = true;
            b.transform.position = shot_point.position;
            b.transform.forward = this.transform.forward;
            b.gameObject.SetActive(true);
            b.GetComponent<Rigidbody>().AddForce(this.transform.forward * 300f);
            b.GetComponent<bullet_move>().obj_pool = true;
            GameObject m = ObjectPool.Instance.bullet[0].muzzle_PopFromPool();
            m.transform.position = shot_point.position;
            m.transform.forward = this.transform.forward;
            m.gameObject.SetActive(true);
            StartCoroutine("destory_muzzle", m);
            StartCoroutine("destory_projectile", b);
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.09f, 0.03f));
        }
    }

    IEnumerator destory_muzzle(GameObject muzzle)
    {
        yield return new WaitForSeconds(0.5f);
        if (object_pool)
        {
            ObjectPool.Instance.bullet[0].muzle_PushToPool(muzzle);
        }
        else
        {
            Destroy(muzzle);
        }
        
    }

    IEnumerator destory_projectile(GameObject proj)
    {
        yield return new WaitForSeconds(3f);
        if (object_pool)
        {
            ObjectPool.Instance.bullet[0].projectile_PushToPool(proj);
        }
        else
        {
            Destroy(proj);
        }
        
    }
}
