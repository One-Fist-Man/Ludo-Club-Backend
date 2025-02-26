using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverAspirants.Common;
using MediatR;

namespace LudoGame.User.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse>
    :IRequest<Result<TResponse>> where TResponse: class
{

}

public interface ICommandHandler<TCommand>:
    IRequestHandler<TCommand,Result> where TCommand:ICommand
{

}

public interface ICommandHandler<TCommand, TResponse>
    :IRequestHandler<TCommand,Result<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse :class
{ }

