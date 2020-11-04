using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Next_Scene : MonoBehaviour
{
    Image fade;
    float fades;
    float time;
    bool check_press;
    int state = 0;

    void Start()
    {
        gameObject.SetActive(false);
        fades = 0.0f;
        time = 0.0f;
        check_press = false;
    }

    void Update()
    {
        if (check_press == true)
        {
            time += Time.deltaTime;
            if (fades >= 0.0f && time <= 0.1f)
            {
                fades += 0.05f;
                fade.color = new Color(0, 0, 0, fades);
                time = 0;
            }
            if (fades >= 1.0f)
            {
                time = 0;
                if(state == 1)
                {
                    SceneManager.LoadScene("VeryEasy");
                }
                if(state == 2)
                {
                    SceneManager.LoadScene("Easy");

                }
                if (state == 3)
                {
                    SceneManager.LoadScene("Normal");
                }
                if (state == 4)
                {
                    SceneManager.LoadScene("Hard");
                }
            }                
        }
    }

    public void OnPointerClick(PointerEventData data)
    {
        check_press = true;
    }

    public void VeryEasy()
    {
        state = 1;
        check_press = true;
        gameObject.SetActive(true);
    }
    public void Easy()
    {
        state = 2;
        check_press = true;
        gameObject.SetActive(true);
    }
    public void Normal()
    {
        state = 3;
        check_press = true;
        gameObject.SetActive(true);
    }
    public void Hard()
    {
        state = 4;
        check_press = true;
        gameObject.SetActive(true);
    }

}
