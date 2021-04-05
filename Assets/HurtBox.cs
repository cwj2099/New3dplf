using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public LivingObject Owner;
    public int side;
    Collider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHurt(float damage)
    {
        Owner.HP -= damage;
    }
}
