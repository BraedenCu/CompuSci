using System;
using Utility;

namespace Homework_2._3_Classes // Note: actual namespace depends on the project name.
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            double simTime = 10, dt = 0.01; //simulate for 0.71 sec

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
                ),
                //spring projectile
                new Projectile(
                    4,                              //projectile mass
                    new Vector(-1, 1, -1),            //initialPosition
                    new Vector(                     //initialVelocity
                        5,    //launch angle * initial velocity
                        -1,
                        3   //launch angle * initial velocity
                    ),
                    new Vector(0, 0, 0)  //initialAcceleration
                )
            };

            //LevelOne(simTime, dt, projectiles);
            //LevelTwo(simTime, dt, projectiles);
            LevelThree(simTime, dt, projectiles);
        }

        public static void LevelOne(double simTime, double dt, List<Projectile> projectiles)
        {
            bool airRes = false;
            bool springRes = false;
            var world = new World(simTime, dt, projectiles, airRes, springRes);
            world.Simulate();
        }

        public static void LevelTwo(double simTime, double dt, List<Projectile> projectiles)
        {
            bool airRes = true;
            bool springRes = false;
            var world = new World(simTime, dt, projectiles, airRes, springRes);
            world.Simulate();
        }

        public static void LevelThree(double simTime, double dt, List<Projectile> projectiles)
        {
            bool airRes = true;
            bool springRes = true;
            var world = new World(simTime, dt, projectiles, airRes, springRes);
            world.Simulate();
        }
    }
}