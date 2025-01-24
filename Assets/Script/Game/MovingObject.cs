using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float minX = -5f; 
    [SerializeField] private float maxX = 5f; 
    [SerializeField] private float spawnY = 6f; 
    [SerializeField] private float destroyY = -6f; 

    public int healt;
   

    private void Start()
    {
        float randomX = Random.Range(minX, maxX);
        transform.position = new Vector3(randomX, spawnY, 0f);
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < destroyY)
        {
            FindAnyObjectByType<HealthTester>().takeDmg();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            damage(collision.gameObject);
            StartCoroutine(damageAnim());
            FindAnyObjectByType<ObjectPool>().ReturnObject(collision.gameObject);

        }
    }

    public void damage(GameObject obj)
    {
        healt--;
        if(healt <= 0)
        {
            FindAnyObjectByType<HealthTester>().addScore();
            Destroy(gameObject);
        }
    }

    IEnumerator damageAnim()
    {
        
        GetComponent<SpriteRenderer>().color= Color.white;
       
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.blue;

    }
}
