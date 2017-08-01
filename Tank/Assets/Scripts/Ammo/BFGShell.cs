using UnityEngine;

public class BFGShell : MonoBehaviour , IDamage
{
    const int SHELLNUMBER = 18;
    const float DEGREESBETWEENSHELS = 20f;

    public GameObject prefabShell;

    GameObject shellsStore;

    float speed = 7f;
    float lifeTime = 7f;
    float damage = 40f;

    void Awake()
    {
        shellsStore = GameObject.FindWithTag("ShellsStore");
    }
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public float GetDamage()
    {
        CreateShrapnel();
        return damage;
    }

    void CreateShrapnel()
    {
        for (int i = 0; i < SHELLNUMBER; i++)
        {
            var shell = Instantiate(prefabShell);
            shell.transform.rotation = this.transform.rotation;
            shell.transform.Rotate(Vector3.forward * DEGREESBETWEENSHELS * i);
            shell.transform.position = this.transform.position ;
            shell.transform.parent = shellsStore.transform;
        }
    }
}
