using UnityEngine;

public sealed class FrameContext {
    private float _deltaTime;
    private float _fixedDeltaTime;

    public float DeltaTime => _deltaTime;
    public float FixedDeltaTime => _fixedDeltaTime;

    public FrameContext() {
        _deltaTime = 0f;
        _fixedDeltaTime = 0f;
    }

    public void Tick() {
        _deltaTime = Time.deltaTime;
    }

    public void FixedTick() {
        _fixedDeltaTime = Time.fixedDeltaTime;
    }
}
