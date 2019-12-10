using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 start_pos;
    public bool obj_pool;
    GameObject impact;
    void Start()
    {
        start_pos = this.transform.position;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
           
            if (obj_pool)
            {
                impact = ObjectPool.Instance.bullet[0].impact_PopFromPool();
                impact.SetActive(true);
            }
            else
            {
                impact = Instantiate(Resources.Load("impact") as GameObject);
            }
            impact.transform.position = collision.contacts[0].point;
            impact.transform.forward = (start_pos - collision.contacts[0].point).normalized;

            if (obj_pool)
            {
                StartCoroutine("impact_push");
            }
            this.transform.position = collision.contacts[0].point;

        }
    }

    IEnumerator impact_push()
    {
        yield return new WaitForSeconds(1f);
        if (obj_pool)
        {
            ObjectPool.Instance.bullet[0].impact_PushToPool(impact);
        }
        else
        {
            Destroy(impact);
        }
        
    }
}
