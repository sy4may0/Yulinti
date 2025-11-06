using UnityEngine;

namespace Yulinti.CharacterControllSuite
{
    public static class FukaSkinConstraintUtils
    {
        public static float GetThreePointAngle(
            Transform anglePoint,
            Transform parentPoint,
            Transform childPoint
        )
        {

            Vector3 v1 = (parentPoint.position - anglePoint.position).normalized;
            Vector3 v2 = (childPoint.position - anglePoint.position).normalized;

            float angle = Vector3.Angle(v1, v2);

            return angle;
        }

        public static float AngleToWeight(float angleDeg, float minDeg, float maxDeg)
        {
            float clamped = Mathf.Clamp(angleDeg, minDeg, maxDeg);
            float t = Mathf.InverseLerp(minDeg, maxDeg, clamped);
            return Mathf.Clamp(t * 100f, 0f, 100f);
        }

        public static float AngleToWeightReverse(float angleDeg, float minDeg, float maxDeg)
        {
            return 100f - AngleToWeight(angleDeg, minDeg, maxDeg);
        }

        public static float AngleToTriWeight(float angleDeg, float minDeg, float peakDeg, float maxDeg)
        {
            if (!(minDeg < peakDeg && peakDeg < maxDeg)) return 0f;

            float rise = Mathf.InverseLerp(minDeg, peakDeg, angleDeg);
            float fall = 1f - Mathf.InverseLerp(peakDeg, maxDeg, angleDeg);

            float tri01 = Mathf.Clamp01(Mathf.Min(rise, fall));

            return Mathf.Clamp(tri01 * 100f, 0f, 100f);
        }
    }

}