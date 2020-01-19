using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class DebugTools : EditorWindow
{
    [MenuItem("Window/Debug Tools")]
    static void Init()
    {
        DebugTools window = (DebugTools)EditorWindow.GetWindow(typeof(DebugTools));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("MainMenu") && EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity", OpenSceneMode.Single);
        if (GUILayout.Button("MainGame") && EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene("Assets/Scenes/MainGame.unity", OpenSceneMode.Single);

        EditorGUILayout.EndHorizontal();
    }
}
