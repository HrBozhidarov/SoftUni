using System.Text;

public class Car
{
    private const string Offset = "  ";
    private const int Weight = -1;
    private const string Color = "n/a";

    private string model;
    private Engine engine;
    private int weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = Weight;
        this.color = Color;
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {
        this.weight = weight;
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        this.color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
        : this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}:\n", this.model);
        sb.Append(this.engine.ToString());
        sb.AppendFormat("{0}Weight: {1}\n", Offset, this.weight == -1 ? Color : this.weight.ToString());
        sb.AppendFormat("{0}Color: {1}", Offset, this.color);

        return sb.ToString();
    }
}