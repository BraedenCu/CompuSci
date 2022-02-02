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
        public Vector fGrav, fAir, fNet;
        public List<Projectile> projectiles;
        public double aG = -9.8;
        public bool airResBool;
        public double simTime;
        double C = 0.5;
        public double dt;
        //Ground???

        public World(double time, double dt, List<Projectile> projectiles)
        {
            this.dt = dt;
            airResBool = true;
            simTime = time;
            this.projectiles = projectiles;
        }

        public void CalculateForces(Projectile p) {
            if (airResBool)
            {
                fGrav = new Vector(
                    0 * p.mass,                           //force of gravity in the X direction
                    0,                                    //force of gravity in the Y direction
                    aG * p.mass                           //force of gravity in the Z direction
                );
                fAir = new Vector(
                    C * p.v.X * p.v.X * Math.Sign(p.v.X),
                    0,
                    C * p.v.Z * p.v.Z * Math.Sign(p.v.Z)
                );
                fNet = (fGrav - fAir);
            }
        }
        public void ApplyForces(Projectile p)
        {
            p.a = fNet / p.mass;
        }

        public void Simulate() { //main function
            for(double i = 0; i < simTime; i+=dt)
            {
                for(int x = 0; x < projectiles.Count; x++)
                {
                    CalculateForces(projectiles[x]);
                    ApplyForces(projectiles[x]);
                    projectiles[x].UpdatePosition(dt);
                    //projectiles[x].PrintComponents();
                    //Console.WriteLine(i);
                }
            }
        }
    }
}
