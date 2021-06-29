using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;


public class password_button : MonoBehaviour
{
    
    public Text my_answer;
    public string answer;
    private AudioSource[] music;
    private AudioSource typing;
    private AudioSource correct;
    private AudioSource incorrect;
    private AudioSource unlock;

    public GameObject player;
    // Start is called before the first frame update
    public void OnClick_0()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        typing.Play();
        text += "0";
        my_answer.text = text;
    }

    public void OnClick_1()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "1";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_2()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "2";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_3()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "3";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_4()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "4";
        typing.Play();
        my_answer.text = text;
    }


    public void OnClick_5()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "5";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_6()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "6";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_7()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "7";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_8()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "8";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_9()
    {
        string text = my_answer.text;
        if (text == "...")
            text = "";
        text += "9";
        typing.Play();
        my_answer.text = text;
    }

    public void OnClick_Enter()
    {
        if (my_answer.text == answer)
        {
            //do things
            Debug.Log("Yes");
            //correct.Play();
            unlock.Play();
            if (player.GetComponent<test_state>().m_CurrentState == 3)
            {
                player.GetComponent<test_state>().isOpen = true;
            }
            if (player.GetComponent<test_state>().m_CurrentState == 4)
            {
                player.GetComponent<test_state>().isOpen = true;
            }
            if (player.GetComponent<test_state>().m_CurrentState == 7)
            {
                player.GetComponent<test_state>().isOpen = true;
            }
            //Invoke("scenechange",2);

        }
        else
        {
            string text = "";
            my_answer.text = text;
            Debug.Log("No");
            incorrect.Play();
        }
    }

    private void scenechange()
    {
        SceneManager.LoadScene(4);
    }

    void Start()
    {
        music = GetComponents<AudioSource>();
        unlock = music[3];
        typing = music[2];
        correct = music[1];
        incorrect = music[0];
        unlock.Stop();
        typing.Stop();
        correct.Stop();
        incorrect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
