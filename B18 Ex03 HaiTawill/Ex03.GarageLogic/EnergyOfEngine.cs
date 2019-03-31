using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EnergyOfEngine
    {

        private float m_CurrentAmountOfEnergy;
        private float m_MaxAmountOfEnergy;


        public EnergyOfEngine()
        {

        }

        public EnergyOfEngine(float i_MaxAmountOfEnergy)
        {
            m_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }
        public float CurrentAmountOfEnergy
        {
            set
            {
                
                    if (value <= m_MaxAmountOfEnergy && value > 0)
                    {
                        this.m_CurrentAmountOfEnergy = value;

                    }
                else
                {
                    ValueOutOfRangeException ex = new ValueOutOfRangeException(0, m_MaxAmountOfEnergy, "You cant add this Amount Of Energy");
                    string msg = ex.Message;
                    Console.WriteLine(msg);

                }



            }
            get
            {
                return m_CurrentAmountOfEnergy;
            }
        }
        public float MaxAmountOfEnergy
        {
            set
            {
                this.m_MaxAmountOfEnergy = value;
            }
            get
            {
                return this.m_MaxAmountOfEnergy;
            }
        }

        public abstract void EnergyToVehicle(float i_AmountToAdd, EnergyOfEngine i_TypeOfEnergy);

        public override string ToString()
        {

            string EnergyInfo = string.Format(
@"The info of the engine is: ");

            return EnergyInfo;
        }
    }
}
