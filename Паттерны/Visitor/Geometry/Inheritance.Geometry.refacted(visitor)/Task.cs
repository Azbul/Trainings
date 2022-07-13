using System;

namespace Inheritance.Geometry
{
	public abstract class Body
	{
        public abstract double GetVolume();
        public abstract void Accept(IVisitor visitor);
	}

	public class Ball : Body
	{
		public double Radius { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitBall(this);
        }

        public override double GetVolume()
        {
            return 4.0 * Math.PI * Math.Pow(Radius, 3) / 3;
        }
    }

	public class Cube : Body
	{
		public double Size { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCube(this);
        }

        public override double GetVolume()
        {
            return Math.Pow(Size, 3);
        }
    }

	public class Cylinder : Body
	{
		public double Height { get; set; }
		public double Radius { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCylinder(this);
        }

        public override double GetVolume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }
	}

    public interface IVisitor
    {
        void VisitBall(Ball ball);
        void VisitCube(Cube cube);
        void VisitCylinder(Cylinder cylinder);
    }

    public class SurfaceAreaVisitor : IVisitor
	{
		public double SurfaceArea { get; private set; }

        public void VisitBall(Ball ball)
        {
            SurfaceArea = 4.0 * Math.PI * Math.Pow(ball.Radius, 2);
        }

        public void VisitCube(Cube cube)
        {
            SurfaceArea = Math.Pow(cube.Size, 2) * 6.0;
        }

        public void VisitCylinder(Cylinder cylinder)
        {
            SurfaceArea = 2.0 * Math.PI * cylinder.Radius * (cylinder.Radius + cylinder.Height);
        }
    }

	public class DimensionsVisitor : IVisitor
	{
		public Dimensions Dimensions { get; private set; }

        public void VisitBall(Ball ball)
        {
            Dimensions = new Dimensions(ball.Radius * 2.0, ball.Radius * 2.0);
        }

        public void VisitCube(Cube cube)
        {
            Dimensions = new Dimensions(cube.Size, cube.Size);
        }

        public void VisitCylinder(Cylinder cylinder)
        {
            Dimensions = new Dimensions(cylinder.Radius * 2.0, cylinder.Height);
        }
    }
}
