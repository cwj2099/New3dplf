﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingObject : MonoBehaviour
{
    public float MHP=3;
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = MHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
