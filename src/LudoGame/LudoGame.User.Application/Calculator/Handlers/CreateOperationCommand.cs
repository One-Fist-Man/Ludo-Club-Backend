using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.User.Application.Interfaces;
using MediatR;

namespace LudoGame.User.Application.Calculator.Handlers; 



    public class CreateOperationCommand : IRequest<int>
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
    public string Operation { get; set; } = string.Empty;
} 

public class CreateOperationCommandHandler(IRepository<Operation>repository)
    :IRequestHandler<CreateOperationCommand,int>
{
    private readonly IRepository<Operation> _repository=repository; 
    public async Task<int> Handle(CreateOperationCommand request,CancellationToken cancellation)
    {
        var result = 0;
        if(request.Operation == "+")
        {
            result = request.Value1+ request.Value2; ;
        }
        if(request.Operation=="-")
        {
            result = request.Value1 - request.Value2; ; 
        }
        if(request.Operation=="*")
        {
            result = request.Value1 * request.Value2;  
        }
        if(request.Operation=="/")
        {
            result = request.Value1 / request.Value2;   
        }
        var operation = new Operation().Create(request.Value1, request.Value2, request.Operation);
        await _repository.AddAsync(operation);
        return result;
    }
}
