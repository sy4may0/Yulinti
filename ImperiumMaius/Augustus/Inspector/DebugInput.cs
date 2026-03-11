using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDisableTracer : MonoBehaviour
{
    [SerializeField] private InputActionReference move; // あなたのMoveをここに刺す

    void OnEnable()
    {
        InputSystem.onActionChange += OnActionChange;
    }

    void OnDisable()
    {
        InputSystem.onActionChange -= OnActionChange;
    }

    void OnActionChange(object obj, InputActionChange change)
    {
        UnityEngine.Debug.Log($"OnActionChange: {change}");
        if (change != InputActionChange.ActionDisabled) return;

        var a = obj as InputAction;
        if (a == null) return;

        // Moveだけ追跡（他も見たいなら条件外す）
        if (move != null && a.id != move.action.id) return;

        UnityEngine.Debug.Log(
            $"[InputDisableTracer] {a.name} disabled. frame={Time.frameCount}\n" +
            new StackTrace(true).ToString()
        );
    }
}