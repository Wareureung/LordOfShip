using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    Title main_ui;
    GameObject map_ui;

    Vector3 vec_direction = Vector3.zero;
    float c_dir_speed;
    float time;
    bool state_ver;
    bool state_mapui;

    void Start()
    {
        main_ui = GameObject.Find("Main_UI").GetComponent<Title>();
        map_ui = GameObject.Find("map_canvas");
        map_ui.gameObject.SetActive(false);
        c_dir_speed = 0.0f;
        time = 0.0f;
        state_ver = false;
        state_mapui = false;
    }

    void Update()
    {
        if (main_ui.c_move_state == true && state_ver == false)
        {
            c_dir_speed = 5.0f;
            vec_direction = new Vector3(-3.0f, 3.0f, 1.0f);
            transform.Translate(vec_direction * c_dir_speed * Time.deltaTime);

            if (transform.position.y >= 55)
                state_ver = true;
        }

        if (state_ver == true)
        {
            time += Time.deltaTime;
            c_dir_speed = 10.0f;
            vec_direction = new Vector3(2.0f, -2.0f, 0.0f);

            if (time <= 1.0f)
            {
                transform.Rotate(vec_direction * c_dir_speed * Time.deltaTime);
            }

            if (time >= 1.0f && time <= 4.0f)
            {
                vec_direction = new Vector3(2.0f, 1.0f, 0.0f);
                transform.Translate(vec_direction * c_dir_speed * Time.deltaTime);
                vec_direction = new Vector3(0.5f, 0.0f, 0.1f);           
                transform.Rotate(vec_direction * c_dir_speed * Time.deltaTime);                
            }
            if (time >= 4.0f)
                state_mapui = true;
        }
        if (state_mapui == true)
        {
            map_ui.gameObject.SetActive(true);
        }
    }
}
