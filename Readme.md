# Translation system service

Provides information about available language directions and domains that platform supports.
Can be used in frontend to show which languages are available or other api services to validate language directions.

## Terminology

`translation system` - source language + target language + domain

Publishes available language directions and domain information

## Architecture

```

 ------------------------------------
|                                   |
|    Translation system service     |
|            [Public]               |
|                                   |
 ------------------------------------

                ↓
                ↓
                ↓   Publishes available language directions (via RabbitMQ)
                ↓

                .
                .

```

