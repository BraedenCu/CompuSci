using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Homework_2._3_Classes
{
    internal class Projectile
    {
        public double mass;
        public Vector p;
        public Vector v;
        public Vector a;

        public Projectile(double mass, Vector initialPosition, Vector initialVelocity, Vector initialAcceleration)
        {
            this.mass = mass;
            p = initialPosition;
            v = initialVelocity;
            a = initialAcceleration;
        }
        /*
        public void UpdateAcceleration(Vector Acceleration)
        {
            a = Acceleration;
        }
        */
        public void UpdateVelocity(double Dt)
        {
            v += (a * Dt);
            Console.WriteLine(v);
        }
        public void UpdatePosition(double Dt)
        {
            UpdateVelocity(Dt);
            p += v * Dt;
        }

        public void PrintComponents()
        {
            Console.WriteLine(p);
        }

    }
}
