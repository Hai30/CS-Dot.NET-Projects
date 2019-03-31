using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageEntryOfVehicle
    {
		public enum eVehicleType { ElectricyCar = 1, FuelCar = 2, ElectricyBike = 3, FuelBike = 4, Truck = 5 }
        public Dictionary<string, GarageVehicleProfile> VehiclesInGarage = null;

		public void AddVehicleToGarage(string i_License, GarageVehicleProfile i_Profile)
        {

            if (VehiclesInGarage == null)
            {
				VehiclesInGarage = new Dictionary<string, GarageVehicleProfile>(0);

				VehiclesInGarage.Add(i_License, i_Profile);
            }

            else
            {
              
                    if (VehiclesInGarage.ContainsKey(i_License)==false)
                    {
                        VehiclesInGarage.Add(i_License, i_Profile);
                    }
                
                else
                {
                    string msg = string.Format(
@"Vehicle License number : {1} is already in Garage",
                    i_License
                        );
                    Console.WriteLine(msg);
                }
            }
        }

    }
}












