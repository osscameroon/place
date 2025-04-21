FROM python:3.13-slim-bookworm AS builder
COPY --from=ghcr.io/astral-sh/uv:latest /uv /uvx /bin/

# Change the working directory to the `app` directory
WORKDIR /opt

# Install dependencies
RUN --mount=type=cache,target=/root/.cache/uv \
    --mount=type=bind,source=uv.lock,target=uv.lock \
    --mount=type=bind,source=pyproject.toml,target=pyproject.toml \
    uv sync --frozen --no-install-project --no-editable --no-dev --group prod

# Copy the project into the intermediate image
ADD ./app /opt/place

FROM python:3.13-slim-bookworm

WORKDIR /opt

# Copy the environment, but not the source code
COPY --from=builder --chown=opt:opt /opt /opt

EXPOSE 8000

# Run the application
CMD ["gunicorn", "place.asgi:application", "-k", "uvicorn_worker.UvicornWorker"]
