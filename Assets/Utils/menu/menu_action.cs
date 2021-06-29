using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//
public class menu_action : MonoBehaviour
{
	public void clickStart()
    {
        Debug.Log("start");
        SceneManager.LoadScene(8);
    }
    public void clickExit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    void Start()
    {
        Debug.Log("load menu_action");
    }

    // Update is called once per frame
    void Update()
    {

    }
}