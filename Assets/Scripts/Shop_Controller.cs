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
        if (!string.IsNullOrEmpty(SceneMemory.lastScene))
        {
            SceneManager.LoadScene(SceneMemory.lastScene);
        }
        else
        {
            SceneManager.LoadScene("NorthWall"); // fallback
        }
    }
}