# Blog_Engine
Api de Prueba técnica realizada para Zemoga.

# Detalles Técnicos de la Implementación
La implementación de la solución se realizó teniendo en cuenta buenas prácticas y una arquitectura limpia. A Continuación se describe el detalle de la solución técnica implementada:

- La implementación se realizó usando .Net Core 3.1
- Se utilizó la arquitectura Onion.
- El ORM utilizado fue Entity Framework Core con el enfoque Code First.
- El acceso a datos se realizó implementando el patrón de diseño Repository.
- Se hizo uso del patrón de diseño Unit Of Work para el control de transacciones.
- Se implementó un Middleware para el manejo de excepciones, con el objetivo de controlar todas las excepciones generadas.
- La autenticación de la aplicación se realiza por medio de tokens JWT.
- Se realiza cifrado de la contraseña de ususario usando el algoritmo SHA-256.
- La persistencia de datos se realizó en una base de datos SQL Server.

# Manual para Ejecución del Api

En el repositorio en la ruta Manuales/ManualDeEjecución.Docx se puede encontrar el manual de ejecución dónde está el paso a paso para la ejecución.
