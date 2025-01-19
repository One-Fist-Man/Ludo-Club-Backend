namespace LudoGame.User.Application.Calculator.Models;


public class CalculateService()
{
    private readonly ApplicationDbContext dbContext;
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
        await dbContext.Operation.AddAsync(result);
        await dbContext.SaveChanges();
        return result;
    }

}