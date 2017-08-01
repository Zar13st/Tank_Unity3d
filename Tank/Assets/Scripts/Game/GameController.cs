using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject gameOverText;
    public GameObject reloadButton;

    public bool HeroAlive { get; set; }

    private void Awake()
    {
        HeroAlive = true;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        reloadButton.SetActive(true);

        HeroAlive = false;
    }
}
