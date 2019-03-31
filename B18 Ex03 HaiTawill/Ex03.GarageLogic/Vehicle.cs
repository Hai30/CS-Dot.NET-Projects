using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        protected float m_EnergyInPercentage;
        private float m_MaxVehiclePsi;
		

        public EnergyOfEngine m_EnergySource;
		private Wheel[] m_Wheels =null;

        public string VehicleModel
        {
            set
            {
                m_Model = value;
            }
            get
            {
                return m_Model;
            }
        }
        public string LicenseNumber
        {
            set
            {
                m_LicenseNumber = value;
            }
            get
            {
                return m_LicenseNumber;
            }
        }
        public EnergyOfEngine VehiclePropulsion
        {
            set
            {
                m_EnergySource = value;
            }

            get
            {

                return m_EnergySource;
            }

        }
        public abstract float EnergyInPercentage { set; get; }
        public Vehicle(EnergyOfEngine i_VehicleEnergySource)
        {
            VehiclePropulsion = i_VehicleEnergySource;
        }
		public Vehicle()
		{
			// TODO: Complete member initialization
		}
        public Wheel[] WheelsOfVehicle
        {
            set
            {

                m_Wheels = value;
            }
            get
            {
                return m_Wheels;
            }
        }
        public float MaxVehiclePsi
        {
            
                set
            {
                    m_MaxVehiclePsi = value;
                }
                get
            {
                    return m_MaxVehiclePsi;
                }
        }
        public void SetAirPressureInWheels(float i_PSIForWheels)
        {

            for(int i = 0;i< m_Wheels.Length;i++)
            {
                m_Wheels[i] = new Wheel();
                m_Wheels[i].CurrentPSI = i_PSIForWheels;
            }


        }
        public void SetManufacturerInWheels(string i_WheelsManufacturer)
        {
			for(int i =0;i<m_Wheels.Length;i++)
			{
				m_Wheels[i] = new Wheel();
				m_Wheels[i].ManufecturerName = i_WheelsManufacturer;
            }
        }
        public override string ToString()
        {
           string VehicleInfo = string.Format(
@"Vehicle Model is: {0}
Vehicle License number is: {1}
The vehicle energy percentage is: {2}
The vehicle engine propulsion is: {3}",
            VehicleModel,
            LicenseNumber,
            EnergyInPercentage,
			m_EnergySource);
            return VehicleInfo;


        }
    }
}
