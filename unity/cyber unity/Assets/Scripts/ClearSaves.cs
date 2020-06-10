using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSaves : MonoBehaviour
{
    public void Clear_Saves()
    {
        PlayerPrefs.DeleteAll();
    }
}
