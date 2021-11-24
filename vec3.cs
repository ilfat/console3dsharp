using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracing
{
	public struct vec3
	{
		public float x, y, z;

		public vec3(float value)
		{
			x = y = z = value;
		}

		public vec3(float _x, vec2 v)
		{
			x = _x;
			y = v.x;
			z = v.y;
		}

		public vec3(float _x, float _y, float _z)
        {
			x = _x;
			y = _y;
			z = _z;
        }

		public static vec3 operator + (vec3 v1, vec3 v2) 
		{
			return new vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
		}
		public static vec3 operator - (vec3 v1, vec3 v2)
		{
			return new vec3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
		}
		public static vec3 operator * (vec3 v1, vec3 v2)
		{
			return new vec3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
		}
		public static vec3 operator / (vec3 v1, vec3 v2)
		{
			return new vec3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
		}
		public static vec3 operator *(vec3 v1, float v2)
		{
			return new vec3(v1.x * v2, v1.y * v2, v1.z * v2);
		}
		public static vec3 operator - (vec3 v1) 
		{
			return new vec3(-v1.x, -v1.y, -v1.z); 
		}
	}
}
