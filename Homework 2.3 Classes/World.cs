using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Homework_2._3_Classes
{
    internal class World
    {
        public Vector fGrav, fAir, fSpring, fNet;
        public List<Projectile> projectiles;
        public double aG = -9.8;
        public bool airRes;
        public bool springRes;
        public double simTime;
        double C = 0.5;
        public double dt;
        //Ground???

        public World(double time, double dt, List<Projectile> projectiles, bool airRes, bool springRes)
        {
            this.dt = dt;
            simTime = time;
            this.projectiles = projectiles;
            this.airRes = airRes;
            this.springRes = springRes;
        }

        public void CalculateForces(Projectile p) {
            //temporarily adding these to calculate spring force
            double springConst = 8;
            double unstretchedLength = 2;
            double fSpringMag = 0;
            Vector displacement = new Vector(0, 0, 0);
            Vector springPosition = new Vector(0, 0, unstretchedLength); //initial position of spring 


            fGrav = new Vector(
                0 * p.mass,                           //force of gravity in the X direction
                0 * p.mass,                           //force of gravity in the Y direction
                aG * p.mass                           //force of gravity in the Z direction
            );
            if (airRes)
            {
                fAir = new Vector(
                    C * p.v.X * p.v.X * Math.Sign(p.v.X),
                    C * p.v.Y * p.v.Y * Math.Sign(p.v.Y),
                    C * p.v.Z * p.v.Z * Math.Sign(p.v.Z)
                );


                if (springRes && p.p.Magnitude()!=0)
                {
                    //displacement = p.p - springPosition; //magnitude of displacement from spring original position to position vector. -2 because that is initial spring length
                    //fSpring = springConst * -1 * displacement;
                    //Console.WriteLine(p.p.X);
                    fSpring = -1 * springConst * (p.p.Magnitude() - 2) * p.p.UnitVector(p.p);
                    Console.WriteLine(p.p.Magnitude());
                }
                else { fSpring = new Vector(0, 0, 0);}



            }
            else { fAir = new Vector(0, 0, 0); }
            fNet = (fGrav - fAir) + fSpring;
        }

        public void ApplyForces(Projectile p)
        {
            p.a = fNet / p.mass;
        }

        public void Simulate() { //main function
            for(double i = 0; i < simTime; i+=dt)
            {
                for(int x = 1; x < projectiles.Count; x++) //x = 1 JUST FOR TESTING
                {
                    Console.Write(i + "\t");
                    CalculateForces(projectiles[x]);
                    ApplyForces(projectiles[x]);
                    projectiles[x].UpdatePosition(dt);
                    if (x==1) //ONLY FOR TESTING
                    {
                        //projectiles[x].PrintComponents();
                        //Console.WriteLine(i + "\t" + projectiles[x].v);
                    }
                }
            }
        }
    }
}
