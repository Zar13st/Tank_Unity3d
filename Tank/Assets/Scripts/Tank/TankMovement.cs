using UnityEngine;

public class TankMovement : MonoBehaviour {

    GameController gameCtrl;

    [SerializeField]
    float movingSpeed = 5.0f;
    [SerializeField]
    float rotationSpeed = 90f;

    void Awake()
    {
        gameCtrl = FindObjectOfType<GameController>();
    }

    void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Vertical");
        float rotation = Input.GetAxisRaw("Horizontal");

        if (gameCtrl.HeroAlive)
        {
            Move(direction, rotation);
        }
    }
        
    void Move(float direction,  float rotation)
    {
        this.transform.position += this.transform.up * movingSpeed * direction * Time.deltaTime;
        this.transform.Rotate(Vector3.forward * rotationSpeed * - rotation * Time.deltaTime);
    }
}
