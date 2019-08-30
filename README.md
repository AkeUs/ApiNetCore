# Aplicación Net Core

## Comandos para iniciar projecto con dotnet cli (Sin Visual Studio)

Crear directorio del proyecto.

``` powershell
mkdir ApiNetCore
cd ApiNetCore
```

crear proyecto con **dotnet cli**.

``` powershell
dotnet new sln
dotnet new webapi -o ApiNetCore
dotnet sln add ApiNetCore\ApiNetCore.csproj
```

crear repositorio **git**.

``` powershell
git init
git remote add origin https://github.com/AkeUs/ApiNetCore.git
git add .
git commit -m "commit inicial"
git push -u origin master
```

Asignar etiqueta inicial en rama master.

``` powershell
git tag -a v0.0.1 -m "version inicial"
git push origin --tags
```

Los siguientes comando se deben ejecutar a nivel de proyecto, 
donde se encuentra el archivo .csproj, entramos a la carpeta del proycto.

``` powershell
cd ApiNetCore
```

## Entity Framework Core

Crear migracion.

``` powershell
dotnet ef migrations add -n [Nombre de migracion]
```

Actualizar base de datos.

``` powershell
dotnet ef database update
```

## Comandos para agregar paquetes

Sintaxis.
```` powershell
dotnet add package [Nombre del paquete]
````

**Automapper**
```` powershell
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
````

## Net Core

Restaurar paquetes
```` powershell
dotnet restore
````

Compilar la aplicacion

```` powershell
dotnet build -c Release
````

Ejecutar pruebas unitarias
```` powershell
dotnet test
````

Crear version para publicar

```` powershell
dotnet publish -c Release -o app
````
