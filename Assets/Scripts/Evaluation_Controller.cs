using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Evaluation_Controller : MonoBehaviour
{
    [SerializeField] private Button b_continue;


    // Start is called before the first frame update
    void Start()
    {
        if (b_continue == null)
            b_continue = GameObject.Find("b_continue")?.GetComponent<Button>();

        if (b_continue != null)
            b_continue.onClick.AddListener(LoadGallery);
    }


    public void LoadGallery()
    {
        Game_Manager.Instance.NextDay();
        SceneManager.LoadScene("NorthWall");
    }
}
