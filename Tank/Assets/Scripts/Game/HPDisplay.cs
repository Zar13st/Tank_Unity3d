using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour {

    Text playerHP;

	void Awake ()
    {
        playerHP = GetComponent<Text>();
	}

    public void Refresh(float hp)
    {
        playerHP.text = "HP = " + hp.ToString();
    }
}
