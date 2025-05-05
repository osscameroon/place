# place

![Screenshot From 2025-05-01 21-09-07](https://github.com/user-attachments/assets/d62aabeb-3c84-49a2-b12d-a0056b3a2877)

An event application for Cameroon that helps users find events based on their interests, location, and availability.

## Table of Contents
* **[Installation](#installation)**
  * [uv](#uv)
  * [Pip](#pip)
  * [Docker](#docker)
* [Contributing](#contributing)
* [Support](#support)
* [License](#license)

## 📖 Installation

Place can be installed via Pip or Docker. To start, clone the repo to your local computer and change into the proper directory.

### 🧰 Prerequisites 

- **Python 3.11+** ([Download](https://python.org))  
- **Docker** (Optional) ([Install Docker](https://docs.docker.com/get-started/get-docker/))  
- **UV** (Optional, for fast Python package management) ([Install UV](https://docs.astral.sh/uv/getting-started/installation/))  

### Install Dependencies

- With Pip:

```sh
pip install .
```

- With uv:

```sh
uv sync
```

- With Docker: Not needed

### Setup

- With Python:

```sh
python place/manage.py migrate
```

- With uv:

```sh
uv run place/manage.py migrate
```
 
- With Docker: Not needed 

### Run the App

- With Python:

```sh
python place/manage.py runserver
```

- With uv:

```sh
uv run place/manage.py runserver
```

- With Docker: 

```sh
docker compose up -d
```  

### Load the dummy data

- With Python:

```sh
python place/manage.py shell -c "import core.dummy_data"
```
  
- With uv:

```sh
uv run place/manage.py shell -c "import core.dummy_data"
```

- With Docker:

```sh
docker compose exec place ./entrypoint.sh shell -c \"import core.dummy_data\"
```

**Access the webapp**  
  Open your browser at: [http://127.0.0.1:8000](http://127.0.0.1:8000) or [http://127.0.0.1:8000/admin](http://127.0.0.1:8000/admin) for the admin

## 🤝 Contributing

Contributions, issues and feature requests are welcome! See [CONTRIBUTING.md](https://github.com/wsvincent/lithium/blob/master/CONTRIBUTING.md).

## ⭐️ Support

Give a ⭐️  if this project helped you!

## License

All the code in this repository is released under the Mozilla Public License v2.0, for more information take a look at the [LICENSE](LICENSE) file.
