/*  Description: Allows attachement to a MonoBehaviour for easy access as a Singleton
 *  Brogrammer: Vast
 */

using UnityEngine;

/// <summary>Extend with Class Name to automatically create a Singleton</summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : Component {
    private static bool isQuitting;
    private static T instance = null;
    public static T Instance {
        get {
            if (instance == null && !isQuitting) {
                Debug.Log($"Creating instance of the singleton {typeof(T)}");
                FindOrCreateInstance();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    /// <summary>Looks for an existing instance, if not found creates one. If multiple are found, reports error.</summary>
    private static void FindOrCreateInstance() {
        T[] instanceArray = FindObjectsOfType<T>();
        if (instanceArray.Length == 0) {
            instance = new GameObject(typeof(T).Name).AddComponent<T>();
        } else if (instanceArray.Length == 1) {
            instance = instanceArray[0];
        } else if (instanceArray.Length > 1) {
            Debug.LogError($"<color=yellow>Multiple instances of the singleton [{typeof(T).Name}] exists.</color>");
            Debug.Break();
        }
        DontDestroyOnLoad(instance);
    }
}