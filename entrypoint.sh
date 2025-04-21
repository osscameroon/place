#!/usr/bin/sh

PATH="$PATH:.venv/bin"

.venv/bin/python manage.py collectstatic --noinput
.venv/bin/python manage.py migrate

gunicorn place.asgi:application -k uvicorn_worker.UvicornWorker -b 0.0.0.0:8000