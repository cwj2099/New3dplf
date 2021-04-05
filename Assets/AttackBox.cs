using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public int side;
    public float damage;
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

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
        if (other.gameObject.GetComponent<HurtBox>())
        {
            HurtBox hbox = other.gameObject.GetComponent<HurtBox>();
            if (hbox.side != side)
            {
                hbox.GetHurt(damage * Time.deltaTime);
            }
            
        }
    }
}
