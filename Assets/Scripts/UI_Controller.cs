using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    private static UI_Controller instance;

    [SerializeField] private Button b_left;
    [SerializeField] private Button b_right;


private void Start()
{
    if (b_left == null)
        b_left = GameObject.Find("b_left")?.GetComponent<Button>();

    if (b_right == null)
        b_right = GameObject.Find("b_right")?.GetComponent<Button>();

    if (b_left != null)
        b_left.onClick.AddListener(LoadLeft);

    if (b_right != null)
        b_right.onClick.AddListener(LoadRight);
}


    public void LoadLeft()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
            nextIndex = 0;

        SceneManager.LoadScene(nextIndex);
    }

    public void LoadRight()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int prev = current - 1;

        if (prev < 0)
            prev = SceneManager.sceneCountInBuildSettings - 1;

        SceneManager.LoadScene(prev);
    }
}