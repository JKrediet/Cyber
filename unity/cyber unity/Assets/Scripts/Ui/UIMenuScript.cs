using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuScript : MonoBehaviour
{
    public int void1, void2, void3, void4, void5, void6;
    public Sprite[] levelImage;
    public GameObject story, mainMenu,level;
    public GameObject panel;

    #region loadscenes
    public void LoadScene1()
    {
        SceneManager.LoadScene(void1);
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene(void2);
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene(void3);
    }
    public void LoadScene4()
    {
        SceneManager.LoadScene(void4);
    }
    public void LoadScene5()
    {
        SceneManager.LoadScene(void5);
    }
    public void LoadScene6()
    {
        SceneManager.LoadScene(void6);
    }
    #endregion
    #region fototrue
    public void Foto1true()
    {
        panel.GetComponent<Image>().sprite = levelImage[0];
    }
    public void Foto2true()
    {
        panel.GetComponent<Image>().sprite = levelImage[1];
    }
    public void Foto3true()
    {
        panel.GetComponent<Image>().sprite = levelImage[2];
    }
    public void Foto4true()
    {
        panel.GetComponent<Image>().sprite = levelImage[3];
    }
    public void Foto5true()
    {
        panel.GetComponent<Image>().sprite = levelImage[4];
    }
    public void Foto6true()
    {
        panel.GetComponent<Image>().sprite = levelImage[5];
    }
    #endregion
    #region main menu
    public void Story()
    {
        story.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Level()
    {
        level.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        level.SetActive(false);
        story.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
