# Customers

En este repositorio se encuentran dos proyectos :
- CustomersApi
- CustomersUI

Los proyectos mencionados forman parte de una solución, la cual nos permite administrar clientes y sus respectivas direcciones.

## CustomersAPI
Este proyecto es un API desarrollada en .NET 6 y SQL Server para la persistencia de datos, contiene los endpoints que nos permiten agregar clientes y sus direcciones, para poder administrar las direcciones de manera efectiva 
se crearon modelos que representan los diferentes elementos que componen una dirección, como el país, la ciudad de cada país, sectores de cada ciudad, etc, de manera que se puedan filtrar los cientes 
por los mismos.

## CustomersUI
Es el proyecto de presentacion al usuario, esta creado en Angular 15, contiene las diferentes pantallas que el usuario final podra ver para utilizar el sistema.

## Correr el proyecto

Para correr este proyecto, debe obviamente primero clonarlo, utilice el siguiente comando:

``git clone https://github.com/Andersonpolanco1/Customers.git``

Se creara la carpeta de nombre Customers con ambos proyectos, puede correr el proyecto CustomersUI abriendo una consola en la ruta de la carpeta CustomersUI
y corriendo el siguiente comando ``ng serve --open`` (debe tener angular instalado en su sistema).

El proyecto correrá y podra ver las pantallas sin información hasta que corra el lado del backend (CustomersAPI).

Para correr este proyecto debe tener SQL Server y visual studio 2022 en su maquina local, abra la solucion CustomersAPI con Visual Studio 2022 y ajuste la cadena de conexión.
Corra el proyecto dandole a F5 dentro de Visual Studio y cuando todo este listo, comience agregando algo de datos para poder visualizar en el frontend, puede utilizar la interfaz
de Swagger para esto o hacerlo directamente en las pantallas del proyecto UI.

## Demo

### Imagenes de la API:

Endpoints para administrar los paises:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/countries-api.JPG)

Endpoints para administrar las ciudades:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/cities-api.JPG)

Endpoints para administrar los sectores:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/neighborhoods-api.JPG)

Endpoints para administrar los clientes:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/customers-api.JPG)

Endpoints para administrar las direcciones de los clientes:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/addressess-api.JPG)

### Imagenes del frontend

Index de la aplicación, lista de clientes:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/countries-ui.JPG)


Consulta de las direcciones de un cliente:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/customer-detail-ui.JPG)

Menú de mantenimientos:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/maintenance-ui.JPG)

Mantenimiento de paises:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/countries-ui.JPG)


Mantenimiento de ciudades:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/cities-ui.JPG)


Mantenimiento de sectores de las ciudades:

![Alt](https://github.com/Andersonpolanco1/Customers/blob/master/Demo/neighborhood-ui.JPG)


