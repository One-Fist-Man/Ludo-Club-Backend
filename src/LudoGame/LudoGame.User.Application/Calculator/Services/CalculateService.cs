namespace LudoGame.User.Application.Calculator.Models;

public class CalculateService()
{
    public int Calculate(CalculateModel model)
    {
        var result = 0;
        if (model.Operation == "+") { 
        result = model.Value1+model.Value2;
        }

        else if (model.Operation == "-") {
            result = model.Value1 - model.Value2;
        }
        else if (model.Operation == "*")
        {
            result = model.Value1 * model.Value2;
        }
        else if (model.Operation == "/")
        {
            result = model.Value1 / model.Value2;
        }
        
        return result;
    }

}