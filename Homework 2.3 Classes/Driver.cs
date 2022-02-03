using System;
using Utility;

namespace Homework_2._3_Classes // Note: actual namespace depends on the project name.
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            double simTime = 100, dt = 0.01; //simTime -> total time of simulation. dt -> increment

            List<Projectile> projectiles = new List<Projectile>() {
                //regular projectile -> levels one and two
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
                //spring projectile -> level three
                new Projectile(
                    4,                              //projectile mass
                    new Vector(-1, 1, -1),          //initialPosition
                    new Vector(5, -1, 3),           //initialVelocity
                    new Vector(0, 0, 0)             //initialAcceleration
                )
            };

            LevelOne(simTime, dt, projectiles);
            LevelTwo(simTime, dt, projectiles);
            LevelThree(simTime, dt, projectiles);
        }

        public static void LevelOne(double simTime, double dt, List<Projectile> projectiles)
        {
            bool airRes = false;
            bool springRes = false;
            List<Projectile> projectileList = new List<Projectile>() { projectiles[0] }; //we only want to pass the first projectile
            var world = new World(simTime, dt, projectiles, airRes, springRes);
            world.Simulate();
            Console.WriteLine("End of level one simulation");
        }

        public static void LevelTwo(double simTime, double dt, List<Projectile> projectiles)
        {
            bool airRes = true;
            bool springRes = false;
            List<Projectile> projectileList = new List<Projectile>() { projectiles[0] }; //we only want to pass the first projectile
            var world = new World(simTime, dt, projectiles, airRes, springRes);
            world.Simulate();
            Console.WriteLine("End of level two simulation");
        }

        public static void LevelThree(double simTime, double dt, List<Projectile> projectiles)
        {
            bool airRes = true;
            bool springRes = true;
            double C = 0.5;
            double unstretchedLength = 2;
            double springConst = 8;
            List<Projectile> projectileList = new List<Projectile>() { projectiles[1] }; //we only want to pass the second projectile
            var world = new World(simTime, dt, projectileList, airRes, springRes, C, unstretchedLength, springConst);
            world.Simulate();
            Console.WriteLine("End of level three simulation");
        }
    }
}