FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["PhoneBook/PhoneBook.csproj", "PhoneBook/"]
RUN dotnet restore "PhoneBook/PhoneBook.csproj"
COPY . .
WORKDIR "/src/PhoneBook"
RUN dotnet build "PhoneBook.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PhoneBook.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PhoneBook.dll"]