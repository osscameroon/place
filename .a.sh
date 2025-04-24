set -ex

docker run -d place
sleep 5
curl -Is http://127.0.0.1
