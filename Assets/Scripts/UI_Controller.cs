using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    // GALLERYEVALUATION UI
    [SerializeField] private GameObject confirmationPopup;
    [SerializeField] private Button b_evaluation;
    [SerializeField] private Button b_yes;
    [SerializeField] private Button b_no;

    // INVENTORY UI
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

    }

    private void Start()
    {
        //EVALUATION CONFIRMATION POPUP
        confirmationPopup.SetActive(false);
        b_evaluation.onClick.AddListener(() => ShowPopup(PopupType.Confirmation));
        b_yes.onClick.AddListener(ConfirmAction);
        b_no.onClick.AddListener(HidePopup);

        //INVENTORY POPUP
        inventoryPopup.SetActive(false);
        b_inventory.onClick.AddListener(() => ShowPopup(PopupType.Inventory));
        b_close.onClick.AddListener(HidePopup);

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