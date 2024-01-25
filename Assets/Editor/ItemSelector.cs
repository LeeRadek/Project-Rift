using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
using System.Configuration;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;

public class ItemSelector : EditorWindow
{
    private GameObject selectedObject;
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


        EditorGUILayout.BeginVertical("Box", GUILayout.MinWidth(300), GUILayout.MinHeight(400));

        

        EditorGUILayout.LabelField("Selected Item ", EditorStyles.boldLabel);

        if(selectedObject == null)
        {
            EditorGUILayout.HelpBox("Select object to show item stats", MessageType.Info);
        }

        selectedObject = Selection.activeGameObject;
        if(selectedObject != null)
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
                        
                        EditorGUILayout.TextField("Item Name", _item.itemName);

                        _item.icon = EditorGUILayout.ObjectField("Item Image", _item.icon, typeof(Sprite), true) as Sprite;

                        EditorGUILayout.TextField("Item Amount", itempickup.amout.ToString());
                        EditorGUILayout.TextField("Item value", _item.value.ToString());
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

                        EditorGUI.BeginDisabledGroup(!isEditoMode);
                        EditorGUILayout.TextField("Item Name", _item.itemName);

                        EditorGUI.BeginDisabledGroup(!isEditoMode);
                        _item.icon = EditorGUILayout.ObjectField("Item Image", _item.icon, typeof(Sprite), true) as Sprite;

                        EditorGUI.BeginDisabledGroup(!isEditoMode);
                        EditorGUILayout.TextField("Item Amount", itempickup.amout.ToString());

                        EditorGUI.BeginDisabledGroup(!isEditoMode);
                        EditorGUILayout.TextField("Item value", _item.value.ToString());
                    }
                    
                    
                }
            }

            

        }


        EditorGUILayout.EndVertical();
        Repaint();
        
    }


}
