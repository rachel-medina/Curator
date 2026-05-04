using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_Controller : MonoBehaviour
{
    //private static UI_Controller instance;
    // MOVEMENT REFERENCES
    [SerializeField] private string[] scenes;
    [SerializeField] private Button b_left;
    [SerializeField] private Button b_right;

    [SerializeField] private Button b_shop;
    

    // GALLERYEVALUATION REFERENCES
    [SerializeField] private GameObject confirmationPopup;
    [SerializeField] private Button b_evaluation;
    [SerializeField] private Button b_yes;
    [SerializeField] private Button b_no;

    // INVENTORY REFERENCES
    [SerializeField] private GameObject inventoryPopup;
    [SerializeField] private Button b_inventory;
    [SerializeField] private Button b_close;



    public enum PopupType
    {
        Confirmation,
        Inventory
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

    private void Start()
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

        //INVENTORY
        if (inventoryPopup == null)
            inventoryPopup = GameObject.Find("InventoryPopup");

        if (inventoryPopup != null)
            inventoryPopup.SetActive(false);

        if (b_inventory == null)
            b_inventory = GameObject.Find("b_inventory")?.GetComponent<Button>();

        if (b_inventory != null)
            b_inventory.onClick.AddListener(() => ShowPopup(PopupType.Inventory));

        if (b_close == null)
            b_close = GameObject.Find("b_close")?.GetComponent<Button>();

        if (b_close != null)
            b_close.onClick.AddListener(HidePopup);



        //EVALUATION
        if (confirmationPopup == null)
            confirmationPopup = GameObject.Find("ConfirmationPopup");

        if (confirmationPopup != null)
            confirmationPopup.SetActive(false);

        if (b_evaluation == null)
            b_evaluation = GameObject.Find("b_evaluation")?.GetComponent<Button>();

        if (b_evaluation != null)
            b_evaluation.onClick.AddListener(() => ShowPopup(PopupType.Confirmation));
            //b_evaluation.onClick.AddListener(ShowPopup(PopupType.Confirmation));

        b_yes.onClick.AddListener(ConfirmAction);
        b_no.onClick.AddListener(HidePopup);

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
        SceneMemory.lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Shop");
    }


    private void ShowPopup(PopupType type)
    {
        confirmationPopup.SetActive(false);
        inventoryPopup.SetActive(false);

        if (type == PopupType.Confirmation)
            confirmationPopup.SetActive(true);
        else if (type == PopupType.Inventory)
            inventoryPopup.SetActive(true);
    }

    private void HidePopup()
    {
        confirmationPopup.SetActive(false);
        inventoryPopup.SetActive(false);
    }

    private void ConfirmAction()
    {
        confirmationPopup.SetActive(false);

        SceneManager.LoadScene("GalleryEvaluation"); 
    }
}