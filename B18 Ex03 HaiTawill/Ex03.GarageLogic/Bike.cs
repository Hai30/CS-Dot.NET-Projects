namespace Ex03.GarageLogic
{
    public class Bike : Vehicle
    {
        public enum eLicenseOfBike { A = 1, A1 = 2, B1 = 3, B2 = 4 };

		private string m_EngineType;
        private readonly float r_MaxAirPressure = (float)30;
        private readonly FuelEngine.eFuelType r_FuelType = FuelEngine.eFuelType.Octan96;
        protected readonly float r_MaxFuelCapacity = (float)6;
        protected readonly float r_MaxBatteryHours = (float)1.8;

        private eLicenseOfBike m_LicenseOfBike;
        private int m_EngineVolume;

        public Bike(EnergyOfEngine i_TypeOfEnergy) : base(i_TypeOfEnergy)
        {
            this.WheelsOfVehicle = new Wheel[2];
            
        }

		public Bike()
		{
			this.WheelsOfVehicle = new Wheel[2];
		}

        public int EngineVolume
        {
            set
            {
                m_EngineVolume = value;
            }
            get
            {
                return m_EngineVolume;
            }
        }

        public eLicenseOfBike LicenseOfBike
        {
            set
            {
                m_LicenseOfBike = value;
            }
            get
            {
                return m_LicenseOfBike;
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

            string BikeInfo = string.Format(
 @"
Your bike info:
-----------------
Bike license type is: {0}
Bike engine volume is: {1}
Bike number of wheels is: {2}

Wheels status is:
----------------- 
Current PSI: {3}
Manufacturer Name: {4}",
           
            LicenseNumber.ToString(),
			EngineVolume.ToString(),
            WheelsOfVehicle.Length.ToString(),
			WheelsOfVehicle[0].CurrentPSI.ToString(),
			WheelsOfVehicle[0].ManufecturerName.ToString());


            return BikeInfo;
        }


    }
}
