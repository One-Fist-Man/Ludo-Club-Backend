using LudoGame.User.Application.Interfaces;

namespace LudoGame.User.Application.Calculator.Models;


public class CalculateService(IRepository<Operation> repository) : ICalculateService
{
    private readonly IRepository<Operation> _repository =repository;
    public async Task<int> Calculate(CalculateModel model)
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

        var operation = new Operation()
            .Create(model.Value1, model.Value2, model.Operation);
        await _repository.AddAsync(operation);
        
        return result;
    }

}