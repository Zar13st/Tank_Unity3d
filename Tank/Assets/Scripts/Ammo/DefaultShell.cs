using UnityEngine;

public class DefaultShell : MonoBehaviour, IDamage {

    float speed = 10f;
    float lifeTime = 5f;
    float damage = 10f;

    void Start ()
    {
        Destroy(this.gameObject, lifeTime);
    }

	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public float GetDamage()
    {
        return damage;
    }
}
