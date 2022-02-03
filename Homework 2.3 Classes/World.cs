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
        public Vector ground = new Vector(0, 0, 0);
        public Vector aG = new Vector(0, 0, -9.8); //acceleration due to gravity
        public bool airRes, springRes;
        public double simTime, dt;
        public double springConst, C, unstretchedLength;
        public double finalSt; //final time when spring speed = 1m/s
        
        //default constructor
        public World(double time, double dt, List<Projectile> projectiles, bool airRes, bool springRes)
        {
            this.dt = dt;
            simTime = time;
            this.projectiles = projectiles;
            this.airRes = airRes;
            this.springRes = springRes;
        }
        //constructor for air resistence values (will only run if they are passed)
        public World(double time, double dt, List<Projectile> projectiles, bool airRes, bool springRes, double C, double unstretchedLength, double springConst)
        {
            this.dt = dt;
            simTime = time;
            this.projectiles = projectiles;
            this.airRes = airRes;
            this.springRes = springRes;
            this.C = C;
            this.unstretchedLength = unstretchedLength; 
            this.springConst = springConst;
        }

        public void CalculateForces(Projectile p) {
            fGrav = aG * p.mass;
            if (airRes)
            {
                fAir = new Vector(
                    C * p.v.X * p.v.X * Math.Sign(p.v.X),
                    C * p.v.Y * p.v.Y * Math.Sign(p.v.Y),
                    C * p.v.Z * p.v.Z * Math.Sign(p.v.Z)
                );
                if (springRes && p.p.Magnitude()!=0)
                {
                    fSpring = -1 * springConst * (p.p.Magnitude() - unstretchedLength) * p.p.UnitVector(p.p);
                    //Console.WriteLine(p.p.Magnitude());
                }
                else { 
                    fSpring = new Vector(0, 0, 0);
                }
            }
            else { 
                fAir = new Vector(0, 0, 0); 
            }
            fNet = (fGrav - fAir) + fSpring;
        }

        public void ApplyForces(Projectile p)
        {
            p.a = fNet / p.mass;
        }

        public void Simulate() { //main function
            for(double i = 0; i < simTime ; i+=dt)
            {
                for(int x = 0; x < projectiles.Count; x++)
                {
                    CalculateForces(projectiles[x]);
                    ApplyForces(projectiles[x]);
                    projectiles[x].UpdatePosition(dt);
                    projectiles[x].PrintComponents(i);

                    //specific to levels one and two. End simulation if projectile hits ground
                    if (springRes == false && ground.Z >= projectiles[x].p.Z)
                    {
                        //object has hit ground, exit loop. setting i to simtime ends loop. 
                        i = simTime; 
                    }
                    //specific to level three. Checking if the projectile speed is 1 m/s (within two decimal places). It then saves that time for future reference
                    else
                    {
                        if (Math.Round(projectiles[x].v.Magnitude(), 2) == 1)
                        {
                            finalSt = i;
                        }
                    }
                }
            }
            //print the final time the projectile reached 1m/s if running level three
            if (springRes == true)
            {
                Console.WriteLine("The final time the projectile reached a speed of 1m/s was at: " + finalSt);
            }
        }
    }
}
