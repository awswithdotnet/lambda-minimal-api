var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

app.MapGet("/values", (HttpRequest request) => {
    
    return request?.Query?.Select(s=> s.Value.ToString()).ToArray() ?? new string[0];
    }
);

app.MapGet("/keys", (HttpRequest request) => {
    
    return request?.Query?.Select(s=> s.Key.ToString()).ToArray() ?? new string[0];
    }
);

app.Run();