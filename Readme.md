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

# Monitor

## Healthcheck probes

https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/

Startup probe / Readiness probe:

`/health/ready`

Liveness probe:

`/health/live`


# Test

Using docker compose
```
docker-compose up --build
```

Open Swagger
```
http://localhost:5002/swagger/index.html
```