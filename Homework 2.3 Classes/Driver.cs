using System;
using Utility;

namespace Homework_2._3_Classes // Note: actual namespace depends on the project name.
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            double simTime = 0.68, dt = 0.01; //simulate for 0.71 sec

            List<Projectile> projectiles = new List<Projectile>() {
                new Projectile(
                    4,                              //projectile mass
                    new Vector(0, 0, 0),            //initialPosition
                    new Vector(                     //initialVelocity
                        Math.Cos(Math.PI / 4)*5,    //launch angle * initial velocity
                        0,
                        Math.Sin(Math.PI / 4) * 5   //launch angle * initial velocity
                    ),
                    new Vector(0, 0, 0)  //initialAcceleration
                )
            };
            
            var world = new World(simTime, dt, projectiles);
            world.Simulate();
        }
    }
}