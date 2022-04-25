# PruebaNexos

El siguiente es un proyecto desarrollado en .net con el fin de cumplir los requerimientos propuestos por la prueba técnica para el cargo de ingeniero de desarrollo .net

Este proyecto se realizó en .net(EntityFramework 5), con base de datos Oracle, está realizado en 4 capas, la primera hace referencia a PruebaNexos.Api,
donde es una ApiRest que contiene acciones Get y post, para listar los datos de los libros y autores existente y también acciones para crear dichas condiciones.
Por segunda parte podemos encontrar PruebaNexos.web, que es el frondend de la prueba, realizada en MVC, este tiene dos pantallas, una que me muestra el contenido 
de los libros donde podemos filtrarlos por cualquier campo de la tabla, paginación y modal para crear libros, donde se debe tener en cuenta que el número máximo de 
libros por crear son 10 lo cual era uno de los requerimientos igual que si el autor no existe no se puede crear un libro. 
En la tercera capa podemos ver PruebaNexos.Core donde están las interfaces y los servicios y la última capa PruebaNexos.Data donde está todo lo que son DTOs, 
Entities, conexión a base de datos y control de excepciones.

La solución cuenta también de inyección de dependencias, bootstrap, JavaScript entre otros.

Con respecto a la base de datos, esta cuenta con dos tablas, libros y autores cada una con sus respectivas columnas requeridas por el problema.
