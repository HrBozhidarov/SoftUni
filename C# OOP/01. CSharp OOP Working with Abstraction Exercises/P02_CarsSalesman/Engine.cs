using System.Text;

public class Engine
{
    private const string Offset = "  ";
    private const int DisplacementValue = -1;
    private const string EfficiencyValue = "n/a";

    private string model;
    private int power;
    private int displacement;
    private string efficiency;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacement = DisplacementValue;
        this.efficiency = EfficiencyValue;
    }

    public Engine(string model, int power, int displacement)
        : this(model, power)
    {
        this.displacement = displacement;
    }

    public Engine(string model, int power, string efficiency)
        : this(model, power)
    {
        this.efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency)
        : this(model, power)
    {
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public string Model => this.model;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}{1}:\n", Offset, this.model);
        sb.AppendFormat("{0}{0}Power: {1}\n", Offset, this.power);
        sb.AppendFormat("{0}{0}Displacement: {1}\n", Offset, this.displacement == -1 ? EfficiencyValue : this.displacement.ToString());
        sb.AppendFormat("{0}{0}Efficiency: {1}\n", Offset, this.efficiency);

        return sb.ToString();
    }
}