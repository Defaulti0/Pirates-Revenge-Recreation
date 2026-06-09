using System.Diagnostics;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class PushGitOnExit
{
    static PushGitOnExit()
    {
        EditorApplication.quitting += OnEditorQuitting;
    }

    private static void OnEditorQuitting()
    {
        // Path to the .bat or .sh script that handles staging, committing, and pushing
        string scriptPath = Application.dataPath.Replace("/Assets", "/auto_git_push.bat"); // or .sh for Mac/Linux

        ProcessStartInfo processInfo = new ProcessStartInfo
        {
            FileName = scriptPath,
            CreateNoWindow = true,
            UseShellExecute = false
        };

        Process.Start(processInfo);
        UnityEngine.Debug.Log("Triggering Git auto-push script before exit...");
    }
}