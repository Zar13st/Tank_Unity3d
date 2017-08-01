using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    const int MAXENEMIES = 10;

    public GameObject prefabEnemy;

    int numberEnemies;
    float timeAfterLastSpawn;
    float timeBetweenEnemies = 1f;
	
	void Update ()
    {
        timeAfterLastSpawn += Time.deltaTime;

        if ((numberEnemies < MAXENEMIES) && (timeAfterLastSpawn >= timeBetweenEnemies))
        {
            CreateEnemy();
        }
    }
    public void ReduceEnemyCount()
    {
        numberEnemies--;
    }
    void CreateEnemy()
    {
        timeAfterLastSpawn = 0;
        float randDistance = Random.Range(15, 20);
        float randDirection = Random.Range(0, 360);
        float newEnemyX = this.transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * randDistance);
        float newEnemyY = this.transform.position.y + (Mathf.Sin((randDirection) * Mathf.Deg2Rad) * randDistance);

        var enemy = Instantiate(prefabEnemy);
        enemy.transform.parent = this.transform;
        enemy.transform.position = new Vector2(newEnemyX, newEnemyY);
        enemy.transform.rotation = this.transform.rotation;

        numberEnemies++;
    }
}
