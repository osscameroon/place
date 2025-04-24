#!/usr/bin/sh

PATH="$PATH:.venv/bin/"

set -ex

.venv/bin/python manage.py collectstatic --noinput
.venv/bin/python manage.py migrate --noinput

if [ -z "$@" ]; then
    gunicorn place.asgi:application -k uvicorn_worker.UvicornWorker -b 0.0.0.0:8000
else
    eval .venv/bin/python manage.py $@
fi