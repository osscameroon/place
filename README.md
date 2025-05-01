# place

![Screenshot From 2025-05-01 21-09-07](https://github.com/user-attachments/assets/d62aabeb-3c84-49a2-b12d-a0056b3a2877)

An event application for Cameroon that helps users find events based on their interests, location, and availability.

## Deployment Guide

### Prerequisites 

- **Python 3.11+** ([Download](https://python.org))  
- **Docker** (Optional) ([Install Docker](https://docs.docker.com/get-started/get-docker/))  
- **UV** (Optional, for fast Python management) ([Install UV](https://docs.astral.sh/uv/getting-started/installation/))  

### Setup Instructions

**Install Dependencies**  
  - **With Python:**  
    ```sh
    pip install .
    ```  
  - **With UV (Faster):** No needed 
  - **With Docker:**  No needed 

**Setup**
  - **With Python:**  
    ```sh
    python place/manage.py makemigrations
    python place/manage.py migrate
    ```  
  - **With UV (Faster):**  
    ```sh
    uv run place/manage.py makemigrations
    uv run place/manage.py migrate
    ```  
  - **With Docker:**  No needed 

**Run the App**  
  - **With Python:**  
    ```sh
    python place/manage.py runserver
    ```  
  - **With UV (Faster):**  
    ```sh
    uv run place/manage.py runserver
    ```  
  - **With Docker:**  
    ```sh
    docker compose up -d
    ```  

**Loading the dummy data**
  - **With Python:**  
    ```sh
    python place/manage.py shell -c "import core.dummy_data"
    ```  
  - **With UV (Faster):**  
    ```sh
    uv run place/manage.py shell -c "import core.dummy_data"
    ```  
  - **With Docker:**  
    ```sh
    docker compose exec place-web ./entrypoint.sh shell -c \"import core.dummy_data\"
    ```  

**Access the webapp**  
  Open your browser at: [http://127.0.0.1:8000](http://127.0.0.1:8000)

## License

All the code in this repository is released under the Mozilla Public License v2.0, for more information take a look at the [LICENSE](LICENSE) file.
