using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtMouse : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;    
    public float bulletSpeed = 10f; 

    public ObjectPool pool;
    public GameObject enemy;

    public float attackDuration;
    public float currentAttackDuration;
    public Animator anim;

    public GameObject cursor;

    private void Start()
    {
        StartCoroutine(SpawnObject());
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        currentAttackDuration -= Time.deltaTime;

        if (Input.GetMouseButton(0)&&currentAttackDuration<0) 
        {
            Shoot();
            currentAttackDuration = attackDuration;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Cursor.visible = false;
        cursor.transform.position = mousePosition;

    }

    void Shoot()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

       
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        
        GameObject bullet = pool.GetObject();
        bullet.transform.position=firePoint.position; 
        StartCoroutine(destObj(bullet));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
        anim.SetTrigger("Attack");
    }

    IEnumerator destObj(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        pool.ReturnObject(obj);
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
           
            Instantiate(enemy, transform.position, Quaternion.identity);

           
            yield return new WaitForSeconds(Random.Range(0.1f,2f));
        }
    }
}
