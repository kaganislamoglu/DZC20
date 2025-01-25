using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public List<itemType> inventoryList;
    public int playerReach;
    [SerializeField] Camera cam;
    [SerializeField] GameObject pressToPickup_gameobject;
    [SerializeField] Image[] inventorySlotImage = new Image[9];
    [SerializeField] Image[] inventoryBackgroundImage = new Image[9];
    [SerializeField] Sprite SlotImage;
    [SerializeField] GameObject throwObject_gameobject;
    [SerializeField] KeyCode throwItemKey;
    [SerializeField] KeyCode pickUpItemKey;

    public int selectedItem = 0;

    [Space(10)]

    [Header("Gameobjects")]
    [SerializeField] GameObject donutpink_item;
    [SerializeField] GameObject donutbrown_item;
    [SerializeField] GameObject burger_item;

    [Header("Item prefabs")]
    [SerializeField] GameObject donutpink_prefab;
    [SerializeField] GameObject donutbrown_prefab;
    [SerializeField] GameObject burger_prefab;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>();
    private Dictionary<itemType, GameObject> itemInstantiate = new Dictionary<itemType, GameObject>();

    void Start()
    {
        itemSetActive.Add(itemType.DonutPink, donutpink_item);
        itemSetActive.Add(itemType.DonutBrown, donutbrown_item);
        itemSetActive.Add(itemType.Burger, burger_item);

        itemInstantiate.Add(itemType.DonutPink, donutpink_prefab);
        itemInstantiate.Add(itemType.DonutBrown, donutbrown_prefab);
        itemInstantiate.Add(itemType.Burger, burger_prefab);

        NewItemSelected();
    }

    void Update()
    {
        if (Input.GetKeyDown(throwItemKey) && inventoryList.Count > 0)
        {
            Instantiate(itemInstantiate[inventoryList[selectedItem]], throwObject_gameobject.transform.position, new Quaternion());
            inventoryList.RemoveAt(selectedItem);

            if (inventoryList.Count == 0)
            {
                selectedItem = 0; // Reset selected item if inventory is empty
            }
            else if (selectedItem != 0)
            {
                selectedItem -= 1; // Move selection back if needed
            }

            NewItemSelected();
        }

        for (int i = 0; i < inventorySlotImage.Length; i++)
        {
            if (i < inventoryList.Count)
            {
                inventorySlotImage[i].sprite = itemSetActive[inventoryList[i]].GetComponent<ItemPickable>().itemScriptableObject.item_sprite;
            }
            else
            {
                inventorySlotImage[i].sprite = SlotImage;
            }
        }

        int a = 0;
        foreach (Image image in inventoryBackgroundImage)
        {
            if (a == selectedItem)
            {
                image.color = new Color32(145, 255, 126, 255);
            }
            else
            {
                image.color = new Color32(219, 219, 219, 255);
            }
            a++;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, playerReach))
        {
            IPickable item = hitInfo.collider.GetComponent<IPickable>();
            if (item != null)
            {
                pressToPickup_gameobject.SetActive(true);
                if (Input.GetKey(pickUpItemKey))
                {
                    inventoryList.Add(hitInfo.collider.GetComponent<ItemPickable>().itemScriptableObject.item_type);
                    item.PickItem();
                }
            }
            else
            {
                pressToPickup_gameobject.SetActive(false);
            }
        }
        else
        {
            pressToPickup_gameobject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0)
        {
            selectedItem = 0;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1)
        {
            selectedItem = 1;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 2)
        {
            selectedItem = 2;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 3)
        {
            selectedItem = 3;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryList.Count > 4)
        {
            selectedItem = 4;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && inventoryList.Count > 5)
        {
            selectedItem = 5;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) && inventoryList.Count > 6)
        {
            selectedItem = 6;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) && inventoryList.Count > 7)
        {
            selectedItem = 7;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) && inventoryList.Count > 8)
        {
            selectedItem = 8;
            NewItemSelected();
        }
    }

    private void NewItemSelected()
    {
        // Deactivate all item GameObjects
        foreach (var item in itemSetActive.Values)
        {
            item.SetActive(false);
        }

        // If inventory has items, activate the selected one
        if (inventoryList.Count > 0)
        {
            GameObject selectedItemGameobject = itemSetActive[inventoryList[selectedItem]];
            selectedItemGameobject.SetActive(true);
        }
    }
}

public interface IPickable
{
    void PickItem();
}
