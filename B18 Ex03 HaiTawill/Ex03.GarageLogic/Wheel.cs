using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentPSI;
        

        public Wheel(string i_ManufacturerName, float i_CurrentPSI, float i_MaxVehiclePsi)
        {
            this.m_CurrentPSI = i_CurrentPSI;
            this.m_ManufacturerName = i_ManufacturerName;
            
        }

		public Wheel()
		{
			// TODO: Complete member initialization
		}

        public string ManufecturerName
        {

            set
            {
                m_ManufacturerName = value;
            }
            get
            {
                return m_ManufacturerName;
            }

        }
        public float CurrentPSI
        {

            set
            {
                m_CurrentPSI = value;
            }
            get
            {
                return m_CurrentPSI;
            }
        }
       

        /*
        public float addAirPressure(float i_PSIToAdd)
        {

            try
            {
                if (this.m_MaxPSI >= i_PSIToAdd + this.m_CurrentPSI || i_PSIToAdd + this.m_CurrentPSI < 0)
                {
                    this.m_CurrentPSI += i_PSIToAdd;
                }
            }
            catch (ValueOutOfRangeException e)
            {
                string.Format("You can't add this amount of PSI {0} to your wheel", i_PSIToAdd);
            }
            return this.m_CurrentPSI;
        }
        */
    }
}
