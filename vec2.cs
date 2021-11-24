namespace RayTracing
{
    public struct vec2
	{
		public float x, y;

		public vec2(float value)
		{
			x = y = value;
		}
		public vec2(float _x, float _y)
        {
			x = _x;
			y = _y;
        }

		public static vec2 operator + (vec2 v1, vec2 v2) 
		{
			return new vec2(v1.x + v2.x, v1.y + v2.y);
		}
		public static vec2 operator - (vec2 v1, vec2 v2)
		{
			return new vec2(v1.x - v2.x, v1.y - v2.y);
		}
		public static vec2 operator * (vec2 v1, vec2 v2)
		{
			return new vec2(v1.x * v2.x, v1.y * v2.y);
		}
		public static vec2 operator / (vec2 v1, vec2 v2)
		{
			return new vec2(v1.x / v2.x, v1.y / v2.y);
		}
		public static vec2 operator *(vec2 v1, float v2)
		{
			return new vec2(v1.x * v2, v1.y * v2);
		}
		public static vec2 operator -(vec2 v1, float v2)
		{
			return new vec2(v1.x - v2, v1.y - v2);
		}
	}
}
