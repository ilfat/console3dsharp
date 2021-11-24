using System;

namespace RayTracing
{
    public class VecFunctions
    {
        public static float clamp(float value, float min, float max)
        {
            return Math.Max(Math.Min(value, max), min);
        }
        public static double sign(double a)
        {
            if (a > 0)
                return 1;
            if (a < 0)
                return -1;
            else return 0;
        }
        public static double step(double edge, double x)
        {
            return x > edge ? 1 : 0;
        }

        public static float length(vec2 v)
        {
            return (float)Math.Sqrt(v.x * v.x + v.y * v.y);
        }

        public static float length(vec3 v)
        {
            return (float)Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }
        public static vec3 norm(vec3 v)
        {
            return new vec3(v.x / length(v), v.y / length(v), v.z / length(v));
        }
        public static float dot(vec3 a, vec3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        public static vec3 abs(vec3 v)
        {
            return new vec3(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z));
        }
        public static vec3 sign(vec3 v)
        {
            return new vec3((float)sign(v.x), (float)sign(v.y), (float)sign(v.z));
        }
        public static vec3 step(vec3 edge, vec3 v)
        {
            return new vec3((float)step(edge.x, v.x), (float)step(edge.y, v.y), (float)step(edge.z, v.z));
        }
        public static vec3 reflect(vec3 rd, vec3 n)
        {
            return rd - n * (2 * dot(n, rd));
        }

        public static vec3 rotateX(vec3 a, double angle)
        {
            vec3 b = a;
            b.z = (float)(a.z * Math.Cos(angle) - a.y * Math.Sin(angle));
            b.y = (float)(a.z * Math.Sin(angle) + a.y * Math.Cos(angle));
            return b;
        }

        public static vec3 rotateY(vec3 a, double angle)
        {
            vec3 b = a;
            b.x = (float)(a.x * Math.Cos(angle) - a.z * Math.Sin(angle));
            b.z = (float)(a.x * Math.Sin(angle) + a.z * Math.Cos(angle));
            return b;
        }

        public static vec3 rotateZ(vec3 a, double angle)
        {
            vec3 b = a;
            b.x = (float)(a.x * Math.Cos(angle) - a.y * Math.Sin(angle));
            b.y = (float)(a.x * Math.Sin(angle) + a.y * Math.Cos(angle));
            return b;
        }

        public static vec2 sphere(vec3 ro, vec3 rd, float r)
        {
            float b = dot(ro, rd);
            float c = dot(ro, ro) - r * r;
            float h = b * b - c;
            if (h < 0.0) return new vec2(-1.0f);
            h = (float)Math.Sqrt(h);
            return new vec2(-b - h, -b + h);
        }

        public static vec2 box(vec3 ro, vec3 rd, vec3 boxSize, out vec3 outNormal)
        {
            vec3 m = new vec3(1.0f) / rd;
            vec3 n = m * ro;
            vec3 k = abs(m) * boxSize;
            vec3 t1 = -n - k;
            vec3 t2 = -n + k;
            float tN = Math.Max(Math.Max(t1.x, t1.y), t1.z);
            float tF = Math.Min(Math.Min(t2.x, t2.y), t2.z);
            outNormal = new vec3(0);
            if (tN > tF || tF < 0.0) 
                return new vec2(-1.0f);
            vec3 yzx = new vec3(t1.y, t1.z, t1.x);
            vec3 zxy = new vec3(t1.z, t1.x, t1.y);
            outNormal = -sign(rd) * step(yzx, t1) * step(zxy, t1);
            return new vec2(tN, tF);
        }

        public static float plane(vec3 ro, vec3 rd, vec3 p, float w)
        {
            return -(dot(ro, p) + w) / dot(rd, p);
        }
    }
}