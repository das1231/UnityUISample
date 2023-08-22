using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        rotation();
        Scale();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float a = Input.GetAxisRaw("Vertical");
        h = h * speed * Time.deltaTime;
        a = a * speed * Time.deltaTime;
        transform.position += new Vector3(h,a,0);
    }

    void rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 5);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z - 5);
        }
    }
    void Scale()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //transform.localScale = new Vector3(transform.localScale.x + 0.5f, transform.localScale.y + 0.5f, transform.localScale.z + 0.5f);
            transform.localScale += Vector3.one * 1.5f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            transform.localScale += Vector3.one * -1.5f;
        }
    }
}
