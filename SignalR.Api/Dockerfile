FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60748
EXPOSE 44337

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY SignalR.Web/SignalR.Web.csproj SignalR.Web/
RUN dotnet restore SignalR.Web/SignalR.Web.csproj
COPY . .
WORKDIR /src/SignalR.Web
RUN dotnet build SignalR.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SignalR.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SignalR.Web.dll"]
