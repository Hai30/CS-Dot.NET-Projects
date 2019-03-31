using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {

        private bool m_IsTrunkCool;
        private float m_LoadCapacity;

        private readonly float r_MaxAirPressure = (float)28;
        private readonly FuelEngine.eFuelType r_FuelType = FuelEngine.eFuelType.Soler;
        protected readonly float r_MaxFuelCapacity = (float)115;


        public Truck(EnergyOfEngine i_TypeOfEnergy) : base(i_TypeOfEnergy)
        {
            this.WheelsOfVehicle = new Wheel[12];
            
        }

		public Truck()
		{
			this.WheelsOfVehicle = new Wheel[12];
			// TODO: Complete member initialization
		}

        public float LoadCapacity
        {
            set
            {
                m_LoadCapacity = value;
            }
            get
            {
                return m_LoadCapacity;
            }
        }

        public bool IsTrunkCool
        {
            set
            {
                m_IsTrunkCool = value;
            }
            get
            {
                return m_IsTrunkCool;
            }
        }


        public float MaxVehiclePsi
        {
            get
            {
                return r_MaxAirPressure;
            }
        }
        public FuelEngine.eFuelType FuelType
        {
            get
            {
                return r_FuelType;
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
                m_EnergyInPercentage = (m_Energy * r_MaxFuelCapacity) / 100;
            }
            get
            {
                return m_EnergyInPercentage;
            }

        }

        public override string ToString()
        {

            string TruckInfo = string.Format(
 @"
Your truck info:
----------------
Truck CoolTrunK option is: {0}
Truck load capacity is:  {1}
Truck number of wheels is: {2}

Wheels status is:
----------------- 
Current PSI: {3}
Manufacturer Name: {4}",
         
            IsTrunkCool.ToString(),
            LoadCapacity.ToString(),
            WheelsOfVehicle.Length.ToString(),
            WheelsOfVehicle[0].CurrentPSI.ToString(),
			WheelsOfVehicle[0].ManufecturerName.ToString());


            return TruckInfo;
        }



    }
}
