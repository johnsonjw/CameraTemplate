using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float speedwagon;
    private bool start;
    private int points;
    public TextMesh textPoint;

    void GameOver()
    {
        start = false;
        transform.position = new Vector3(-0.2f, 0.82f, -5179f);
    }

    void Win()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        speedwagon = 8f;
        start = false;
        points = 70;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
             start = true;
        }
        if (start) { 
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speedwagon, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speedwagon);
            textPoint.text = "Points:" + points.ToString();
        }
    }
    private void OncollisionEnter(Collision collision)
    {
    
        if(collision.collider.tag == "cubes")
        {
            points = points - 10;
            Destroy(collision.gameObject);
            
        }else if(collision.collider.name == "Wall3")
        {
            Win();
            GameOver();
        }
    }
}
