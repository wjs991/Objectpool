using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_controller : MonoBehaviour
{

    public Text bullet_count;
    public Text impact_count;
    public Text muzzle_count;

    public Text overflow;
    public Text mode;

    // Start is called before the first frame update
    void Start()
    {
        bullet_count.text = ObjectPool.Instance.bullet[0].projectile_poolList.Count.ToString();
        impact_count.text = ObjectPool.Instance.bullet[0].impact_poolList.Count.ToString();
        muzzle_count.text = ObjectPool.Instance.bullet[0].muzzle_poolList.Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int bullet_count_int = ObjectPool.Instance.bullet[0].projectile_poolList.Count;
        int impact_count_int = ObjectPool.Instance.bullet[0].impact_poolList.Count;
        int muzzle_count_int = ObjectPool.Instance.bullet[0].muzzle_poolList.Count;
        bullet_count.text = bullet_count_int.ToString();
        impact_count.text = impact_count_int.ToString();
        muzzle_count.text = muzzle_count_int.ToString();

        if(bullet_count_int ==0 || impact_count_int == 0 || muzzle_count_int == 0)
        {
            overflow.gameObject.SetActive(true);
        }
    }

    public void obj_btn()
    {
        if (ObjectPool.Instance.obj_pool)
        {
            ObjectPool.Instance.obj_pool = false;
            mode.text = "normal mod";
        }
        else
        {
            ObjectPool.Instance.obj_pool = true;
            mode.text = "pooling mod";
        }
    }
}
