# place

An event application for Cameroon that helps users find events based on their interests, location, and availability.

## Deployment Guide

### Prerequisites 

- **Python 3.11+** ([Download](https://python.org))  
- **Docker** (Optional) ([Install Docker](https://docs.docker.com/get-started/get-docker/))  
- **UV** (Optional, for fast Python management) ([Install UV](https://docs.astral.sh/uv/getting-started/installation/))  

### Setup Instructions

**Install Dependencies**  
  ```sh
  pip install .
  ```

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

**Access the webapp**  
  Open your browser at: [http://127.0.0.1:8000](http://127.0.0.1:8000)

## License

All the code in this repository is released under the Mozilla Public License v2.0, for more information take a look at the [LICENSE](LICENSE) file.
