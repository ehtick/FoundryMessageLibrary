namespace IoBTMessage.Models;

public class UnitFamily
{
    private string Name { get; set; }
    protected Units DefaultUnits { get; set; }

    public UnitFamily(string name)
    {
        Name = name;
    }
}

public class Units
{
    private string Name { get; set; }
    private UnitFamily ParentFamily { get; set; }
    public Units(string name)
    {
        Name = name;
    }
}

public class MeasuredValue<T>
{
    protected T Value { get; set; }
    protected Units BaseUnits { get; set; }
    protected UnitFamily UnitCategory { get; set; }
}

public class Distance: MeasuredValue<double>
{
    public Distance()
    {
        BaseUnits = new Units("m"); //meters
        UnitCategory = new UnitFamily(this.GetType().Name);
    }
}

public class Time: MeasuredValue<double>
{
    public Time()
    {
        BaseUnits = new Units("sec"); //seconds
        UnitCategory = new UnitFamily(this.GetType().Name);
    }

    public Time Hours(double value){
        this.Value = value / 3600.0;
        return this;
    }

    
    public Time Minutes(double value){
        this.Value = value / 60.0;
        return this;
    }
        public Time MicroSeconds(double value){
        this.Value = 1000.0 * value;
        return this;
    }
}

public class Angle: MeasuredValue<double>
{
    public Angle()
    {
        BaseUnits = new Units("deg"); //seconds
        UnitCategory = new UnitFamily(this.GetType().Name);
    }
    public Angle Degrees(double value){
        this.Value = value;
        return this;
    }
    public Angle Radians(double value){
        this.Value = value * 180.0 / Math.PI;
        return this;
    }

    public double Degrees(){
        return this.Value;
    }
    public double Radians(){
        return this.Value * Math.PI / 180.0;
    }
}

public class Speed: MeasuredValue<double>
{
    public Speed()
    {
        BaseUnits = new Units("m/s"); //meters per second
        UnitCategory = new UnitFamily(this.GetType().Name);
    }

    public Speed MetersPerSecond(double value){
        this.Value = value;
        return this;
    }

    public Speed MilesPerHour(double value){
        this.MetersPerSecond(value / 3600.0 * 1609.34);
        return this;
    }

    public Speed KilometersPerHour(double value){
        this.MetersPerSecond(value / 3600.0 * 1000);
        return this;
    }

    public double MetersPerSecond(){
        return this.Value;
    }

    public double KiloMetersPerSecond(){
        return this.Value / 1000.0;
    }

    public double MilesPerSecond(){
        return this.Value / 1609.34;
    }
}