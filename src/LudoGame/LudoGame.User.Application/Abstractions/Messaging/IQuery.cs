using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverAspirants.Common;
using MediatR;

namespace LudoGame.User.Application.Abstractions.Messaging;

public interface IQuery<TResponse>:IRequest<Result<TResponse>> where TResponse: class
{ }

public interface IQueryHandler<TQuery,TResponse>
    :IRequestHandler<TQuery, Result<TResponse>>
    where TQuery:IQuery<TResponse>
    where TResponse : class
{ }