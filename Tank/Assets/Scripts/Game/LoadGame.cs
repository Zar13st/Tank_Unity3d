using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(1);
            FindObjectOfType<GameController>().HeroAlive = true;
        });
    }
}
