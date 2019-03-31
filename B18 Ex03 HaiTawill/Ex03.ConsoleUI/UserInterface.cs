using System;
using System.Collections.Generic;
using System.Text;

using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface : UserEnumParse
    {
		private Car m_car = new Car();
		private Bike m_Bike = new Bike();
		private Truck m_Truck = new Truck();

        private Car.eColors m_UserCarColor;
        private Car.eDoor m_UserCarDoors;
		private GarageEntryOfVehicle.eVehicleType m_UserVehicleType;
        private Bike.eLicenseOfBike m_UserBikeLicenseType;
		private FuelEngine.eFuelType m_FuelType;
		private GarageVehicleProfile.eStateOfVehicle m_UserStateChoose;
		GarageManagment m_Grage = new GarageManagment();
		private GarageVehicleProfile m_VehicleProfile = new GarageVehicleProfile();
        

        private string [] ArrayOfInfo = new string[10];
		private bool m_IsAddVehicle = false;


        public void AppMenu()
        {
            Console.WriteLine(
@"Main Menu:
============
Please type your desired choose in the app:
------------------------------------------
1) Insert a vehicle to the garage

2) report your wanted services for your vehicle

3) Exit

");			   
			string number = Console.ReadLine();
            int NumChoose;
            while( int.TryParse(number,out NumChoose) == false)
            {
                Console.WriteLine("Please choose Legal choose: 1, 2 or 3!");
                number = Console.ReadLine();
            }
            NumChoose = int.Parse(number);
            while (NumChoose == 1 || NumChoose == 2)
            {
                if (NumChoose == 1)
                {


                    SetInfoOfNewProfile();
                    SetNewProfile();
					m_IsAddVehicle = true;
                    ActionInGarage();
                }
                if (NumChoose == 2)
                {
                    if (m_Grage.VehiclesInGarage == null)
                    {
                        Console.WriteLine("**Warning!** The garage is empty please enter a Vehicle Profile before choosing wanted services for your vehicle !");
                        number = Console.ReadLine();
                        NumChoose = int.Parse(number);
                    }
                    else
                    {
                        ActionInGarage();
                    }
                }
				if (NumChoose == 3)
				{
					break;
				}
            }
			Console.WriteLine("Please choose Legal choose: 1, 2 or 3!");
        }
		public void SetInfoOfNewProfile()
		{
			Console.WriteLine("Please enter your name: ");
			string str = Console.ReadLine();
			while (isAllLetters(str) != true)
			{
				Console.WriteLine("You need to enter only letters! please insert again ");
				str = Console.ReadLine();
			}
			ArrayOfInfo[0] = str;

			Console.WriteLine("Please enter your valid Phone: ");
			str = Console.ReadLine();
			while (isAllDigits(str) != true || str.Length != 10)
			{
				Console.WriteLine("You need to enter phone number with only 10 digits in this format: XXXXXXXXXX! insert again! ");
				str = Console.ReadLine();
			}
			ArrayOfInfo[1] = str;

			Console.WriteLine("Please enter your vehicle Model: ");
			str = Console.ReadLine();
			while (isAllLetters(str) != true)
			{
				Console.WriteLine("You need to enter only letters! please insert again ");
				str = Console.ReadLine();
			}
			ArrayOfInfo[2] = str;

			Console.WriteLine("Please enter your vehicle license: ");
			str = Console.ReadLine();
			while (isAllLettersOrDigits(str) != true ||  str.Length != 7)
			{
				Console.WriteLine("You need to enter license with only 7 letters and digits! please insert again ");
				str = Console.ReadLine();
			}
			ArrayOfInfo[3] = str;

			Console.WriteLine("Please enter your Vehicle Wheels Manufacturer: ");
			str = Console.ReadLine();
			while (isAllLetters(str) != true)
			{
				Console.WriteLine("You need to enter only letters! please insert again ");
				str = Console.ReadLine();
			}
			ArrayOfInfo[4] = str;

            Console.WriteLine("Please enter your Vehicle current amount of Energy(In Fuel tank/In Battery): ");
            str = Console.ReadLine();
            while (isAllDigits(str) != true)
            {
                Console.WriteLine("You need to enter only letters! please insert again ");
                str = Console.ReadLine();
            }
            ArrayOfInfo[8] = str;
        }
		public void SetNewProfile( )
        {
			EnergyOfEngine f = new FuelEngine();
			EnergyOfEngine e = new ElectricityEngine();
			
			 UserTypeOfVehicle();
             m_VehicleProfile.NameOfOwner =ArrayOfInfo[0];
             m_VehicleProfile.PhoneOfOwner =ArrayOfInfo[1];
			 if (m_UserVehicleType == GarageEntryOfVehicle.eVehicleType.ElectricyBike || m_UserVehicleType == GarageEntryOfVehicle.eVehicleType.FuelBike)
			 {
				 if (m_UserVehicleType == GarageEntryOfVehicle.eVehicleType.FuelBike)
				 {
					m_Bike = new Bike(f);
					m_Bike.m_EnergySource.MaxAmountOfEnergy = m_Bike.MaxFuelCapacity;
					m_Bike.m_EnergySource.CurrentAmountOfEnergy =float.Parse( ArrayOfInfo[8]);
					m_FuelType = FuelEngine.eFuelType.Octan96;
                    m_VehicleProfile.m_Vehicle =SetNewVehicles.CreateVehicle(GarageEntryOfVehicle.eVehicleType.FuelBike);
					m_Bike.EngineType = "fuelEngine";
				
                   
                 }
                else
                {
					m_Bike = new Bike(e);
					m_Bike.m_EnergySource.MaxAmountOfEnergy = m_Bike.MaxBatteryHours;
					m_Bike.m_EnergySource.CurrentAmountOfEnergy = float.Parse(ArrayOfInfo[8]);
					
                    m_VehicleProfile.m_Vehicle = SetNewVehicles.CreateVehicle(GarageEntryOfVehicle.eVehicleType.ElectricyBike);
                   
					m_Bike.EngineType = null;
				
                }
              
                BikeLicenseType();
                 m_VehicleProfile.m_Vehicle = m_Bike;
				 m_VehicleProfile.m_Vehicle.WheelsOfVehicle = new Wheel[2];
			 }
			 if (m_UserVehicleType == GarageEntryOfVehicle.eVehicleType.ElectricyCar || m_UserVehicleType == GarageEntryOfVehicle.eVehicleType.FuelCar)
			 {
				 if (m_UserVehicleType == GarageEntryOfVehicle.eVehicleType.FuelCar)
				 {
				    m_car = new Car(f);
					m_car.m_EnergySource.MaxAmountOfEnergy = m_car.MaxFuelCapacity;
					m_car.m_EnergySource.CurrentAmountOfEnergy =float.Parse( ArrayOfInfo[8]);
					
					m_FuelType = FuelEngine.eFuelType.Octan98;
                    m_VehicleProfile.m_Vehicle = SetNewVehicles.CreateVehicle(GarageEntryOfVehicle.eVehicleType.FuelCar);
					m_car.EngineType = "fuelEngine";
					
                }
                else
                {
					m_car = new Car(e);
					m_car.m_EnergySource.MaxAmountOfEnergy = m_car.MaxBatteryHours;
					m_car.m_EnergySource.CurrentAmountOfEnergy = float.Parse(ArrayOfInfo[8]);
					
                    m_VehicleProfile.m_Vehicle = SetNewVehicles.CreateVehicle(GarageEntryOfVehicle.eVehicleType.ElectricyCar);
					m_car.EngineType = null;
					
                }
         
                UserColorOfCar();
				 UserDoorsOfCar();
				 m_VehicleProfile.m_Vehicle = m_car;
				 m_VehicleProfile.m_Vehicle.WheelsOfVehicle = new Wheel[4];
				 
			 }
			 if (m_UserVehicleType == GarageEntryOfVehicle.eVehicleType.Truck)
			 {
                m_VehicleProfile.m_Vehicle = SetNewVehicles.CreateVehicle(GarageEntryOfVehicle.eVehicleType.Truck);
                m_FuelType = FuelEngine.eFuelType.Soler;

				m_Truck  = new Truck(f);
				m_Truck.m_EnergySource.MaxAmountOfEnergy = m_Truck.MaxFuelCapacity;
				m_Truck.m_EnergySource.CurrentAmountOfEnergy =float.Parse( ArrayOfInfo[8]);
				
           
                TruckLoadCapacity();
				 IsTrunkOfTruckCool();
				 m_Truck.LoadCapacity = int.Parse(ArrayOfInfo[6]);
				 m_VehicleProfile.m_Vehicle = m_Truck;
				 m_VehicleProfile.m_Vehicle.WheelsOfVehicle = new Wheel[12];
			 }
			
            m_VehicleProfile.m_Vehicle.EnergyInPercentage = float.Parse(ArrayOfInfo[8]);
             m_VehicleProfile.m_Vehicle.VehicleModel=ArrayOfInfo[2];
			 m_VehicleProfile.m_Vehicle.LicenseNumber=ArrayOfInfo[3];
			m_VehicleProfile.m_Vehicle.SetManufacturerInWheels(ArrayOfInfo[4]);
        }
		private void UserTypeOfVehicle()
        {
            bool IsTypeOfVehicle = false;

            try
            {
               Console.WriteLine(
@"Choose Vehicle type from one of the options:
==============================================
1) Electricity Car
2) Fuel Car
3) Electricity Bike
4) Fuel Bike
5) Truck ");
                string str = Console.ReadLine();
				m_UserVehicleType = UserEnumParseofValue<GarageEntryOfVehicle.eVehicleType>(str);

				if (m_UserVehicleType != null)
				{
					IsTypeOfVehicle = true;
					m_VehicleProfile.m_VehicleType = m_UserVehicleType;
				}
                if (!IsTypeOfVehicle)
                {
                    Console.WriteLine("You choose type of Vehicle that not exist in the system ");
                }
            }
            catch(ArgumentException ex)
            {
                IsTypeOfVehicle = false;
            }
            if (!IsTypeOfVehicle)
            {
                UserTypeOfVehicle();
            }
        }
		private void UserColorOfCar()
        {
            bool IsTypeOfColor = false;

            try
            {
                Console.WriteLine(
 @"Choose car color from one of the options:
==============================================
1) Gray  
2) Blue
3) White
4) Black ");
                string str = Console.ReadLine();
                m_UserCarColor = UserEnumParseofValue<Car.eColors>(str);

				if (m_UserCarColor != null)
				{
					IsTypeOfColor = true;
					m_car.ColorOfCar = m_UserCarColor;
				}
                if (!IsTypeOfColor)
                {
                    Console.WriteLine("Your choose of car color not exist in the system ");
                }
            }
            catch (ArgumentException ex)
            {
                IsTypeOfColor = false;
            }
            if (!IsTypeOfColor)
            {
                UserColorOfCar();
            }
        }
		private void UserDoorsOfCar()
        {
            bool IsTypeOfDoors = false;

            try
            {
                Console.WriteLine(
 @"Choose car number of doors from one of the options:
======================================================
1) two 
2) three
3) Four
4) Five ");
                string str = Console.ReadLine();
                m_UserCarDoors = UserEnumParseofValue<Car.eDoor>(str);
				if (m_UserCarDoors != null)
				{
					IsTypeOfDoors = true;
					m_car.DoorsOfCar = m_UserCarDoors;
				}
                if (!IsTypeOfDoors)
                {
                    Console.WriteLine("Your choose of car doors number not exist in the system ");
                }
            }
            catch (ArgumentException ex)
            {
                IsTypeOfDoors = false;
            }
            if (!IsTypeOfDoors)
            {
				UserDoorsOfCar();
            }
        }
		private void BikeLicenseType()
        {
            bool IsTypeOfBikeLicense = false;

            try
            {
                Console.WriteLine(
 @"Choose Bike License Type from one of the options:
==============================================
1) A 
2) A1
3) B1
4) B2 ");
                string str = Console.ReadLine();
                m_UserBikeLicenseType = UserEnumParseofValue<Bike.eLicenseOfBike>(str);
				if (m_UserBikeLicenseType != null)
				{
					IsTypeOfBikeLicense = true;
					m_Bike.LicenseOfBike = m_UserBikeLicenseType;
					BikeEngineVolume();
				}
                if (!IsTypeOfBikeLicense)
                {
                    Console.WriteLine("Your choose of bike license type not exist in the system ");
                }
            }
            catch (ArgumentException ex)
            {
                IsTypeOfBikeLicense = false;
            }
            if (!IsTypeOfBikeLicense)
            {
				BikeLicenseType();
            }
        }
		private void BikeEngineVolume()
        {
			Console.WriteLine("Please enter your bike engine volume: ");
			string str = Console.ReadLine();
			while (isAllDigits(str) != true)
			{
				Console.WriteLine("You need to enter only digits ! ");
				str = Console.ReadLine();
			}
            ArrayOfInfo[5] = str;
        }
        private void TruckLoadCapacity()
        {
            Console.WriteLine("Please enter your truck load capacity: ");
            string str = Console.ReadLine();
            ArrayOfInfo[6] = str;
        }
		private void IsTrunkOfTruckCool()
        {
            Console.WriteLine("Please enter yes/no if your truck is cool: ");
            string str = Console.ReadLine();
			if (str == "yes")
			{
				m_Truck.IsTrunkCool = true;
			}
			else
			{
				m_Truck.IsTrunkCool = false;
			}
        }
		private static bool isAllDigits(string i_Str)
		{
			foreach (char c in i_Str)
			{
				if (!Char.IsDigit(c))
					return false;
			}
			return true;
		}
		private static bool isAllLetters(string s)
		{
			foreach (char c in s)
			{
				if (!Char.IsLetter(c))
					return false;
			}
			return true;

		}
		private static bool isAllLettersOrDigits(string s)
		{
			foreach (char c in s)
			{
				if (!Char.IsLetter(c) && !Char.IsDigit(c))
					return false;
			}
			return true;

		}
		public void AddVehicleToGarage()
		{
			m_Grage.AddVehicleToGarage(m_VehicleProfile.m_Vehicle.LicenseNumber, m_VehicleProfile);
		}
		public void ChangeVehicleStatusInGarage(GarageVehicleProfile.eStateOfVehicle i_StatusToChange)
		{
            Console.WriteLine("Please enter the Vehicle License that you need to change State for: ");
            string i_strLicense = Console.ReadLine();
            m_Grage.ChangeStateOfVehicleInGarage(i_strLicense, i_StatusToChange);
		}
		public void AddFuelToVehicleInGarage(float i_FuelToAdd)
        {
            Console.WriteLine("Please enter the Vehicle License to add fuel to: ");
            string i_strLicense = Console.ReadLine();
            float m_FuelTypeToAdd = i_FuelToAdd;
			m_Grage.AddFuelToVehicle(i_strLicense, m_FuelType, m_FuelTypeToAdd);
		}
		public void AddElectricityToVehicleInGarage(float i_ElectricityToAdd)
		{
			float m_ElectricityToAdd = i_ElectricityToAdd;
			m_Grage.ChargeElectricityToVehicle(m_VehicleProfile.m_Vehicle.LicenseNumber, m_ElectricityToAdd);
		}
		public void ShowFullDetailsOfVehicleByLicense()
		{
			Console.WriteLine("Please enter the Vehicle License that you want to see his profile and Vehicle data:");
			string str = Console.ReadLine();

			string msg = m_Grage.VehiclesInGarage[str].ToString();
			string msg2 = null;
			if (m_Grage.VehiclesInGarage[str].m_Vehicle == m_Bike)
			{
				msg2 = m_Bike.ToString();
			}
			if (m_Grage.VehiclesInGarage[str].m_Vehicle == m_car)
			{
				msg2 = m_car.ToString();
			}
			if (m_Grage.VehiclesInGarage[str].m_Vehicle == m_Truck)
			{
				msg2 = m_Truck.ToString();
			}
			Console.WriteLine(msg);
			Console.WriteLine(msg2);
			ActionInGarage();
		}
		public void ActionInGarage()
		{

			Console.WriteLine(
@"
Please insert your choice by number for action in the garage: 
=============================================================
1 - Add a vehicle to garage
2 - Show all license number in garage by choosen status
3 - Change status of choosen vehicle in garage
4 - Blow air pressure in vehicle wheeels for maximum psi
5 - To Fuel a fuel engine vehicle
6 - To charge a electricity engine vehicle 
7 - Show a full details of vehicle by license 
8 - return to Main Menu


");
			string UserActionInGarage = Console.ReadLine();
			while (m_IsAddVehicle == true && UserActionInGarage != "1")
			{

				Console.WriteLine("**Alert!! You Need to enter your vehicle to garage first, choose - 1!**");
				ActionInGarage();
			}
			m_IsAddVehicle = false;

			switch (UserActionInGarage)
			{
				case "1": //Add new Vehicle to garage action
					AddVehicleToGarage();
					Console.WriteLine("You successfully Add your vehicle to the garage!");
					ActionInGarage();
					break;

				case "2": //Show all vehicles in garage by license and status
					Console.WriteLine("Enter requested status for filtring: ");
					string i_strState = Console.ReadLine();
					m_UserStateChoose = UserEnumParseofValue<GarageVehicleProfile.eStateOfVehicle>(i_strState);
					m_Grage.ShowAllVehiclesLicenseAndStateInGarage(m_UserStateChoose);
					Console.WriteLine("This is all the vehicles by status: {0} in the garage.", i_strState);
					ActionInGarage();
					break;

				case "3": //change Vehicle status in garage
					Console.WriteLine("Please enter the status of vehicle for change: ");
					string i_strStateChange = Console.ReadLine();
					m_UserStateChoose = UserEnumParseofValue<GarageVehicleProfile.eStateOfVehicle>(i_strStateChange);
					ChangeVehicleStatusInGarage(m_UserStateChoose);
					ActionInGarage();
					break;

				case "4": //Blow air pressure to max in vehicle by license
					Console.WriteLine("Please enter license for wheels max blow : ");
					string i_strLicense = Console.ReadLine();
					m_Grage.BlowMaxPressureByLicense(i_strLicense);
					Console.WriteLine("The vehicle wheels with license No. {0} blow for max psi!", i_strLicense);
					ActionInGarage();
					break;

				case "5": //Add fuel to vehicle in garage
					Console.WriteLine("Enter amount of fuel to add in liters");
					string i_strFuel = Console.ReadLine();
					float i_FuelToAdd = float.Parse(i_strFuel);
					AddFuelToVehicleInGarage(i_FuelToAdd);
					ActionInGarage();
					break;

				case "6": //charge elcetricity to Vehicle in garage
					Console.WriteLine("Enter amount of electricity to add in minutes");
					string i_strElectric = Console.ReadLine();
					float i_ElectricityToAdd = float.Parse(i_strElectric);
					AddElectricityToVehicleInGarage(i_ElectricityToAdd);
					ActionInGarage();
					break;

				case "7":  //Show a full details of vehicle by license 
					ShowFullDetailsOfVehicleByLicense();
					break;

				case "8":  //Exit
					AppMenu();
					break;

				default:

					Console.WriteLine("You Choose invalid option! please try Again!");
					break;
			}

		}
    }        


    

}
