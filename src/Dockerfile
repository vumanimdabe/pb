FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["phonebookapi/phonebookapi.csproj", "phonebookapi/"]
RUN dotnet restore "phonebookapi/phonebookapi.csproj"
COPY . .
WORKDIR "/src/phonebookapi"
RUN dotnet build "phonebookapi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "phonebookapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "phonebookapi.dll"]