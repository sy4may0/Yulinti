using System;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public static class Mathematica {
        public static float Clamp(float value, float min, float max) {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static int Clamp(int value, int min, int max) {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static float Clamp01(float value) {
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return value;
        }

        public static int Clamp01(int value) {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public static float Lerp(float min, float max, float t) {
            return min + (max - min) * t;
        }

        public static float Lerp01(float min, float max, float t) {
            return Lerp(min, max, Clamp01(t));
        }

        public static float InverseLerp(float min, float max, float v) {
            if (MathF.Abs(max - min) < Numerus.Epsilon) return 0f;
            return (v - min) / (max - min);
        }

        public static float InverseLerp01(float min, float max, float v) {
            if (MathF.Abs(max - min) < Numerus.Epsilon) return 0f;
            return Clamp01((v - min) / (max - min));
        }

        public static float Round(float value) {
            return (float)Math.Round(value);
        }

        public static float Deg2Rad(float deg) {
            return deg * Numerus.Deg2Rad;
        }

        public static float Rad2Deg(float rad) {
            return rad * Numerus.Rad2Deg;
        }

        public static float SmoothStep(
            float x, float min, float max
        ) {
            if (min >= max) {
                return 0f;
            }
            float t = Clamp01((x - min) / (max - min));
            return t * t * (3f - 2f * t);
        }

        public static float Sigmoid(
            float x, float centrum, float praeruptio
        ) {
            return 1f / (1f + MathF.Exp(-praeruptio * (x - centrum)));
        }

        public static float Sigmoid01(
            float x, float centrum, float praeruptio,
            float min, float max
        ) {
            x = Clamp01(x);

            float y = Sigmoid(x, centrum, praeruptio);

            return InverseLerp(min, max, y);
        }

        public static float Gaussian01(
            float x, float min, float max, float epsilon 
        ) {
            x = Clamp01(x);
            min = Clamp01(min);
            max = Clamp01(max);
            if (min >= max) {
                return 0f;
            }
            if (epsilon <= 0f || epsilon > 1f) {
                return 0f;
            }

            float centrum = (min + max) / 2f;
            float h = (max - min) / 2f;
            float sigma = h / MathF.Sqrt(-2f * MathF.Log(epsilon));

            return MathF.Exp(-MathF.Pow(x - centrum, 2f) / (2f * MathF.Pow(sigma, 2f)));
        }

        // 現在値を目標値へ、臨界減衰のばねのように滑らかに近づける。
        // smoothTime は到達までのおよその時間で、小さいほど速く追従する。
        // currentVelocity はフレームをまたいで速度を保持するため、呼び出し側が保持して渡す。
        // 速度は maxSpeed を超えないよう変化量を制限する。
        // 次の値が目標を越えるときは目標値で止め、速度を 0 にする。
        public static float SmoothDamp(
            float current,
            float target,
            ref float currentVelocity,
            float smoothTime,
            float maxSpeed = float.PositiveInfinity,
            float deltaTime = 1.0f/60.0f
        ) {
            smoothTime = MathF.Max(0.0001f, smoothTime);
            float omega = 2.0f / smoothTime;
            float x = omega * deltaTime;

            float exp = 1.0f / (
                1.0f
                + x
                + 0.48f * x * x
                + 0.234f * x * x * x
            );

            float change = current - target;
            float originalTarget = target;

            float maxChange = maxSpeed * smoothTime;
            change = Clamp(change, -maxChange, maxChange);
            target = current - change;

            float temp = 
                (currentVelocity + omega * change) * deltaTime;
            
            currentVelocity =
                (currentVelocity - omega * temp) * exp;

            float result = target + (change + temp) * exp;

            if (
                (originalTarget - current > 0.0f) 
                ==
                (result > originalTarget)
            ) {
                result = originalTarget;
                currentVelocity = 0f;
            }

            return result;
        }

        // 加速度と速度の上限を守りながら、目標地点で速度 0 になるように現在値を進める。
        // 残り距離 x から止まれる最大速度 sqrt(2 * a * x) を求め、
        // 遠いときは maxSpeed、近いときはその停止速度を目標速度にする。
        // velocity はその目標速度へ、1 フレームあたり maxAcceleration * deltaTime 以内で近づく。
        // 次の位置が目標を越えるときは目標値で止め、速度を 0 にする。
        public static float SmoothMove(
            float current,
            float target,
            ref float velocity,
            float maxAcceleration,
            float maxSpeed,
            float deltaTime = 1.0f/60.0f
        ) {
            float distance = target - current;

            if (MathF.Abs(distance) < Numerus.Epsilon) {
                velocity = 0f;
                return target;
            }

            float direction = MathF.Sign(distance);

            // この距離で停止できる最大速度
            // v^2 = 2 * a * x
            float stoppingSpeed = MathF.Sqrt(
                2f * maxAcceleration * MathF.Abs(distance)
            );

            float desiredSpeed = direction * MathF.Min(stoppingSpeed, maxSpeed);

            velocity = MoveTowards(
                velocity,
                desiredSpeed,
                maxAcceleration * deltaTime
            );

            float next = current + velocity * deltaTime;

            // オーバーシュート防止
            if (
                (target - current > 0f && next >= target) ||
                (target - current < 0f && next <= target)
            ) {
                velocity = 0f;
                return target;
            }

            return next;
        }

        // 現在値を目標値へ、1 回の変化量 maxDelta 以内で近づける。
        // 残り差が maxDelta 以下なら目標値そのものを返す。速度の状態は持たない。
        private static float MoveTowards(
            float current,
            float target,
            float maxDelta
        ) {
            float delta = target - current;
            if (MathF.Abs(delta) <= maxDelta) {
                return target;
            }
            return current + Math.Sign(delta) * maxDelta;
        }
    }
}