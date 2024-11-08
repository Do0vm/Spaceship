using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class MouseInput : MonoBehaviour
{

    float alpha;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float opposite = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x);
        float adjacent = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y);


        alpha = (180 - Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI));
        //alpha = Mathf.Atan2(opposite, adjacent) * Mathf.RadToDeg;


        transform.rotation = Quaternion.Euler(0f, 0f, alpha);
    }
}
