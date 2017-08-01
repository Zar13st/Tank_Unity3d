using UnityEngine;
using System.Collections;

public class TankWeaponManager : MonoBehaviour {
    const int DEFAULTWEAPON = 0;

    public GameObject[] weaponArr;

    IWeapon currentWeapon;
    GameObject currWeaponObject;
    GameController gameCtrl;

    int weaponType = 0;
    float timeBetweenWeaponChange = 1f;
    float lastWeaponChangeTime;

    void Awake ()
    {
        gameCtrl = FindObjectOfType<GameController>();
        TakeNewWeapon(DEFAULTWEAPON);
    }

    void Start()
    {
        lastWeaponChangeTime = Time.time;
    }

    void FixedUpdate()
    {
        if (gameCtrl.HeroAlive)
        {
            currentWeapon.Attack();
            ChangeWeapon();
        }
    }

    void ChangeWeapon()
    {
        if (Input.GetButtonDown("NextWeapon") && (weaponType < 2) && (lastWeaponChangeTime <= Time.time))
        {
            weaponType++;
            TakeNewWeapon(weaponType);
            lastWeaponChangeTime = Time.time + timeBetweenWeaponChange;
        }
        if (Input.GetButtonDown("PreviousWeapon") && (weaponType > 0) && (lastWeaponChangeTime <= Time.time))
        {
            weaponType--;
            TakeNewWeapon(weaponType);
            lastWeaponChangeTime = Time.time + timeBetweenWeaponChange;
        }
    }

    void TakeNewWeapon(int id)
    {
        if (currWeaponObject != null)
        {
            Destroy(currWeaponObject);
        }

        currWeaponObject = Instantiate(weaponArr[id], this.transform.position, this.transform.rotation, this.transform);
        currentWeapon = currWeaponObject.GetComponent<IWeapon>();
    }
}
