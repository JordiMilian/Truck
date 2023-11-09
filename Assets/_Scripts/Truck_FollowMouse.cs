using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Truck_FollowMouse : MonoBehaviour
{
    Vector2 MousePos;
    [SerializeField] float MoveForce;
    Rigidbody2D rigidbody;
    bool clicking;
    [SerializeField] Road_Speed road;
    [SerializeField] float Accelerator;
    [SerializeField] float Deceleratpor;
    [SerializeField] float MaxSpeed;
    [SerializeField] float MinSpeed;
    [SerializeField] float BaseDrag;
    [SerializeField] SpriteRenderer TruckSprite;
    [SerializeField] float CrashDecelerator;
    [SerializeField] float CrashPush;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.drag = BaseDrag / road.BaseSpeed;

        if (Input.GetMouseButtonDown(1))
        { 
            clicking = true;  
        }

        if (Input.GetMouseButtonUp(1))
        { 
            clicking = false; 
        }

        if (clicking)
        {
            followMouse();
            if (road.BaseSpeed < MaxSpeed) { road.BaseSpeed += Accelerator * Time.deltaTime; }
            
        }
        if (clicking == false)
        {
            if(road.BaseSpeed > MinSpeed) { road.BaseSpeed -= Deceleratpor * Time.deltaTime; }
            
        }
    }
    void followMouse()
    {
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        var dir = pos - transform.position;
        rigidbody.AddForce(dir * MoveForce * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            
            StartCoroutine(SpriteRedFlash(TruckSprite));
            
            Vector2 direction = (transform.position - collision.gameObject.transform.position).normalized;
            rigidbody.AddForce(direction * CrashPush * road.BaseSpeed);

            road.BaseSpeed -= CrashDecelerator;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator SpriteRedFlash(SpriteRenderer sprite)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }
}
