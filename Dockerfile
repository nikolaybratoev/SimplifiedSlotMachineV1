FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "SimplifiedSlotMachineV1.dll" ]

# download and run the container
# docker pull nikbratoe/slotmachinev1
# docker run -p 8080:80 -d nikbratoe/slotmachinev1