using System.Linq;
using UnityEngine;

public static class GameObjectExtensions {
    public static T GetSafeComponent<T>(this GameObject obj) where T : MonoBehaviour {
        var component = obj.GetComponent<T>();

        if (component == null) {
            Debug.LogError("Expected to find component of type " + typeof(T) + " but found none", obj);
        }

        return component;
    }

    public static T GetInterfaceComponent<T>(this GameObject obj) where T : class {
        return obj.GetComponent(typeof(T)) as T;
    }

    public static T[] GetInterfaceComponents<T>(this GameObject obj) where T : class {
        return obj.GetComponents(typeof(T)).Select(c => c as T).ToArray();
    }
}
