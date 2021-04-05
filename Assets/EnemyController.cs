using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] private float speed = 4.0f;
    GameObject player;

    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        if (Vector3.Distance(player.transform.position, transform.position) <= 50)
        {
            moveDirection = (player.transform.position - transform.position).normalized;
        }
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}
