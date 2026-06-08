using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class CompileOnPlay
{
    static CompileOnPlay()
    {
        // Hook into Unity's state change event (e.g., pressing the Play button)
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        // Triggered exactly when you press Play, right before the scene loads
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            // Force Unity to scan for modified scripts and compile them
            AssetDatabase.Refresh();
        }
    }
}