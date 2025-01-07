using MediatR;
using Vander.Wallet.Service.Application.QueryStack;
using Vander.Wallet.Service.Application.QueryStack.RetrieveBalance.Query;
using Vander.Wallet.Service.CommandStack;
using Vander.Wallet.Service.CommandStack.DepositFund.Command;
using Vander.Wallet.Service.CommandStack.Wallet.Command;
using Vander.Wallet.Service.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommandStackServiceExtensions();
builder.Services.AddQueryStackServiceExtensions();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapPost("/accounts", async (IMediator mediator, CreateWalletCommand command) =>
{
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapPost("/accounts/{id}/deposit", async (IMediator mediator, DepositFundCommand command, Guid id) =>
{
    command.AccountId = id;
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapGet("/accounts/{id}/balance", async (IMediator mediator, Guid id) =>
{
    var result = await mediator.Send(new RetrieveBalanceQuery { AccountId = id });
    return result is not null ? Results.Ok(result) : Results.NotFound();
});

app.Run();