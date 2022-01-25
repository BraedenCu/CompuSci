using System;

namespace Kinematics
{
    public static class Kinematics
    {
        public static void Main()
        {
            LevelOne();
            LevelTwo();
            LevelThree();
        }

        public static void LevelOne() 
        {
            double particleVel = 5; //m/s
            double time = 100; //ending time to calculate position at 
            double increment = 0.1; //step size for approx.
            double changePos;
            double totalPos = 0; //total position (old position + change in position)
            double i = 0; //iterator
            int precision = 1; //precision for iterator to account for weird decimal arithmetic in c#

            while (i <= time)
            {
                i = Math.Round(i, precision); //round to account for weird c# decimal action
                Console.WriteLine(i.ToString() + "  " + totalPos.ToString() + "    " + particleVel.ToString());
                changePos = particleVel * increment;
                totalPos += changePos;
                i += 0.1;
            }
        }

        public static void LevelTwo()
        {
            double accel = -9.8; //change in velocity / change in time,    m/s^2
            double initialVelocity = 5; //m/s
            double velocity = initialVelocity; //change in accel * change in time, 
            double time = 100; //ending time to calculate position at 
            double increment = 0.1; //step size
            double changePos;
            double totalPos = 0; //total position (old position + change in position)
            double i = 0; //iterator
            int precision = 1; //precision for iterator to account for weird decimal arithmetic in c#

            while (i <= time)
            {
                i = Math.Round(i, precision);
                Console.WriteLine(i.ToString() + "    " + totalPos.ToString() + "    " + velocity.ToString() + "   " + accel.ToString());
                velocity = velocity + accel * increment;
                changePos = velocity * increment;
                totalPos += changePos;
                i += increment;
            }
        }

        public static void LevelThree()
        {
            double accelGrav = -9.8; //change in velocity / change in time,    m/s^2
            double initialVel = 5; //m/s
            double velocity = initialVel; //change in accel * change in time
            double time = 100; //ending time to calculate position at 
            double increment = 0.1; //calculate change in position every __ seconds
            double changePos = 0; //change in position
            double pos = 0; //total position (old position + change in position)
            double i = 0; //iterator
            int precision = 1; //precision for iterator to account for weird decimal arithmetic in c#'
            
            //now we are adding air resistence yayyyyy
            double particleMass = 4; //kg
            double C = 0.5; //kg/m

            double forceGrav; 
            double forceAir;
            double newAccel;

            while (i <= time)
            {
                i = Math.Round(i, precision);
                forceAir = C * (velocity * velocity);
                forceGrav = particleMass * accelGrav;
                newAccel = (-1*forceAir*Math.Sign(velocity) + forceGrav) / particleMass;
                velocity = velocity + (newAccel * 0.1);
                changePos = velocity * increment;
                pos += changePos;
                Console.WriteLine(i.ToString() + "    " + pos.ToString() + "    " + velocity.ToString() + "   " + newAccel.ToString());
                i += increment;
            }
        }
    }
}