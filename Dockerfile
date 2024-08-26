FROM mcr.microsoft.com/dotnet/aspnet:8.0

COPY src/Web/App /app

WORKDIR /app

EXPOSE 443/tcp

ENTRYPOINT ["dotnet", "Web.dll"]