FROM  mcr.microsoft.com/dotnet/sdk as build-env
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet 
WORKDIR /app
COPY --from=build-env /app/out .
COPY .db ./
ENTRYPOINT ["dotnet", "MvcMovie.dll"]