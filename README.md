
# filtro. indicaciones



El proyecto cuenta con que al momento de ser registrado se genera un token de seguridad 
para  que el usuario tenga un registro unico. tambien cuenta con autorizacion.  en todos los endpoints. porfavor suministrar bearer con rol de administrador o gerente.
tambien cuenta con semilla. recuerde reemplazar credenciales. ademas porfavor importar el json en insomnia llamado endpoints veterinaria

## ejemplos de peticiones (CRUD)

![get](/Media/get.png)
![post](/Media/post.png)
![update](/Media/put.png)
![delete](/Media/delete.png)


no olvide ejecutar las migraciones. la carpeta ya esta creada. porfavor hacer el database update.

```
dotnet ef database update --project ./Percistence/ --startup-project ./API/
```



endpoints para consultas. solo pude realizar 3.


1: Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.
```
http://localhost:8080/API/Veterinario?ver=1.2&especialidad=cardiobascular
```

2: Listar los medicamentos que pertenezcan a el laboratorio Genfar
```
http://localhost:8080/API/Medicamento?ver=1.2

```

```
http://localhost:8080/API/Medicamento?ver=1.3

```




