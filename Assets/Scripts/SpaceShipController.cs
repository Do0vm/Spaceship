using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float shootCooldown = 0.2f;
    public static SpaceShip instance;

    public float acceleration = 5f;
    public float maxSpeed = 10f;
    public float boostMultiplier = 2f;
    public float deceleration = 3f;
    public float projectileLifetime;
    public Vector2 shipSize;
    public Vector2 screenSize;

    public float currentSpeed = 0f;
    private float lastShotTime;
    private bool isStanding = false;
    private float alpha;
    
    void Start()
    {
        shipSize = (GetComponent<SpriteRenderer>().bounds.size) / 2;
        screenSize = Camera.main.ViewportToWorldPoint(Vector3.one) - Camera.main.ViewportToWorldPoint(Vector3.zero);
        instance = this;
    }

    void Update()
    {
        // Calculate angle to mouse
        float opposite = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x);
        float adjacent = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y);
        alpha = -Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);
        transform.rotation = Quaternion.Euler(0f, 0f, alpha);

        // Shooting with cooldown
        if (Input.GetMouseButton(0) && Time.time - lastShotTime > shootCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        float distanceToMouse = Vector3.Distance(transform.position, mouseWorldPos);

        // Boost mechanism
        float currentAcceleration = Input.GetKey(KeyCode.LeftShift) ? acceleration * boostMultiplier : acceleration;

        if (distanceToMouse > 0.1f)
        {
            isStanding = false;
            
            currentSpeed = Mathf.Min(currentSpeed + currentAcceleration * Time.deltaTime, maxSpeed);
            transform.position += transform.up * currentSpeed * Time.deltaTime;
        }
        else
        {
            isStanding = true;
            currentSpeed = 0;
        }

        // Screen wrapping
        WrapScreen();
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        projectileLifetime = (screenSize.x)/40f;

        rb.velocity = transform.up * projectileSpeed;
        Destroy(projectile, projectileLifetime);
    }

    void WrapScreen()
    {
        // Horizontal wrapping
        if (transform.position.x < -screenSize.x / 2 + shipSize.x / 2)
            transform.position = new Vector3(screenSize.x / 2 - shipSize.x / 2, transform.position.y, 0);
        else if (transform.position.x > screenSize.x / 2 - shipSize.x / 2)
            transform.position = new Vector3(-screenSize.x / 2 + shipSize.x / 2, transform.position.y, 0);

        // Vertical wrapping
        if (transform.position.y < -screenSize.y / 2 + shipSize.y / 2)
            transform.position = new Vector3(transform.position.x, screenSize.y / 2 - shipSize.y / 2, 0);
        else if (transform.position.y > screenSize.y / 2 - shipSize.y / 2)
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2 + shipSize.y / 2, 0);
    }

    public bool IsStanding => isStanding;
}