using System;

namespace SolidExamples
{
    class InterfaceSeg
    {
        //no client should be forced to depend on methods it does not use

        interface IToy
        {
            void SetPrice(int price);
            void SetColor(string color);
            void Move();
            void Fly();
        }
        public partial class ToyHouse : IToy
        {
            int _myprice;
            string _mycolor;
            public void SetPrice(int price)
            {
                this._myprice = price;
            }
            public void SetColor(string color)
            {
                this._mycolor = color;
            }
            public void Move()
            {
                throw new Exception("not applicable");
            }
            public void Fly()
            {
                throw new Exception("not applicable");
            }
        }

        //in the above example, The ToyHouse client has to implement Fly() and Move() event though they did not apply.
        //splitting down the interfaces we have:

        interface IToyBasic
        {
            void SetPrice(int price);
            void SetColor(string color);
        }
        interface IMovable
        {
            void Move();
        }
        interface IFlyable
        {
            void Fly();
        }

        public class ToyHouseInterfaceSeg : IToyBasic
        {
            int _myPrice;
            string _myColor;

            public void SetPrice(int price)
            {
                _myPrice = price;
            }

            public void SetColor(string color)
            {
                _myColor = color;
            }
        }

        public class ToyPlaneIntSeg : IToyBasic, IMovable, IFlyable
        {
            int _myPrice;
            string _myColor;

            public void SetPrice(int price)
            {
                _myPrice = price;
            }

            public void SetColor(string color)
            {
                _myColor = color;
            }

            public void Move()
            {
                //move
            }

            public void Fly()
            {
                //Fly
            }
        }

    }
}
