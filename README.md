# Comandos para iniciar projecto net core con dotnet cli (Sin Visual Studio)

Crear directorio del proyecto

``` powershell
mkdir ApiNetCore
cd ApiNetCore
```

crear proyecto con **dotnet cli**

``` powershell
dotnet new sln
dotnet new webapi -o ApiNetCore
dotnet sln add ApiNetCore\ApiNetCore.csproj
```

repositorio de git

``` powershell
git init
git remote add origin https://github.com/AkeUs/ApiNetCore.git
git add .
git commit -m "commit inicial"
git push -u origin master
```
