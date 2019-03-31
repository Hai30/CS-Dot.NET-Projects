using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColors { Gray = 1, Blue = 1, White = 1, Black = 1};
        public enum eDoor { two = 1, three = 1, Four = 1, Five = 1 };

        private FuelEngine m_Fuel = new FuelEngine();
		private eColors m_Color;
		private eDoor m_Doors;

        private readonly float r_MaxAirPressure = (float)32;
        private readonly FuelEngine.eFuelType r_FuelType = FuelEngine.eFuelType.Octan98;
        private readonly float r_MaxBatteryHours = (float)3.2;
        private readonly float r_MaxFuelCapacity = (float)45;
		private string m_EngineType;
    
        public Car(EnergyOfEngine i_TypeOfEnergy) : base(i_TypeOfEnergy)
        {
            this.WheelsOfVehicle = new Wheel[4];
          
        }

		public Car()
		{
			this.WheelsOfVehicle = new Wheel[4];
			// TODO: Complete member initialization
		}

        public eColors ColorOfCar
        {
         
            set
            {
                m_Color = value;
            }

            get
            {
                return m_Color;
            }

        }

        public eDoor DoorsOfCar
        {

            set
            {
                m_Doors = value;
            }

            get
            {
                return m_Doors;
            }

        }

        public float MaxVehiclePsi
        {
            get
            {
                return r_MaxAirPressure;
            }
        }
		public string EngineType
		{
			set
			{
				m_EngineType = value;

			}
			get
			{
				return m_EngineType;
			}
		}
        public FuelEngine.eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
        public float MaxBatteryHours
        {
            get
            {
                return r_MaxBatteryHours;
            }
        }
        public float MaxFuelCapacity
        {
            get
            {
                return r_MaxFuelCapacity;
            }
        }
        public override float EnergyInPercentage
       {
            set
            {
                float m_Energy = value;
				if (this.m_EngineType == "fuelEngine")
                {
                    m_EnergyInPercentage = (m_Energy * r_MaxFuelCapacity) / 100;
                }
                else
                {
                    m_EnergyInPercentage = (m_Energy * r_MaxBatteryHours) / 100;
                }
            }
            get
            {
                return m_EnergyInPercentage;
            }
          
        }
        public override string ToString()
        {

            string CarInfo = string.Format(
 @"
Your car info:
-----------------
Car Color is: {0}
Car number of doors is: {1}
Car number of wheels is: {2}

Wheels status is:
----------------- 
Current PSI: {3}
Manufacturer Name: {4}",
       
            ColorOfCar.ToString(),
            DoorsOfCar.ToString(),
            WheelsOfVehicle.Length.ToString(),
			WheelsOfVehicle[0].CurrentPSI.ToString(),
			WheelsOfVehicle[0].ManufecturerName.ToString());


            return CarInfo;
        }

    }
}
