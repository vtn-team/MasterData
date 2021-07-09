using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(CardList)), CanEditMultipleObjects]
public class CardListChecker : Editor
{
    CardList _list;

    /// <summary>
    /// InspectorのGUIを更新
    /// </summary>
    public override void OnInspectorGUI()
    {
        _list = target as CardList;

        //更新ボタンを表示
        if (GUILayout.Button("Idを採番する"))
        {
            int id = 1;
            foreach (var d in _list.List)
            {
                d.SetId(id++);
            }
            // 保存
            EditorUtility.SetDirty(_list);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        //元のInspector部分を表示
        base.OnInspectorGUI();
    }
}