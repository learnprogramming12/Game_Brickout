using NAudio.SoundFont;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assignment2Prj.CollisionDetection;
using static System.Windows.Forms.LinkLabel;

namespace Assignment2Prj
{
    //This detection only applied to detect collision based on the collision standards in this program.
    internal class CollisionDetection
    {
        public class Circle
        {
            public int iR;
            public int iXCenter;
            public int iYCenter;
        }
        public static bool DetectBallVSPaddle(Circle circle, Rectangle rect)
        {
            if(circle == null) return false;
            if (circle.iXCenter >= rect.X && circle.iXCenter <= rect.Right && circle.iYCenter + circle.iR >= rect.Y && (circle.iYCenter + circle.iR < rect.Bottom))
                return true;
            return false;
        }
        public static Circle GetCircleFromSquare(Rectangle rect)
        {
            if (rect == null)
                return null;
            Circle circle = new Circle();
            circle.iR = Math.Min(rect.Width, rect.Height) / 2;
            circle.iXCenter = rect.X + circle.iR;
            circle.iYCenter = rect.Y + circle.iR;
            return circle;
        }
        public enum enumCollisionPos
        {
            PosLeftRight,
            PosUpDown,
        }
        public class CollisionInfo
        {
            public bool bCollision;
            public int iXReferencePoint;
            public int iYReferencePoint;
        }
        //The part about judging Circle and Rectangle collison comes from internet.
        public static CollisionInfo CheckCircleRectangleIntersection(Rectangle rectangle, Point circleCenter, int circleRadius)
        {
            // Calculate the closest point on the rectangle to the circle center
            int closestX = Math.Max(rectangle.Left, Math.Min(circleCenter.X, rectangle.Right));
            int closestY = Math.Max(rectangle.Top, Math.Min(circleCenter.Y, rectangle.Bottom));

            int distanceX = circleCenter.X - closestX;
            int distanceY = circleCenter.Y - closestY;
            double distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));

            CollisionInfo collisionInfo = new CollisionInfo();
            collisionInfo.bCollision = false;
            if(distance <= circleRadius)
            {
                collisionInfo.bCollision = true;
                collisionInfo.iXReferencePoint = closestX;
                collisionInfo.iYReferencePoint = closestY;
            }
            return collisionInfo;
        }

        //This function is from Internet. I use it because I want to know which side of rectangular the ball enters so I can know the bounce angle,
        //change horizontal or vertical direction.
        public static bool CalculateXIntersection(PointF p1, PointF p2, PointF p3, PointF p4, out float xIntersection)
        {
            // Calculate the slopes and y-intercepts of the lines representing the line segments
            float m1 = (p2.Y - p1.Y) / (p2.X - p1.X);
            float b1 = p1.Y - m1 * p1.X;

            float m2 = (p4.Y - p3.Y) / (p4.X - p3.X);
            float b2 = p3.Y - m2 * p3.X;

            // Check if the lines are parallel
            if (Math.Abs(m1 - m2) < float.Epsilon)
            {
                xIntersection = float.NaN;
                return false;
            }

            // Calculate the x-coordinate of the intersection point using the line equations
            float x = (b2 - b1) / (m1 - m2);

            // Check if the x-coordinate falls within the bounds of both line segments
            if (x >= Math.Min(p1.X, p2.X) && x <= Math.Max(p1.X, p2.X) && x >= Math.Min(p3.X, p4.X) && x <= Math.Max(p3.X, p4.X))
            {
                xIntersection = x;
                return true;
            }

            xIntersection = float.NaN;
            return false;
        }
    }
}
