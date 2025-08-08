FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# استفاده از image رسمی .NET SDK برای build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# کپی کردن فایل‌های پروژه
COPY ["TicketingSystem.API/TicketingSystem.API.csproj", "TicketingSystem.API/"]
COPY ["TicketingSystem.Application/TicketingSystem.Application.csproj", "TicketingSystem.Application/"]
COPY ["TicketingSystem.Domain/TicketingSystem.Domain.csproj", "TicketingSystem.Domain/"]
COPY ["TicketingSystem.Infrastructure/TicketingSystem.Infrastructure.csproj", "TicketingSystem.Infrastructure/"]
COPY ["TicketingSystem.Shared/TicketingSystem.Shared.csproj", "TicketingSystem.Shared/"]


# restore dependencies
RUN dotnet restore "TicketingSystem.API/TicketingSystem.API.csproj"

# کپی کردن همه فایل‌های پروژه
COPY . .
WORKDIR "/src/TicketingSystem.API"

# build پروژه
RUN dotnet build "TicketingSystem.API.csproj" -c Release -o /app/build

# publish پروژه
FROM build AS publish
RUN dotnet publish "TicketingSystem.API.csproj" -c Release -o /app/publish

# ساخت image نهایی
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketingSystem.API.dll"]
