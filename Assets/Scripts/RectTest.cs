using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class RectTest : MonoBehaviour
{
    public bool Value;
    public RectTransform Target;

    [ContextMenu("Toggle Object")]
    public void ToggleObject()
    {
        Target.ToggleUIObject(Value);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RunTest();
    }

    [ContextMenu("Run Tests")]
    public void RunTest()
    {
        Debug.Log("Starting tests");
        Profiler.BeginSample("Test");
        SpawnAndToggle(1);
        SpawnAndToggle(10);
        SpawnAndToggle(100);
        SpawnAndToggle(1000);
        Profiler.EndSample();
    }

    public void SpawnAndToggle(int amount) 
    {
        Profiler.BeginSample($"Spawning {amount}");
        List<RectTransform> lifebarsToActive = LifeBarSpawner.Instance.SpawnLifeBars(amount);
        Profiler.EndSample();


        Profiler.BeginSample($"Simple Toggle {amount}");

        Profiler.BeginSample($"Simple Toggle - Desactivate {amount}");
        foreach (RectTransform lifebar in lifebarsToActive)
            lifebar.gameObject.SetActive(false);
        Profiler.EndSample();

        Profiler.BeginSample($"Simple Toggle - Activate {amount}");
        foreach (RectTransform lifebar in lifebarsToActive)
            lifebar.gameObject.SetActive(true);
        Profiler.EndSample();

        Profiler.EndSample();


        Profiler.BeginSample($"New Toggle {amount}");
        Profiler.BeginSample($"New Toggle - Desactivate {amount}");
        foreach (RectTransform lifebar in lifebarsToActive)
            lifebar.ToggleUIObject(false);
        Profiler.EndSample();

        Profiler.BeginSample($"New Toggle - Activate {amount}");
        foreach (RectTransform lifebar in lifebarsToActive)
            lifebar.ToggleUIObject(true);
        Profiler.EndSample();

        Profiler.EndSample();
    }
}
