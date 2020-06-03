using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuScript : MonoBehaviour
{
    public int void1, void2, void3, void4, void5, void6, void7, void8, void9, void10;
    public GameObject[] levelImage;
    public GameObject story, mainMenu,level;
    void Start()
    {

    }

    void Update()
    {

    }
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
    public void LoadScene7()
    {
        SceneManager.LoadScene(void7);
    }
    public void LoadScene8()
    {
        SceneManager.LoadScene(void8);
    }
    public void LoadScene9()
    {
        SceneManager.LoadScene(void9);
    }
    public void LoadScene10()
    {
        SceneManager.LoadScene(void10);
    }
    public void Foto1false()
    {
       levelImage[0].SetActive(false);
    }
    public void Foto2false()
    {
        levelImage[1].SetActive(false);
    }
    public void Foto3false()
    {
        levelImage[2].SetActive(false);
    }
    public void Foto4false()
    {
        levelImage[3].SetActive(false);
    }
    public void Foto5false()
    {
        levelImage[4].SetActive(false);
    }
    public void Foto6false()
    {
        levelImage[5].SetActive(false);
    }
    public void Foto7false()
    {
        levelImage[6].SetActive(false);
    }
    public void Foto8false()
    {
        levelImage[7].SetActive(false);
    }
    public void Foto9false()
    {
        levelImage[8].SetActive(false);
    }
    public void Foto10false()
    {
        levelImage[9].SetActive(false);
    }
    public void Foto1true()
    {
        levelImage[0].SetActive(true);
    }
    public void Foto2true()
    {
        levelImage[1].SetActive(true);
    }
    public void Foto3true()
    {
        levelImage[2].SetActive(true);
    }
    public void Foto4true()
    {
        levelImage[3].SetActive(true);
    }
    public void Foto5true()
    {
        levelImage[4].SetActive(true);
    }
    public void Foto6true()
    {
        levelImage[5].SetActive(true);
    }
    public void Foto7true()
    {
        levelImage[6].SetActive(true);
    }
    public void Foto8true()
    {
        levelImage[7].SetActive(true);
    }
    public void Foto9true()
    {
        levelImage[8].SetActive(true);
    }
    public void Foto10true()
    {
        levelImage[9].SetActive(true);
    }
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
}
