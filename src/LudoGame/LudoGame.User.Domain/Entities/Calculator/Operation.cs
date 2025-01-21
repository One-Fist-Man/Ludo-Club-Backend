

public class Operation
{
    public Guid Id { get; private set; }
    public int Value1 { get; private set; }
    public int Value2 { get; private set; }
    public string Operator { get; private set; } = string.Empty;

    public Operation Create(int value1, int value2, string operation)
    {
        Value1= value1;
        Value2 = value2;
        Operator = operation;   
        return this;
    }
}
