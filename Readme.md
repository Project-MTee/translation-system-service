# Translation system service

Provides information about available language directions and domains that platform supports.
Can be used in frontend to show which languages are available or other api services to validate language directions.

## Terminology

`translation system` - source language + target language + domain

## Architecture

```

 ------------------------------------
|                                   |
|    Translation system service     |
|            [Public]               |
|                                   |
 ------------------------------------

```

# Test

Install MySQL

```Shell
helm repo add bitnami https://charts.bitnami.com/bitnami
helm repo update

# MySQL
helm install mysql --set auth.rootPassword=root bitnami/mysql
```

forward ports:

```Shell
# MySQL
kubectl port-forward --namespace default svc/mysql 3306:3306
```

Using docker compose
```
docker-compose up --build
```

Open Swagger
```
http://localhost:5002/swagger/index.html
```