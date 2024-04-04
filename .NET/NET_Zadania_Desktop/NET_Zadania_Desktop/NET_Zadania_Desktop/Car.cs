using System;
using System.Collections.Generic;

namespace NET_Zadania_Desktop { 

    public abstract class Car
    {
        protected string Brand;
        protected string Model;
        protected string ProductionYear;

        public Car(string brand, string model, string prodYear)
        {
            this.Brand = brand;
            this.Model = model;
            this.ProductionYear = prodYear;
        }

        public abstract Dictionary<string, string> GetAllValues();
        public abstract String GetValuesString();
    }

    public class FamilyCar : Car
    {
        protected string TrunkVolume;
        protected string NumberOfSeats;

        public FamilyCar(string brand, string model, string prodYear, string trunkVolume, string numOfSeats)
            : base(brand, model, prodYear)
        {
            this.TrunkVolume = trunkVolume;
            this.NumberOfSeats = numOfSeats;
        }

        public override Dictionary<string,string> GetAllValues()
        {
            var values = new Dictionary<string, string>();
            values.Add("Brand", this.Brand);
            values.Add("Model", this.Model);
            values.Add("Production Year",this.ProductionYear);
            values.Add("Trunk Volume", this.TrunkVolume);
            values.Add("Number Of Seats", this.NumberOfSeats);

            return values;
        }
        public override string GetValuesString() => $"Rodzinne, {this.Brand}, {this.Model} ";
    }

    public class SportCar : Car
    {
        protected string Acceleration;
        protected string FuelConsumption;

        public SportCar(string brand, string model, string prodYear, string acceleration, string fuelConsumption)
            : base(brand, model, prodYear)
        {
            this.Acceleration = acceleration;
            this.FuelConsumption = fuelConsumption;
        }

        public override Dictionary<string, string> GetAllValues()
        {
            var values = new Dictionary<string, string>();
            values.Add("Brand", this.Brand);
            values.Add("Model", this.Model);
            values.Add("Production Year", this.ProductionYear);
            values.Add("Acceleration", this.Acceleration);
            values.Add("Fuel Consumption", this.FuelConsumption);

            return values;
        }

        public override string GetValuesString() => $"Sportowe, {this.Brand}, {this.Model}";        


    }

    public class TerrainCar : Car
    {
        protected string Conversion;
        protected string GearBox;

        public TerrainCar(string brand, string model, string prodYear, string conversion, string gearBox)
            : base(brand, model, prodYear)
        {
            this.Conversion = conversion;
            this.GearBox = gearBox;
        }

        public override Dictionary<string, string> GetAllValues()
        {
            var values = new Dictionary<string, string>();

            values.Add("Brand", this.Brand);
            values.Add("Model", this.Model);
            values.Add("Production Year", this.ProductionYear);
            values.Add("Conversion", this.Conversion);
            values.Add("Gear Box Type", this.GearBox);

            return values;
        }

        public override string GetValuesString() => $"Terenowe, {this.Brand}, {this.Model} ";
    }
}