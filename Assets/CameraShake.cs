﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originPos;
    void Start()
    {
        originPos = transform.localPosition;
    }
    public IEnumerator Shake(float duration,float magnitude)
    {
        float timer = 0;
        while (timer <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * magnitude + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;
    }
}
