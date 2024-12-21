# Demo MediatR with Fluent Validation and Logging Request

In this we use custom exception handler to better response
for api requests

### Run Project
```
dotnet run
```

You can comment out pipelines from `ServicesConfigurations.cs` to
disable logging or validation
```csharp
cfg.AddOpenBehavior(typeof(LogPipeline<,>));
cfg.AddOpenBehavior(typeof(ValidationPipeline<,>));
```