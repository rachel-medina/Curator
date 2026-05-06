using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop_Controller : MonoBehaviour
{
    [SerializeField] private Button b_return;

    private void Start()
    {
        if (b_return == null)
            b_return = GetComponentInChildren<Button>();

        if (b_return != null)
            b_return.onClick.AddListener(ReturnToPreviousScene);
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