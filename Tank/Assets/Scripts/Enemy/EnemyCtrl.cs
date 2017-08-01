using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour, IDamage {
    const int ENEMYTYPESNUMBER = 3;

    public GameObject explosionPrefab;
    public Sprite[] enemyImg = new Sprite[ENEMYTYPESNUMBER];
    
    int enemyType;
    float damage;
    float health;
    float defense;
    float speed;
    float timeOutExplosion = 3f;

    GameObject tank;
    EnemySpawn enemySpawn;

    void Awake()
    {
        enemyType = Random.Range(0, ENEMYTYPESNUMBER);
        SetEnemy(enemyType);
        tank = GameObject.FindWithTag("Player");
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }
	void FixedUpdate ()
    {
        Move();
    }

    void SetEnemy(int _type)
    {
        switch (_type)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = enemyImg[0];
                damage = 10f;
                health = 20f;
                defense = 1f;
                speed = 4f;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = enemyImg[1];
                damage = 20f;
                health = 40f;
                defense = 0.8f;
                speed = 2f;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = enemyImg[2];
                damage = 50f;
                health = 50f;
                defense = 0.5f;
                speed = 1f;
                break;
            default:
                Debug.LogError("Wrong enemyType in EnemyCtrl");
                break;
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    public void DestroyEnemy()
    {
        enemySpawn.ReduceEnemyCount();
        var explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        explosion.transform.parent = enemySpawn.transform;
        Destroy(explosion, timeOutExplosion);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            Damage(other.GetComponent<IDamage>().GetDamage());
            Destroy(other.gameObject);
        }
    }

    void Damage(float dmg)
    {
        health -= dmg * defense;
        if (health <= 0) { DestroyEnemy(); }
    }

    void Move()
    {
        Vector3 delta = tank.transform.position - transform.position;
        delta.Normalize();
        transform.position = transform.position + delta * speed * Time.deltaTime;
    }
}
