namespace SolidExamples
{
    class OpenClosed
    {
        //open to extension
        //closed to modification

        class Rectangle
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }

        class Area
        {
            public double CalculateArea(Rectangle[] rectangles)
            {
                double total = 0.0;

                foreach (var rectangle in rectangles)
                {
                    total += (rectangle.Width * rectangle.Height);
                }

                return total;
            }
        }

        //problem above is if the shape changes or we want to add shapes, the "Area" class needs modifying

        abstract class Shape
        {
            public abstract double Area();
        }

        class RectangleOpen : Shape
        {
            double Width { get; set; }
            double Height { get; set; }

            public override double Area()
            {
                return Height + Width;
            }
        }


    }
}
