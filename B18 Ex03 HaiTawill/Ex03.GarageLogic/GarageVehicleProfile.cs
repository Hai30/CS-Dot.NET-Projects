using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageVehicleProfile
    {
        public enum eStateOfVehicle { Repair = 1, Fixed = 2, Paid = 3 }

        private string m_NameOfOwner;
        private string m_PhoneOfOwner;
        private eStateOfVehicle m_VehicleStatus = eStateOfVehicle.Repair;
		public GarageEntryOfVehicle.eVehicleType m_VehicleType;
        public Vehicle m_Vehicle;

		public GarageVehicleProfile()
		{
	
		}
        public eStateOfVehicle VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public string NameOfOwner
        {
            get
            {
                return m_NameOfOwner;

            }

            set
            {
                m_NameOfOwner = value;
            }
        }

        public string PhoneOfOwner
        {
            get
            {
                return m_PhoneOfOwner;

            }

            set
            {
                m_PhoneOfOwner = value;
            }
        }
		public eStateOfVehicle ChangeVehicleStatus
		{

			set
			{
				m_VehicleStatus = value;
			}
			get
			{
				return m_VehicleStatus;

			}
		}

     

        public override string ToString()
        {
            string GarageVehicleProfileInfo = string.Format(
@"Profile of Vehicle in the Garage:
Vehicle Owner name is: {0}
Vehicle Owner Phone is: {1}
Vehicle State on the garage: {2}",
            NameOfOwner,
            PhoneOfOwner,
            VehicleStatus.ToString());

            return GarageVehicleProfileInfo;
        }

    }
}
