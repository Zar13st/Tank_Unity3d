using UnityEngine;

public class TankHealth : MonoBehaviour {

    HPDisplay hpUI;
    GameController gameCtrl;

    float health = 100.0f;
    [SerializeField]
    float defense = 0.5f;

    void Awake()
    {
        hpUI = FindObjectOfType<HPDisplay>();
        gameCtrl = FindObjectOfType<GameController>();
    }

    void Damage(float dmg)
    {
        health -= dmg * defense;

        if (health <= 0)
        {
            health = 0;
            gameCtrl.GameOver();
        }
        hpUI.Refresh(health);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyCtrl>().DestroyEnemy();
            Damage(other.GetComponent<IDamage>().GetDamage());
       }
    }
}
