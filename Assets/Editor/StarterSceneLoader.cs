using UnityEditor.SceneManagement;
using UnityEditor;
using System;

[InitializeOnLoad]
public static class StarterSceneLoader
{
    static StarterSceneLoader(){
        EditorApplication.playModeStateChanged += LoadStartupScene;
    }

    private static void LoadStartupScene(PlayModeStateChange state)
    {
        if(state == PlayModeStateChange.EnteredPlayMode){
            if(EditorSceneManager.GetActiveScene().buildIndex != 0){
                EditorSceneManager.LoadScene(0);
            }
        }
        if(state == PlayModeStateChange.ExitingPlayMode){
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }
    }
}
