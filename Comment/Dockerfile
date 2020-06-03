#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Comment/Comment.csproj", "Comment/"]
RUN dotnet restore "Comment/Comment.csproj"
COPY . .
WORKDIR "/src/Comment"
RUN dotnet build "Comment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Comment.csproj" -c Release -o /app/publish

RUN wget https://chromedriver.storage.googleapis.com/2.46/chromedriver_linux64.zip &&\
      unzip chromedriver_linux64.zip &&\
      cp chromedriver /usr/sbin/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Comment.dll"]