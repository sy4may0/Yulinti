using UnityEngine;

public sealed class FrameContext {
    private float _deltaTime;
    private float _fixedDeltaTime;

    public float DeltaTime => _deltaTime;
    public float FixedDeltaTime => _fixedDeltaTime;

    public FrameContext() {
        DeltaTime = 0f;
        FixedDeltaTime = 0f;
    }

    public void Tick() {
        DeltaTime = Time.deltaTime;
    }

    public void FixedTick() {
        FixedDeltaTime = Time.fixedDeltaTime;
    }
}
