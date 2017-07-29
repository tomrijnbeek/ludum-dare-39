using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MonoBehaviourExtensions {
    public delegate void Task(float time);

    public static void Invoke(this MonoBehaviour behaviour, Task task, float time) {
        behaviour.Invoke(task.Method.Name, time);
    }

    /// <summary>
    /// Gets the component that implements an interface I.
    /// </summary>
    /// <returns>The component implementing I.</returns>
    /// <typeparam name="T">The interface that should be implemented by the component.</typeparam>
    public static T GetInterfaceComponent<T>(this MonoBehaviour behaviour) where T : class {
        return behaviour.GetComponent(typeof(T)) as T;
    }

    /// <summary>
    /// Finds all objects with a component that implements a certain interface I.
    /// </summary>
    /// <returns>The objects of with a component implementing interface I.</returns>
    /// <typeparam name="T">The interface that should be implemented by the components.</typeparam>
    public static List<T> FindObjectsOfInterface<T>() where T : class {
        return Object.FindObjectsOfType<MonoBehaviour>()
                .Select(behaviour => behaviour.GetComponent(typeof(T)))
                .OfType<T>()
                .ToList();
    }
}
