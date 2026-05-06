using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Navigation : MonoBehaviour
{

    [SerializeField] private string[] scenes;
    [SerializeField] private Button b_left;
    [SerializeField] private Button b_right;
    [SerializeField] private Button b_shop;
    [SerializeField] private Button b_return;
    
    void Start()
    {
        //MOVEMENT
        if (b_left == null)
            b_left = GameObject.Find("b_left")?.GetComponent<Button>();

        if (b_right == null)
            b_right = GameObject.Find("b_right")?.GetComponent<Button>();

        if (b_shop == null)
            b_shop = GameObject.Find("b_shop")?.GetComponent<Button>();

        if (b_left != null)
            b_left.onClick.AddListener(LoadLeft);

        if (b_right != null)
            b_right.onClick.AddListener(LoadRight);

        if (b_shop != null)
            b_shop.onClick.AddListener(LoadShop);

        if (b_return == null)
            b_return = GameObject.Find("b_return")?.GetComponent<Button>();


        if (b_return != null)
            b_return.onClick.AddListener(ReturnToPreviousScene);
    
    }

    private void Awake()
    {
        if (scenes == null || scenes.Length == 0)
        {
            scenes = new string[]
            {
                "NorthWall",
                "WestWall",
                "SouthWall",
                "EastWall"
            };
        }
    }

    public void LoadLeft()
    {
        int currentIndex = System.Array.IndexOf(scenes, SceneManager.GetActiveScene().name);

        int nextIndex = currentIndex + 1;

        if (nextIndex >= scenes.Length)
            nextIndex = 0;

        SceneManager.LoadScene(scenes[nextIndex]);
    }

        public void LoadRight()
    {
        int currentIndex = System.Array.IndexOf(scenes, SceneManager.GetActiveScene().name);

        int prevIndex = currentIndex - 1;

        if (prevIndex < 0)
            prevIndex = scenes.Length - 1;

        SceneManager.LoadScene(scenes[prevIndex]);
    }

    
    public void LoadShop()
    {
        Scene_Memory.lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Shop");
    }

    private void ReturnToPreviousScene()
    {
        if (!string.IsNullOrEmpty(Scene_Memory.lastScene))
        {
            SceneManager.LoadScene(Scene_Memory.lastScene);
        }
        else
        {
            SceneManager.LoadScene("NorthWall"); 
        }
    }

}