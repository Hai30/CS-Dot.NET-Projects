using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManagment : GarageEntryOfVehicle
    {
        public static bool IsMax = false;
        public void ShowAllVehiclesLicenseAndStateInGarage(GarageVehicleProfile.eStateOfVehicle i_VehicleGarageState)
        {
          int m_Count = 0;
          foreach(KeyValuePair<string, GarageVehicleProfile> vehicles in VehiclesInGarage)
          {
                
                if (vehicles.Value.VehicleStatus == i_VehicleGarageState)
                {
					 string msg = string.Format(
@"The LicenseNumber is: {0} for the status: {1} ",
					vehicles.Key,
					i_VehicleGarageState.ToString());
					 Console.WriteLine(msg);
					m_Count++;
                }  
   			  
          }
          if (m_Count == 0)
          {
                throw new Exception("Their is not Vehicle in Garage with the status of : " + i_VehicleGarageState.ToString());
           
          }
        } 

        public void ChangeStateOfVehicleInGarage(string i_License, GarageVehicleProfile.eStateOfVehicle i_NewVehicleState)
        {
           try
            {
                if (VehiclesInGarage.ContainsKey(i_License))
                {
                    VehiclesInGarage[i_License].VehicleStatus = i_NewVehicleState;
                    string msg = string.Format("The vehicle with license No: {0} status successfully changed for {1}!", i_License, i_NewVehicleState);
                    Console.WriteLine(msg);
                }
            }
            catch(KeyNotFoundException ex)
            {
                string msg = string.Format(
@"The requested license {0} for the status change has not found in the garage system",
                i_License.ToString());


            }
        
        }

        public void BlowMaxPressureByLicense(string i_License)
        {
            try
            {
                VehiclesInGarage[i_License].m_Vehicle.SetAirPressureInWheels(VehiclesInGarage[i_License].m_Vehicle.MaxVehiclePsi);

            }
            catch (KeyNotFoundException ex)
            {
                string msg = string.Format(
@"The requested license {0} for the status change has not found in the garage system",
                i_License.ToString());

            }
         }


        public void AddFuelToVehicle(string i_License, FuelEngine.eFuelType i_FuelType, float i_AmountToAdd)
        {

            try       
            {

				VehiclesInGarage[i_License].m_Vehicle.m_EnergySource.EnergyToVehicle(i_AmountToAdd, VehiclesInGarage[i_License].m_Vehicle.m_EnergySource);
                if (IsMax == false)
                {
                    string msg = string.Format("You successfully Added the fuel CurrentAmountOfEnergy is {0} to vehicle with license No. {1} !", VehiclesInGarage[i_License].m_Vehicle.m_EnergySource.CurrentAmountOfEnergy, i_License);
                    Console.WriteLine(msg);
                }
            }
            catch (KeyNotFoundException ex)
            {
                string msg = string.Format(
@"The requested license {0} for the status change has not found in the garage system",
                i_License.ToString());

            }
        }


        public void ChargeElectricityToVehicle(string i_License, float i_AmountInMinutesToCharge)
        {

            float m_AmountToChargeInHours = i_AmountInMinutesToCharge / 60;
            try
            {
                

                VehiclesInGarage[i_License].m_Vehicle.m_EnergySource.EnergyToVehicle(m_AmountToChargeInHours, VehiclesInGarage[i_License].m_Vehicle.m_EnergySource);
				if (IsMax ==false)
                {
                    string msg = string.Format("You successfully Charged your battery CurrentAmountOfEnergy is {0} to vehicle with license No. {1} !", VehiclesInGarage[i_License].m_Vehicle.m_EnergySource.CurrentAmountOfEnergy, i_License);
                    Console.WriteLine(msg);
                }
				
            }
            catch (KeyNotFoundException ex)
            {
                string msg = string.Format(
@"The requested license {0} for the status change has not found in the garage system",
                i_License.ToString());

            }
        }


        public void ShowProfileVehicleByLicenseInGarage(string i_License)
        {
            try
            {
                VehiclesInGarage[i_License].ToString();
                VehiclesInGarage[i_License].m_Vehicle.ToString();

            }
            catch (KeyNotFoundException ex)
            {
                string msg = string.Format(
@"The requested license {0} for the status change has not found in the garage system",
                i_License.ToString());

            }

        }


    }
}
                                           