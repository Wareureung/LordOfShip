using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBoat_2 : MonoBehaviour
{
    bool state = false;
    bool touch_state = false;
    float speed = 1.0f;
    float b = 0.0f;

    float pDirection;
    public AudioSource[] _SFX;
    public Slider powerGage;

    void Start()
    {
        powerGage = GameObject.Find("Slider").GetComponent<Slider>();
    }

    void Update()
    {
        float Direction = pDirection;
        float Go;

        if (state == true)
        {
            Go = 1.0f;

            if (b < 10.0f)
                b += (2.0f * Time.deltaTime);
        }
        else
        {
            Go = 0.0f;
            if (b > 0.0f)

                for (int cost = 0; cost < 10; cost++)
                {
                    if (b > 0.0f)
                        b -= Time.deltaTime;
                }
        }

        if(touch_state == false)
        {
            if (pDirection > 0)
            {
                pDirection -= 0.01f;
                if (pDirection < 0f)
                    pDirection = 0f;
            }
            if (pDirection < 0)
            {
                pDirection += 0.01f;
                if (pDirection > 0f)
                    pDirection = 0f;
            }
        }

        Direction = Direction * (15 * speed) * Time.deltaTime;
        Go = (b * speed * Time.deltaTime) + Go * speed * Time.deltaTime;

        transform.rotation *= Quaternion.AngleAxis(Direction, Vector3.up);
        transform.Translate(Vector3.forward * Go);
    }

    public void Left_Touch()
    {
        touch_state = true;
        pDirection = -1.0f;
    }

    public void Left_Touch_Out()
    {
        touch_state = false;
    }
    public void Right_Touch()
    {
        touch_state = true;
        pDirection = 1.0f;
    }

    public void Right_Touch_Out()
    {
        touch_state = false;
    }
    public void Go_Touch()
    {
        if (state == false)
        {
            state = true;
        }
        else if (state == true)
        {
            state = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PickUp")
        {
      
            other.gameObject.SetActive(false);
            powerGage.value -= 0.1f;


        }
        if (other.transform.tag == "Rock_1")
        {
    
            other.gameObject.SetActive(false);
            powerGage.value -= 0.1f;


        }

        if (other.transform.tag == "Rock_2")
        {

            other.gameObject.SetActive(false);
            powerGage.value -= 0.3f;


        }

        if (other.transform.tag == "Rock_3")
        {
   
            other.gameObject.SetActive(false);
            powerGage.value -= 0.5f;


        }
        if (other.transform.tag == "Rock_4")
        {
   
            other.gameObject.SetActive(false);
            powerGage.value -= 0.3f;


        }
        if (other.transform.tag == "Enemy")
        {

            other.gameObject.SetActive(false);
            powerGage.value -= 0.5f;


        }

        if (other.transform.tag == "ClearArea")
        {
            SceneManager.LoadScene("ClearScene");
        }

    }
}
