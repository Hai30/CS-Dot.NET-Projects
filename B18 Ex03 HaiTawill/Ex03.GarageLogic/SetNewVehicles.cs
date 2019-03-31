using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public  class SetNewVehicles : GarageEntryOfVehicle
    {

        
        public enum eEnginePropulsion { Fuel = 1, Electricity = 2 }
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            Vehicle m_Vehicle = null;
            FuelEngine FuelPropulsion = null;
            ElectricityEngine ElectricityPropulsion = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:  //Fuel Car
                    FuelPropulsion = new FuelEngine (45f);
                    FuelPropulsion.FuelType = FuelEngine.eFuelType.Octan98;
                    m_Vehicle = new Car(FuelPropulsion);
                    m_Vehicle.SetAirPressureInWheels(32f);
                    break;

                case eVehicleType.ElectricyCar:   //Electric Car
                    ElectricityPropulsion = new ElectricityEngine(3.2f);
                    m_Vehicle = new Car(FuelPropulsion);
                    m_Vehicle.SetAirPressureInWheels(32f);
                    break;

                case eVehicleType.FuelBike:  //Fuel Bike
                    FuelPropulsion = new FuelEngine(6f);
                    FuelPropulsion.FuelType = FuelEngine.eFuelType.Octan96;
                    m_Vehicle = new Bike(FuelPropulsion);
                    m_Vehicle.SetAirPressureInWheels(30f);
                    break;

                case eVehicleType.ElectricyBike:  //Electric Bike
                    ElectricityPropulsion = new ElectricityEngine (1.8f);
                    m_Vehicle = new Bike(ElectricityPropulsion);
                    m_Vehicle.SetAirPressureInWheels(30f);
                    break;

                case eVehicleType.Truck:   //Fuel Truck
                    FuelPropulsion = new FuelEngine(115f);
                    FuelPropulsion.FuelType = FuelEngine.eFuelType.Soler;
                    m_Vehicle = new Truck(FuelPropulsion);
                    m_Vehicle.SetAirPressureInWheels(28f);
                    break;

                default:
                    throw new ArgumentException("Type of Vehicle not Set");
            }

            return m_Vehicle;
        }
       

    
    }
}
