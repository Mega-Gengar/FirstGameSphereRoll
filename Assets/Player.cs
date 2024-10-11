using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
            //Time.timeScale = 1;
            return;
        }
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x*turnSpeed*Time.deltaTime, 0, speed * Time.deltaTime);

        if(transform.position.x<-2.5||transform.position.x>2.5)
        {
            transform.Translate(0, -4 * speed * Time.deltaTime,0);
        }
        if (transform.position.y < -20)
        {
            Debug.Log("µôÏÂÈ¥ÁË");
            Time.timeScale = 0;
        }
    }
}
