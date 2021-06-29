using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;


public class TextTyping : MonoBehaviour
{
    public bool IsChangeScene;
    public float charsPerSecond = 0.2f;//打字間隔的時間
    public GameObject nextText;
    public int ToScene;

    private string words;//儲存需要顯示的文字
    private bool isActive = false;
    private float timer;//計時器
    private Text myText;
    private int currentPos = 0;
    private AudioSource keyAudio;

    private void Start()
    {
        timer = 0f;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        myText = GetComponent<Text>();
        words = myText.text;
        //獲取Text的文字資訊，儲存到words中，然後動態更新文字
        //顯示的內容，實現打字機的效果
        myText.text = "";
        keyAudio = GetComponent<AudioSource>();
        keyAudio.Stop();
    }

    private void Update()
    {
        OnStartWriter();
    }

    public void StartEffect()
    {
        isActive = true;
    }

    //執行打字任務
    private void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {
                timer = 0f;
                currentPos++;
                //重新整理文字顯示內容
                myText.text = words.Substring(0, currentPos);
                if (currentPos < words.Length)
                {
                    if (words[currentPos] != '\n')
                        keyAudio.Play();
                }
                if (currentPos >= words.Length)
                {
                    
                    OnFinish();
                    if(nextText != null)
                        Invoke("NextText", 1);
                    keyAudio.Stop();
                }
            }
        }
    }

    private void NextText()
    {
        nextText.SetActive(true);
    }

    private void changescene()
    {

        SceneManager.LoadScene(ToScene);
    }

    //結束打字，初始化資料
    private void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
        if(IsChangeScene == true)
            Invoke("changescene", 2);
    }
}