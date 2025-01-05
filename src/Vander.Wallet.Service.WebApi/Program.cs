using MediatR;
using Vander.Wallet.Service.Application.QueryStack.Balance.Query;
using Vander.Wallet.Service.CommandStack.Account.Command;
using Vander.Wallet.Service.CommandStack.Deposit.Command;

var builder = WebApplication.CreateBuilder(args);

// Configura o MediatR
builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

// Endpoints usando Minimal APIs
app.MapPost("/accounts", async (IMediator mediator, CreateAccountCommand command) =>
{
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapPost("/accounts/{id}/deposit", async (IMediator mediator, DepositCommand command, Guid id) =>
{
    command.AccountId = id;
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapGet("/accounts/{id}/balance", async (IMediator mediator, Guid id) =>
{
    var result = await mediator.Send(new GetBalanceQuery { AccountId = id });
    return result is not null ? Results.Ok(result) : Results.NotFound();
});

app.Run();