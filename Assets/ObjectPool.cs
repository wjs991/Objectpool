using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public List<bullet> bullet = new List<bullet>();
    public bool obj_pool;
    protected ObjectPool() { }


}
