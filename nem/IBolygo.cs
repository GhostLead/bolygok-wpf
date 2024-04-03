using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nem
{
    internal interface IBolygo
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        bool Szabad { get; set; }

        double Tavolsag(IBolygo egyik, IBolygo masik);


    }

    public class Bolygo : IBolygo
    {
        public double X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Szabad { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        double IBolygo.Tavolsag(IBolygo egyik, IBolygo masik)
        {
            throw new NotImplementedException();
        }
    }

}
