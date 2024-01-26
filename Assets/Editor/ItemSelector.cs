using UnityEditor;
using UnityEngine;

public class ItemSelector : EditorWindow
{
    private GameObject selectedObject;
    private Object[] assetItems;
    private ItemPickUp item;
    private bool isEditoMode = false;
    private Color backgroundColor = Color.gray;


    [MenuItem("Tppls/Item Selector")]
    public static void ShowWindow()
    {
        ItemSelector window = GetWindow<ItemSelector>("Item Selector");
        window.minSize = new Vector2(250, 300);
        window.maxSize = new Vector2(400, 600);

        window.Show();


    }

    void OnGUI()
    {

        bool isDocked = docked;

        if (!isDocked)
        {
            EditorGUILayout.BeginVertical("Box", GUILayout.MinWidth(240), GUILayout.MinHeight(400));

            Handles.DrawSolidRectangleWithOutline(new Rect(0, 0, position.width, position.height), backgroundColor, Color.clear);

            EditorGUILayout.EndVertical();
        }


        EditorGUILayout.BeginVertical("Box");

        selectedObject = Selection.activeGameObject;




        EditorGUILayout.LabelField("Selected Item ", EditorStyles.boldLabel);

        if (selectedObject != null && EditorWindow.focusedWindow)
        {
            EditorGUILayout.HelpBox("Select object to show item data", MessageType.Info);
        }
        else if (selectedObject != null && selectedObject.GetComponent<ItemPickUp>() == null)
        {
            EditorGUILayout.HelpBox("Select object to show item data", MessageType.Info);
        }
        if (selectedObject == null)
        {
            EditorGUILayout.HelpBox("Select object to show item data", MessageType.Info);
        }



        if (selectedObject != null)
        {
            isEditoMode = EditorGUILayout.Toggle("Editing Mode", isEditoMode);

            ItemPickUp itempickup = selectedObject.GetComponent<ItemPickUp>();

            if (isEditoMode)
            {
                if (itempickup != null)
                {

                    EditorGUILayout.ObjectField("Selected object", selectedObject, typeof(ItemPickUp), true);

                    ItemCreator _item = itempickup.item;
                    if (_item != null)
                    {

                        ShowFields(_item, itempickup);
                    }
                }
            }
            else
            {
                if (itempickup != null)
                {

                    EditorGUI.BeginDisabledGroup(!isEditoMode);
                    EditorGUILayout.ObjectField("Selected object", selectedObject, typeof(ItemPickUp), true); ;

                    ItemCreator _item = itempickup.item;
                    if (_item != null)
                    {
                        ShowFields(_item, itempickup);
                        EditorGUI.EndDisabledGroup();
                    }


                }
            }


        }
        else if (selectedObject == null || selectedObject.GetComponent<ItemCreator>() == null)
        {

            isEditoMode = EditorGUILayout.Toggle("Editing Mode", false);
            EditorGUI.EndDisabledGroup();
        }



        EditorGUILayout.EndVertical();
        Repaint();

    }

    void ShowFields(ItemCreator _item, ItemPickUp itempickup)
    {

        EditorGUILayout.TextField("Item Name", _item.itemName);
        _item.icon = EditorGUILayout.ObjectField("Item Image", _item.icon, typeof(Sprite), true) as Sprite;
        EditorGUILayout.TextField("Item Amount", itempickup.amout.ToString());
        EditorGUILayout.TextField("Item value", _item.value.ToString());
    }


}
