namespace Yulinti.CharacterControllSuite {
    public struct HorizontalSpeedPlan {
        public readonly float TargetSpeed;
        public readonly float SmoothTime;
        public HorizontalSpeedPlan(float targetSpeed, float smoothTime) {
            TargetSpeed = targetSpeed;
            SmoothTime = smoothTime;
        }
    }
    
    public struct YawPlan {
        public readonly float TargetYawDeg;
        public readonly float SmoothTime;
        public YawPlan(float targetYawDeg, float smoothTime) {
            TargetYawDeg = targetYawDeg;
            SmoothTime = smoothTime;
        }
    }
    
    public struct VerticalSpeedPlan {
        public readonly float TargetSpeed;
        public readonly float SmoothTime;
        public VerticalSpeedPlan(float targetSpeed, float smoothTime) {
            TargetSpeed = targetSpeed;
            SmoothTime = smoothTime;
        }
    }
    
    public struct MovePlan {
        public readonly HorizontalSpeedPlan HorizontalSpeedPlan;
        public readonly YawPlan YawPlan;
        public readonly VerticalSpeedPlan VerticalSpeedPlan;
        public MovePlan(HorizontalSpeedPlan horizontalSpeedPlan, YawPlan yawPlan, VerticalSpeedPlan verticalSpeedPlan) {
            HorizontalSpeedPlan = horizontalSpeedPlan;
            YawPlan = yawPlan;
            VerticalSpeedPlan = verticalSpeedPlan;
        }
    }
}