# FarmacyMedic - Aplicación Web para Gestión de Inventario 

![FarmacyMedic](https://github.com/alelolek/FarmacyMedic/blob/main/Arquitecture)

## Descripción

FarmacyMedic es una aplicación web ASP.NET MVC desarrollada utilizando tecnologías modernas como ASP.NET Core 6, Entity Framework (Code-First approach), AutoMapper e inyección de dependencias. La aplicación está diseñada para gestionar el inventario de una farmacia, lo que permite a los usuarios llevar un control eficiente de los medicamentos y otros productos disponibles en stock.

## Arquitectura de Proyecto

La arquitectura de FarmacyMedic sigue el patrón MVC (Modelo-Vista-Controlador), que ayuda a organizar el código en capas para una mejor separación de preocupaciones. A continuación, se describe la estructura básica del proyecto:

- **Models**: Esta carpeta contiene los modelos de datos utilizados en la aplicación, incluyendo DAOs (Data Access Objects), DTOs (Data Transfer Objects) y Entities (Entidades).

- **Controllers**: En esta carpeta se encuentran los controladores de la aplicación que manejan las solicitudes de los usuarios y coordinan las acciones apropiadas.

- **Views**: Aquí se ubican los archivos CSHTML, que representan la interfaz de usuario de la aplicación.

## Características Principales

- Gestión de inventario: FarmacyMedic permite agregar, eliminar y actualizar medicamentos y otros productos en el inventario de la farmacia.

- Búsqueda eficiente: Los usuarios pueden buscar rápidamente productos por nombre, categoría, etc., para facilitar la ubicación de elementos específicos en el inventario.

- Interfaz intuitiva: La interfaz de usuario ha sido diseñada para ser fácil de usar, proporcionando una experiencia fluida para los usuarios.

- Optimizado para rendimiento: FarmacyMedic está desarrollado siguiendo las mejores prácticas para asegurar un rendimiento óptimo incluso en entornos con alta concurrencia.

## Diagrama de Base de Datos

A continuación se muestra el diagrama que representa la estructura de la base de datos utilizada en FarmacyMedic:

![Diagrama Base de Datos](https://github.com/alelolek/FarmacyMedic/blob/main/DiagramaBD.PNG)

## Instalación

Para instalar y ejecutar FarmacyMedic en su máquina local, siga estos pasos:

1. Clonar el repositorio desde GitHub: `git clone url_del_repositorio.git`

2. Asegúrese de tener instalado .NET 6 SDK en su sistema.

3. Configure la cadena de conexión a la base de datos en el archivo `appsettings.json`.

4. Abra una terminal en la carpeta raíz del proyecto y ejecute el siguiente comando: `dotnet run`.

5. Abra su navegador web y navegue a `http://localhost:puerto` para acceder a la aplicación.

## Contribución

Si desea contribuir al desarrollo de FarmacyMedic, le agradecemos sus aportes. Puede realizarlo mediante los siguientes pasos:

1. Haga un fork de este repositorio y clónelo en su máquina local.

2. Cree una nueva rama para trabajar en su mejora: `git checkout -b nombre_de_la_rama`.

3. Realice los cambios y agregue sus mejoras.

4. Realice un commit con un mensaje descriptivo: `git commit -m "Descripción del cambio"`.

5. Haga push de la rama a su repositorio en GitHub: `git push origin nombre_de_la_rama`.

6. Finalmente, abra un pull request en el repositorio original y describa los cambios que ha realizado.

## Licencia

FarmacyMedic se distribuye bajo la Licencia MIT. Consulte el archivo [LICENSE](https://github.com/alelolek/FarmacyMedic/blob/main/LICENSE.txt) para obtener más información acerca de los derechos y limitaciones que impone la licencia.