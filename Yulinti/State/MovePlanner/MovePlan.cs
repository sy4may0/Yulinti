public struct HorizontalSpeedPlan {
    public readonly float TargetSpeed;
    public readonly float SmoothTime;
}

public struct YawPlan {
    public readonly float TargetYawDeg;
    public readonly float SmoothTime;
}

public struct VerticalSpeedPlan {
    public readonly float TargetSpeed;
    public readonly float SmoothTime;
}

public struct MovePlan {
    public readonly HorizontalSpeedPlan HorizontalSpeedPlan;
    public readonly YawPlan YawPlan;
    public readonly VerticalSpeedPlan VerticalSpeedPlan;
}