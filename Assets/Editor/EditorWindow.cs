using UnityEngine;
using UnityEditor;

/// <summary>
/// スクロールするだけのウィンドウ
/// </summary>
public class ScrollWindow : EditorWindow
{

    //スクロール位置
    private Vector2 _scrollPosition = Vector2.zero;

    //=================================================================================
    //初期化
    //=================================================================================

    //メニューからウィンドウを表示
    [MenuItem("Tools/Open/Scroll Window")]
    public static void Open()
    {
        GetWindow(typeof(ScrollWindow));
    }

    //=================================================================================
    //表示するGUIの設定
    //=================================================================================

    private void OnGUI()
    {
        //描画範囲が足りなければスクロール出来るように
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
        Debug.Log(_scrollPosition.x.ToString("F2") + ", " + _scrollPosition.y.ToString("F2"));

        //テキトウにUI表示
        for (int i = 0; i < 20; i++)
        {
            GUILayout.Button("特に意味のないボタン" + i.ToString(), GUILayout.Width(300));
        }

        //スクロール箇所終了
        EditorGUILayout.EndScrollView();
    }

}