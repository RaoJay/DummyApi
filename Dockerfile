FROM mcr.microsoft.com/dotnet/core/sdk:5.0 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY DummyApi/*.csproj ./DummyApi/
COPY DummyApp/*.csproj ./DummyApp/
COPY DummyServic/*.csproj ./DummyServic/
COPY DummyWrapper/*.csproj ./DummyWrapper/ 
#
RUN dotnet restore 
#
# copy everything else and build app
COPY DummyApi/. ./DummyApi/
COPY DummyApp/. ./DummyApp/
COPY DummyServic/. ./DummyServic/
COPY DummyWrapper/. ./DummyWrapper/
#
WORKDIR /app/DummyApi
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:5.0 AS runtime
WORKDIR /app 
#
COPY --from=build /app/DummyApi/out ./
ENTRYPOINT ["dotnet", "DummyApi.dll"]