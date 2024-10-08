using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    

    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //�����ڵ�
        if (Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y.Equals(0))
        {
            rigid2D.AddForce(transform.up * jumpForce);
            animator.SetTrigger("Jump");
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }
        float speedX = Mathf.Abs(rigid2D.velocity.x);

        if (speedX < maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        animator.speed = speedX / 2.0f;
       // if (transform.position.y < 10f)
       // {
       //    SceneManager.LoadScene("CLimbCloud");
      //  }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }

}


