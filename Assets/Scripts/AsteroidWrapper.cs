using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Vector2 screenSize;

    public Vector2 asteroidSize;

    private void Start()
    {
        screenSize = new Vector2(Camera.main.orthographicSize * Camera.main.aspect * 2, Camera.main.orthographicSize * 2);
    }

    private void Update()
    {
        WrapScreen();
    }

    void WrapScreen()
    {
        if (transform.position.x < -screenSize.x / 2 + asteroidSize.x / 2)
            transform.position = new Vector3(screenSize.x / 2 - asteroidSize.x / 2, transform.position.y, 0);
        else if (transform.position.x > screenSize.x / 2 - asteroidSize.x / 2)
            transform.position = new Vector3(-screenSize.x / 2 + asteroidSize.x / 2, transform.position.y, 0);

        if (transform.position.y < -screenSize.y / 2 + asteroidSize.y / 2)
            transform.position = new Vector3(transform.position.x, screenSize.y / 2 - asteroidSize.y / 2, 0);
        else if (transform.position.y > screenSize.y / 2 - asteroidSize.y / 2)
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2 + asteroidSize.y / 2, 0);
    }
}
