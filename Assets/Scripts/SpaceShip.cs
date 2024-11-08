

using UnityEngine;



public class SpaceShip : MonoBehaviour
{

    public static SpaceShip instance;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public Vector2 flagSize;
    public Vector2 screenSize;
    public float x;
    public float y;
    public float alpha;
    public float speed;
    void Start()
    {
        flagSize = (GetComponent<SpriteRenderer>().bounds.size) / 2;

        screenSize = Camera.main.ViewportToWorldPoint(Vector3.one) - Camera.main.ViewportToWorldPoint(Vector3.zero);


        //Dvd.GetComponent<SpriteRenderer>().color = Color.blue;

        x = flagSize.x;
        y = flagSize.y;

        instance = this;    



        //HorizontalSpeed = 
    }






    void Update()
    {

        transform.position += transform.up * speed * Time.deltaTime;




        float opposite = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x);
        float adjacent = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y);


        alpha =  -Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);
        //alpha = Mathf.Atan2(opposite, adjacent) * Mathf.RadToDeg;


        transform.rotation = Quaternion.Euler(0f, 0f, alpha);








        if (transform.position.x < -screenSize.x / 2 + flagSize.x / 2)
        {
            
            transform.position = new Vector3(screenSize.x / 2 - flagSize.x / 2, transform.position.y, 0);
          
        }
        else if (transform.position.x > screenSize.x / 2 - flagSize.x / 2)
        {
            
            transform.position = new Vector3(-screenSize.x / 2 + flagSize.x / 2, transform.position.y, 0);
           
        }

       
        if (transform.position.y < -screenSize.y / 2 + flagSize.y / 2)
        {
            
            transform.position = new Vector3(transform.position.x, screenSize.y / 2 - flagSize.y / 2, 0);
            
        }
        else if (transform.position.y > screenSize.y / 2 - flagSize.y / 2)
        {
            
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2 + flagSize.y / 2, 0);
           
        }
    }

}