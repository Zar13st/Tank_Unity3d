using UnityEngine;

public class MultipleGun : MonoBehaviour, IWeapon
{
    const int SHELLNUMBER = 7;
    const float DEGREESBETWEENSHELS = 10f;
    const int SHELLOFFSET = 3;

    public GameObject prefabShell;
    public AudioClip shot;

    GameObject shellsStore;

    float shellSpawnRange = 0.5f;
    float nextFireTime;
    float timeBetweenShoots = 0.5f;

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

            for (int i = 0; i < SHELLNUMBER; i++)
            {
                var shell = Instantiate(prefabShell);
                shell.transform.position = this.transform.position + this.transform.up * shellSpawnRange;
                shell.transform.rotation = this.transform.rotation;
                shell.transform.Rotate(Vector3.forward * DEGREESBETWEENSHELS * (i - SHELLOFFSET) );
                shell.transform.parent = shellsStore.transform;
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        gunAudio.PlayOneShot(clip);
    }
}


