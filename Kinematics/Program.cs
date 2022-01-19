using System;

//curly brace goes on the next line
namespace Kinematics
{
    public static class Kinematics
    {
        public static void Main()
        {
            //LevelOne();
            LevelTwo();
        }

        public static void LevelOne() 
        {
            double particleVel = 5; //m/s
            double time = 100; //ending time to calculate position at 
            double increment = 0.1; //calculate change in position every __ seconds
            double changePos = 0; //change in position
            double pos = 0; //total position (old position + change in position)
            double i = 0; //iterator
            int precision = 1; //precision for iterator to account for weird decimal arithmetic in c#
            //position vs time, velocity vs time
            while (i <= time)
            {
                i = Math.Round(i, precision);
                Console.WriteLine(i.ToString() + "  " + pos.ToString() + "    " + particleVel.ToString());
                changePos = particleVel * increment;
                pos += changePos;
                i += 0.1;
            }
            //velocity vs time
            /*
            i = 0; //reset increment
            while (i <= time)
            {
                i = Math.Round(i, precision);
                Console.WriteLine(particleVel.ToString() + "   " + i.ToString());
                i += 0.1;
            }
            */
        }

        public static void LevelTwo()
        {
            double accel = -9.8; //change in velocity / change in time,    m/s^2
            double initialVel = 5; //m/s
            double velocity = 0; //change in accel * change in time
            double time = 100; //ending time to calculate position at 
            double increment = 0.1; //calculate change in position every __ seconds
            double changePos = 0; //change in position
            double pos = 0; //total position (old position + change in position)
            double i = 0; //iterator
            int precision = 1; //precision for iterator to account for weird decimal arithmetic in c#'

            velocity = initialVel;
            while (i <= time)
            {
                i = Math.Round(i, precision);
                velocity = velocity + accel * increment;
                changePos = velocity * increment;
                pos += changePos;
                Console.WriteLine(i.ToString() + "    " + pos.ToString() + "    " + velocity.ToString() + "   " + accel.ToString());
                i += increment;
                //calculations for next run
            }
        }

        public static void LevelThree()
        {
            int x = 0;
        }
    }
}