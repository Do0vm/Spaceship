

//using UnityEngine;



//public class SpaceShip : MonoBehaviour
//{
//    public GameObject projectilePrefab;
//    public float projectileSpeed;
//    public static SpaceShip instance;
//    public float HorizontalSpeed;
//    public float VerticalSpeed;
//    public Vector2 shipSize;
//    public Vector2 screenSize;
//    public float x;
//    public float y;
//    public float alpha;
//    public float speed;

//    void Start()
//    {
//        shipSize = (GetComponent<SpriteRenderer>().bounds.size) / 2;

//        screenSize = Camera.main.ViewportToWorldPoint(Vector3.one) - Camera.main.ViewportToWorldPoint(Vector3.zero);



//        x = shipSize.x;
//        y = shipSize.y;

//        instance = this;    




//    }






//    void Update()
//    {

//        transform.position += transform.up * speed * Time.deltaTime;




//        float opposite = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x);
//        float adjacent = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y);


//        alpha =  -Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);


//        transform.rotation = Quaternion.Euler(0f, 0f, alpha);






//        if (transform.position.x < -screenSize.x / 2 + shipSize.x / 2)
//        {
            
//            transform.position = new Vector3(screenSize.x / 2 - shipSize.x / 2, transform.position.y, 0);
          
//        }
//        else if (transform.position.x > screenSize.x / 2 - shipSize.x / 2)
//        {
            
//            transform.position = new Vector3(-screenSize.x / 2 + shipSize.x / 2, transform.position.y, 0);
           
//        }

       
//        if (transform.position.y < -screenSize.y / 2 + shipSize.y / 2)
//        {
            
//            transform.position = new Vector3(transform.position.x, screenSize.y / 2 - shipSize.y / 2, 0);
            
//        }
//        else if (transform.position.y > screenSize.y / 2 - shipSize.y / 2)
//        {
            
//            transform.position = new Vector3(transform.position.x, -screenSize.y / 2 + shipSize.y / 2, 0);
           
//        }
//    }


//    //private void OnCollisionEnter2D(Collision2D collision)
//    //{
        
//    //}
//}