using UnityEngine;

public class BFG : MonoBehaviour, IWeapon
{
    public GameObject prefabShell;
    public AudioClip shot;

    GameObject shellsStore;

    float shellSpawnRange = 0.5f;
    float nextFireTime;
    float timeBetweenShoots = 0.3f;

    AudioSource gunAudio;

    void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        shellsStore = GameObject.FindWithTag("ShellsStore");
    }

    void Start()
    {
        nextFireTime = Time.time;
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire") && (nextFireTime <= Time.time))
        {
            PlaySound(shot);

            nextFireTime = Time.time + timeBetweenShoots;

            var shell = Instantiate(prefabShell);
            shell.transform.position = this.transform.position + this.transform.up * shellSpawnRange;
            shell.transform.rotation = this.transform.rotation;
            shell.transform.parent = shellsStore.transform;
        }
    }

    void PlaySound(AudioClip clip)
    {
        gunAudio.PlayOneShot(clip);
    }
}
