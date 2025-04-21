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
     python flask --app app run --debug
     ```  
   - **With UV (Faster):**  
     ```sh
     uv run flask --app app run --debug
     ```  
   - **With Docker:**  
     ```sh
     docker compose up -d
     ```  

**Access the webapp**  
   Open your browser at:  
   🔗 [http://127.0.0.1:5000/hello](http://127.0.0.1:5000/hello)  


## License

This project is open-source under the **[MIT License](LICENSE)**.  
