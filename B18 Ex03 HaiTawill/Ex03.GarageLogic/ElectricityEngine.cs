using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricityEngine : EnergyOfEngine
    {
        public ElectricityEngine() : base ()
        {

        }

        public ElectricityEngine(float i_MaxAmountOfEnergy) : base (i_MaxAmountOfEnergy)
        {

        }

        public override void EnergyToVehicle(float i_AmountToAdd, EnergyOfEngine i_TypeOfEnergy)
        {
			if (i_TypeOfEnergy.CurrentAmountOfEnergy + i_AmountToAdd <= i_TypeOfEnergy.MaxAmountOfEnergy && i_AmountToAdd >= 0)
			{
				CurrentAmountOfEnergy += i_AmountToAdd;
                GarageManagment.IsMax = false;
            }

            else
            {
                ValueOutOfRangeException ex = new ValueOutOfRangeException(0, i_TypeOfEnergy.MaxAmountOfEnergy, "You cant add this Amount Of Energy");
                GarageManagment.IsMax = true;
                string msg = ex.Message;
                Console.WriteLine(msg);
                

            }

        }
    }
}
